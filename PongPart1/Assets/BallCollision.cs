using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{

    public float speed = 20f;
    public float accel = .5f;
    public Transform[] spawnTransforms;
    public AudioClip paddleSound1;
    public AudioClip paddleSound2;
    public AudioClip wallSound;
    public int lasthit;

    // Start is called before the first frame update
    void Start()
    {
        Transform randomTransform = spawnTransforms[Random.Range(0, spawnTransforms.Length)];
        this.GetComponent<Rigidbody>().AddForce(randomTransform.right * speed);
        lasthit = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Paddle") {
            AudioSource audioSource = GetComponent<AudioSource>();
            
            if(collision.gameObject.name == "Paddle Left") {
                lasthit = 1;
            } else {
                lasthit = 2;
            }
            Vector3 direction = new Vector3(0, 0, 0);
            //Debug.Log("Paddle and Ball Collision Detected");
            //Vector3 newDirection = Vector3.Cross(collision.rigidbody.velocity, this.GetComponent<Rigidbody>().velocity);
            ContactPoint contactpoint = collision.GetContact(0);
            if(contactpoint.point.z > collision.transform.position.z) {
                direction = new Vector3(0, 0, 1);
                audioSource.clip = paddleSound1;
            } else {
                direction = new Vector3(0, 0, -1);
                audioSource.clip = paddleSound2;
            }
            
            Rigidbody ball = this.GetComponent<Rigidbody>();
            ball.AddForce(ball.velocity / 5, ForceMode.VelocityChange);
            ball.AddForce(direction * accel, ForceMode.Force);

            audioSource.Play();
        } else if(collision.gameObject.tag == "Wall") {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = wallSound;
            audioSource.Play();
        }
    }
}
