using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        transform.parent.transform.parent.GetComponent<PipesHandler>().PushPipe(); // when a pipe is not visible, we get the parent of the parent (first it will get PipesContainer and then the parent of it which is the PipesHandler) and call a function
    }
}
