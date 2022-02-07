using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{

    public float speed = 20f;
    public float accel = .5f;
    public Transform[] spawnTransforms;

    // Start is called before the first frame update
    void Start()
    {
        Transform randomTransform = spawnTransforms[Random.Range(0, spawnTransforms.Length)];
        this.GetComponent<Rigidbody>().AddForce(randomTransform.right * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Paddle") {
            Vector3 direction = new Vector3(0, 0, 0);
            //Debug.Log("Paddle and Ball Collision Detected");
            //Vector3 newDirection = Vector3.Cross(collision.rigidbody.velocity, this.GetComponent<Rigidbody>().velocity);
            ContactPoint contactpoint = collision.GetContact(0);
            if(contactpoint.point.x > collision.transform.position.x) {
                direction = new Vector3(0, 0, 1);
            } else {
                direction = new Vector3(0, 0, -1);
            }
            
            Rigidbody ball = this.GetComponent<Rigidbody>();
            ball.AddForce(ball.velocity / 5, ForceMode.VelocityChange);
            ball.AddForce(direction * accel, ForceMode.Force);
        }
    }
}
