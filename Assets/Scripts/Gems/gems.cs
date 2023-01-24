using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gems : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private int gamesValue = 1;


    public int GetGamesValue()
    {
        return gamesValue;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.instance.SetGemsText(gamesValue);
        }
    }

}
