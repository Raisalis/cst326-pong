using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    public PowerUpsManager manager;
    Transform pos;
    int counter;
    bool up;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        up = true;
        pos = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(up) {
            pos.position += new Vector3 (0, 0, 2 * Time.deltaTime);
            counter++;
            if(counter == 90) {
                up = false;
            }
        } else {
            pos.position -= new Vector3 (0, 0, 2 * Time.deltaTime);
            counter--;
            if(counter == -90) {
                up = true;
            }
        }
    }

    void OnTriggerEnter(Collider collision) {
        if(collision.tag == "Ball") {
            manager.ballSpeed(collision);
            Destroy(this.gameObject);
        }
    }
}
