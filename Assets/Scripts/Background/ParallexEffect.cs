using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    private float length;
    private Vector3 startPos;
    public float parallaxFactor;

    void Start()
    {
        startPos.x = 13;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * parallaxFactor * Time.deltaTime);

        if (transform.position.x < -40)
            transform.position = new Vector3(startPos.x + length ,0,0);

    }
}
