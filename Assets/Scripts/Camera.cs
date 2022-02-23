using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float initialPosY;

    // Start is called before the first frame update
    void Start()
    {
        initialPosY = transform.position.y;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, initialPosY, transform.position.z); // move the camera towards the player and the Y pos will be always the same (the initial)
    }
}
