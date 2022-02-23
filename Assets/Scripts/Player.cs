using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float xVelocity;
    public float velocityIncrementer;
    public float maxVelocity;
    public GameHandler gameHandler;
    public GameObject min;
    public GameObject max;

    private bool alive = true;
    private Rigidbody2D bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
        gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
        min = GameObject.Find("Min");
        max = GameObject.Find("Max");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && alive) // if we press the left click and we are alive
        {
            bird.velocity = new Vector2(0.0f, 1.0f); // apply a force to the Y axis
            GetComponent<Animator>().SetBool("fly", true); // change the bool of the animator so that we change the current animation to fly
            gameHandler.PlaySFX(4);
        }
    }

    void FixedUpdate()
    {
        bird.velocity = new Vector2(xVelocity , bird.velocity.y); // scroll the bird to the left
    }

    void LateUpdate()
    {
        CheckLimits();
    }

    void restore_idle()
    {
        GetComponent<Animator>().SetBool("fly", false); // disable the fly animation
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (alive) // if we collide and we are alive
        {
            Death();
        }
    }

    void CheckLimits() 
    {
        if (alive)
        {
            if (transform.position.y > max.transform.position.y)
            {
                Death();
            }
            else if(transform.position.y < min.transform.position.y)
            {
                Death();
            }
        }
    }

    public void Death() 
    {
        gameHandler.PlaySFX(1);
        xVelocity = 0.0f; // stop the bird from moving
        alive = false; // we are death
        gameHandler.GameOver(); // call GameOver function which will disable the background scroll and will show the game over text                 
    }
}