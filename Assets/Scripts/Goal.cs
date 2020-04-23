using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Goal : NetworkBehaviour
{
    public int score;
    public Text scoreText;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
}