using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Meteor,
    IdelEnemy,
    MovingEnemy
}

public class EnemyContrallor : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private int damage = 50;
    [SerializeField] private float health = 100;
    [SerializeField] private int score;

    private bool isDead;
    private bool isMoveing;

    private Animator _anim;

    // Start is called before the first frame update
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    

    private void FixedUpdate()
    {
        if (enemyType == EnemyType.Meteor || enemyType == EnemyType.MovingEnemy)
        {
            isMoveing = true;
            MoveEnemy();
            _anim.SetBool("Move", isMoveing);
        }

        if (enemyType == EnemyType.IdelEnemy)
        {
            
            if(transform.position.x <= 8f)
            {
                isMoveing = false;
                moveSpeed = 0;
                transform.position = new Vector3(7, transform.position.y, transform.position.z);
            }
            else
            {
                isMoveing = true;
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
        }
    }

    private void MoveEnemy()
    {
        if (isDead)
            moveSpeed = 0;

        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            isMoveing = false;
            isDead = true;
            ScoreManager.instance.AddScore(score);
            _anim.SetTrigger("Die");
            Destroy(collision.gameObject);
            Destroy(gameObject,1);
        }

        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            collision.transform.GetComponent<PlayerHealth>().ApplyDamage(damage);
        }
    }
}
