using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private Slider healthBar;
    [SerializeField] private float health;

    [HideInInspector]
    public bool isPlayerDie;
    private PlayerAnimationContrallor _anim;

    private bool isPlayerHasShield;
    public bool GetIsPlayerHasShield()
    {
        return isPlayerHasShield;
    }
    public void SetIsPlayerHasShield(bool isHas)
    {
        isPlayerHasShield = isHas;
    }

    private void OnEnable()
    {
       
    }

    private void Awake()
    {
        _anim = GetComponent<PlayerAnimationContrallor>();
       
    }

    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        health = PlayerManager.instance.SetHealth();

        healthBar.value = health;
       // print("health " + health);
    }

    public void ApplyDamage(int amount)
    {
        if(isPlayerHasShield == false)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            ApplyDamage(collision.transform.GetComponent<EnemyBullet>().damage);
        }
    }

}
