using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int health = 100;

    [HideInInspector]
    public bool isPlayerDie;
    private PlayerAnimationContrallor _anim;

    private void Awake()
    {
        _anim = GetComponent<PlayerAnimationContrallor>();

        healthBar.value = health;
    }

    public void ApplyDamage(int amount)
    {
        health -= amount;
        healthBar.value = health;
        if (health <= 0)
        {
            isPlayerDie = true;
            _anim.DeadAnim();
            Destroy(gameObject, 1);
            UIManager.instance.Gameover();
        }
        else
        {
            _anim.Hit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            ApplyDamage(collision.transform.GetComponent<EnemyBullet>().damage);
        }
    }

}
