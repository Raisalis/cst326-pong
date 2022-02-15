using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float speed = 5f;
    Rigidbody paddlebody;

    bool player1Down;
    bool player1Held;
    bool player1Up;
    bool player2Down;
    bool player2Held;
    bool player2Up;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        player1Down = Input.GetButtonDown("Player1Buttons");
        player1Held = Input.GetButton("Player1Buttons");
        player1Up = Input.GetButtonUp("Player1Buttons");
        player2Down = Input.GetButtonDown("Player2Buttons");
        player2Held = Input.GetButton("Player2Buttons");
        player2Up = Input.GetButtonUp("Player2Buttons");
    }

    void FixedUpdate()
    {
        float translation1 = Input.GetAxisRaw("Player1Buttons") * speed * Time.deltaTime;
        float translation2 = Input.GetAxisRaw("Player2Buttons") * speed * Time.deltaTime;

        if(this.name == "Paddle Left") {
            paddlebody = this.GetComponent<Rigidbody>();
            if(player1Down) {
                //Debug.Log("Player 1 Buttons Pressed.");
                //this.transform.Translate(0, 0, translation1);
                paddlebody.velocity = new Vector3(0, 0, translation1);
            }

            if(player1Held) {
                //Debug.Log("Player 1 Buttons Held.");
                paddlebody.AddForce(0, 0, translation1, ForceMode.VelocityChange);
            }

            else {
                paddlebody.velocity = new Vector3(0,0,0);
            }

        }

        if(this.name == "Paddle Right") {
            paddlebody = this.GetComponent<Rigidbody>();
            if(player2Down) {
                //Debug.Log("Player 2 Buttons Pressed.");
                paddlebody.velocity = new Vector3(0, 0, translation2);
            }

            if(player2Held) {
                //Debug.Log("Player 2 Buttons Held.");
                paddlebody.AddForce(0, 0, translation2, ForceMode.VelocityChange);
            }

            else {
                paddlebody.velocity = new Vector3(0,0,0);
            }
        }

        
    }

}
