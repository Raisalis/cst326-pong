using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public AudioClip scoreSound;
    public ScoringManager manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.name != "Top Wall" && collision.name != "Bottom Wall") {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = scoreSound;
            audioSource.Play();
            if(this.name == "End Left") {
                manager.onScore(2, collision);
            } else {
                manager.onScore(1, collision);
            }
        }
    }
}
