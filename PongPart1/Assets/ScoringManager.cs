using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringManager : MonoBehaviour
{
    int player1score;
    int player2score;
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
        player1score = 0;
        player2score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to increments score of the player who scored.
    public void onScore(int playernum, Collider collision) {
        if(playernum == 1) {
            player1score++;
            Debug.Log("Player 1 Scored! Current Score:\nPlayer1: " + player1score + " | Player2: " + player2score);
            scoreText = textObject.GetComponent<TextMeshProUGUI>();
            scoreText.text = $"{player1score} - {player2score}";
        } else {
            player2score++;
            Debug.Log("Player 2 Scored! Current Score:\nPlayer1: " + player1score + " | Player2: " + player2score);
            scoreText = textObject.GetComponent<TextMeshProUGUI>();
            scoreText.text = $"{player1score} - {player2score}";
        }
        checkWin(playernum, collision);
    }

    // Checks if a player won the game. If not, spawns another ball.
    void checkWin(int playernum, Collider collision) {
        if(player1score == 11) {
            Debug.Log("Game Over! Player 1 Wins! Final Score:\nPlayer1: " + player1score + " | Player2: " + player2score);
        } else if(player2score == 11) {
            Debug.Log("Game Over! Player 2 Wins! Final Score:\nPlayer1: " + player1score + " | Player2: " + player2score);
        } else {
            Destroy(collision.gameObject);
            GameObject instance = Instantiate(ballPrefab);
            changeMats(playernum, instance);
        }
    }

    // Changes the materials of the game when a player scores.
    void changeMats(int playernum, GameObject instance) {
        if(playernum == 2) {
            var renderer = instance.GetComponent<MeshRenderer>();
            var renderertop = topWall.GetComponent<MeshRenderer>();
            var rendererbottom = bottomWall.GetComponent<MeshRenderer>();
            renderer.material = player2mat;
            renderertop.material = player2mat;
            rendererbottom.material = player2mat;
            instance.transform.position = Vector3.zero;
        } else {
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
