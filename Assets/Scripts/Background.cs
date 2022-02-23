using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollVelocity; 
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scroll = new Vector2(Mathf.Repeat(Time.time * scrollVelocity, 1), 0.0f); // loop the velocity to the right
        renderer.sharedMaterial.SetTextureOffset("_MainTex", scroll); // change the offset so that it will be moved
    }
}
