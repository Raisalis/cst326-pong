using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    int counter;
    bool counting;

    public GameObject paddle1;
    public GameObject paddle2;
    Transform player1;
    Transform player2;

    public GameObject powerUp1Prefab;
    public GameObject powerUp2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        counting = false;
        player1 = paddle1.GetComponent<Transform>();
        player2 = paddle2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) {
            GameObject instance1 = Instantiate(powerUp1Prefab);
            GameObject instance2 = Instantiate(powerUp2Prefab);
            instance1.transform.position = new Vector3(0, 0, 5);
            instance2.transform.position = new Vector3(0, 0, -5);
            instance1.GetComponent<PowerUp1>().manager = this;
            instance2.GetComponent<PowerUp2>().manager = this;
        }
    }

    void FixedUpdate() {
        if(counting) {
            counter++;
            if(counter == 100) {
                player1.localScale = new Vector3(1, 0.4f, 3f);
                player2.localScale = new Vector3(1, 0.4f, 3f);
                counting = false;
                counter = 0;
            }
        }
    }

    // Double the speed of the ball
    public void ballSpeed(Collider collision) {
        Rigidbody ball = collision.attachedRigidbody;
        ball.velocity *= 2;
    }

    // Increase the size of the paddles
    public void paddleSize(int playernum) {
        if(playernum == 1) {
            player1.localScale = new Vector3(1, 0.4f, 6f);
            player2.localScale = new Vector3(1, 0.4f, 1.5f);
        } else {
            player1.localScale = new Vector3(1, 0.4f, 1.5f);
            player2.localScale = new Vector3(1, 0.4f, 6f);
        }
        counting = true;
    }
}
