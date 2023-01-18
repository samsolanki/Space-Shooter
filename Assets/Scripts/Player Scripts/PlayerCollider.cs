using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Green Missile"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Purple Missile"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Yellow Missile"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Brown Missile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
