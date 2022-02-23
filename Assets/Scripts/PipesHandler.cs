using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesHandler : MonoBehaviour
{
    public float xOffset;
    public List<GameObject> pipesList;
    private float minPos = -0.486f;
    private float maxPos = 0.255f; 

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("PipeContainer"))
        {
            pipesList = new List<GameObject>(GameObject.FindGameObjectsWithTag("PipeContainer")); // store all the pipes in a list
            for (int i = 0; i < pipesList.Count; i++) // iterate all the pipes
            {
                pipesList[i].transform.position = new Vector2(pipesList[i].transform.position.x, Random.Range(minPos, maxPos)); // change the Y position in a range so that it wil increase the difficult
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushPipe()
    {
        pipesList[0].transform.position = new Vector2(pipesList[pipesList.Count - 1].transform.position.x + xOffset , Random.Range(minPos, maxPos)); // obtain the position off the first pipe and set the X position to the last pipe plus an offset (so that every pipe will be separated) and again a range for the Y position
        GameObject provPipe = pipesList[0]; // make a provisional reference to the first pipe
        pipesList.RemoveAt(0); // remove the first pipe
        pipesList.Insert(pipesList.Count, provPipe); // in the last position we will insert the first pipe
    }
}
