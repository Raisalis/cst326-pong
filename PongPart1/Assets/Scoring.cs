using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    int player1Score;
    int player2Score;

    public TextMeshProUGUI scoreText;
    public GameObject ballPrefab;
    public float speed;
    public Material player1mat;
    public Material player2mat;
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject textObject;
    public AudioClip scoreSound;

    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
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
                player2Score++;
                scoreText = textObject.GetComponent<TextMeshProUGUI>();
                scoreText.text = $"{player2Score} - {player1Score}";
                if(player2Score == 11) {
                    Debug.Log("Game Over! Player 2 Wins! Final Score:\nPlayer1: " + player1Score + " | Player2: " + player2Score);
                    player1Score = 0;
                    player2Score = 0;
                } else {
                    Debug.Log("Player 2 Scored! Current Score:\nPlayer1: " + player1Score + " | Player2: " + player2Score);
                    Destroy(collision.gameObject);
                    GameObject instance = Instantiate(ballPrefab);
                    var renderer = instance.GetComponent<MeshRenderer>();
                    var renderertop = topWall.GetComponent<MeshRenderer>();
                    var rendererbottom = bottomWall.GetComponent<MeshRenderer>();
                    renderer.material = player2mat;
                    renderertop.material = player2mat;
                    rendererbottom.material = player2mat;
                    instance.transform.position = Vector3.zero;
                }
            }

            else {
                player1Score++;
                scoreText = textObject.GetComponent<TextMeshProUGUI>();
                scoreText.text = $"{player2Score} - {player1Score}";
                if(player1Score == 11) {
                    Debug.Log("Game Over! Player 1 Wins! Final Score:\nPlayer1: " + player1Score + " | Player2: " + player2Score);
                    player1Score = 0;
                    player2Score = 0;
                } else {
                    Debug.Log("Player 1 Scored! Current Score:\nPlayer1: " + player1Score + " | Player2: " + player2Score);
                    Destroy(collision.gameObject);
                    GameObject instance = Instantiate(ballPrefab);
                    var renderer = instance.GetComponent<MeshRenderer>();
                    var renderertop = topWall.GetComponent<MeshRenderer>();
                    var rendererbottom = bottomWall.GetComponent<MeshRenderer>();
                    renderer.material = player1mat;
                    renderertop.material = player1mat;
                    rendererbottom.material = player1mat;
                    instance.transform.position = Vector3.zero;
                }
            }
        }
    }
}
