using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesContainer : MonoBehaviour
{
    GameHandler gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") // if we collide with the player
        {
            gameHandler.Scored();
        }
    }
}
