using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject scoreLabel;
    public GameObject SFX;
    public GameObject gameOver;
    public GameObject background;
    public Player player;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored() 
    {
        PlaySFX(2);
        score += 1;

        if (score%10 == 0 && player.xVelocity < player.maxVelocity) // every 10 pipes passed and if the player velocity is < that the max velocity (so that we have a limit velocity)
        {
            player.xVelocity += player.velocityIncrementer;
        }

        UpdateScoreLabelText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreLabelText();
    }

    public void UpdateScoreLabelText()
    {
        scoreLabel.GetComponent<Text>().text = score.ToString();
    }

    public void PlaySFX(int num)
    {
        SFX.GetComponent<SFX>().play(num);
    }

    public void GameOver() 
    {
        background.GetComponent<Background>().enabled = false; // disable background scroll
        gameOver.SetActive(true); // show the game over message
    }
}
