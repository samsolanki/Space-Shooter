using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefab;


    [Header("Setting")]
    [SerializeField] private float fireRate = 1;
    [SerializeField] private float bulletForce = 20;
    [SerializeField] private float damage = 10;
    [SerializeField] private float powerUpTimer = 5;

    
    [SerializeField] private Sprite defaultBullet;

    [Header("Green Missile")]
    [SerializeField] private Sprite greenBullet;
    [SerializeField] private float greenMissileDamage;
    [SerializeField] private float greenMissileFirerate;

    [Header("Purple Missile")] 
    [SerializeField] private Sprite purpleBullet;
    [SerializeField] private float purpleMissileDamage;
    [SerializeField] private float purpleMissileFirerate;

    [Header("Brown Missile")]
    [SerializeField] private Sprite brownBullet;
    [SerializeField] private float brownMissileDamage;
    [SerializeField] private float brownMissileFirerate;

    [Header("Sliver Missile")]
    [SerializeField] private Sprite yellowBullet;
    [SerializeField] private float yellowMissileDamage;
    [SerializeField] private float yellowMissileFirerate;

    [Header("Red Missile")]
    [SerializeField] private Sprite redBullet;
    [SerializeField] private float redMissileDamage;
    [SerializeField] private float redMissileFirerate;
    
    

    [Header("Blue Missile")]
    [SerializeField] private Sprite blueBullet;
    [SerializeField] private float blueMissileDamage;
    [SerializeField] private float blueMissileFirerate;


    private PowerUpPrefab powerUp = new PowerUpPrefab();
    private float coolDownTime = 1;
    private float defaultFirerate;
    private float defaultDamage;

    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab.GetComponent<SpriteRenderer>().sprite = defaultBullet;
        defaultDamage = damage;
        defaultFirerate = fireRate;
    }

    private void Update()
    {
        coolDownTime -= Time.deltaTime;
        if(coolDownTime <= 0)
        {
            coolDownTime = fireRate;
            Shoot();
        }
    }


    private void  Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity) as GameObject;
        Rigidbody2D bulletBody = bullet.transform.GetComponent<Rigidbody2D>();
        bulletBody.velocity = new Vector2(bulletForce, bulletBody.velocity.y);
        Destroy(bullet , 3);
    }



    IEnumerator PowerUp(Sprite bulletSprite , float damage,float fireRate)
    {
        bulletPrefab.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        this.damage = damage;
        this.fireRate = fireRate;
        yield return new WaitForSeconds(powerUpTimer);
        bulletPrefab.GetComponent<SpriteRenderer>().sprite = defaultBullet;
        this.fireRate = defaultFirerate;
        this.damage = defaultDamage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Green Missile")
        {
            StartCoroutine(PowerUp(greenBullet , greenMissileDamage , greenMissileFirerate));
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Brown Missile")
        {
            StartCoroutine(PowerUp(brownBullet, brownMissileDamage, brownMissileFirerate));
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Yellow Missile")
        {
            StartCoroutine(PowerUp(yellowBullet, yellowMissileDamage, yellowMissileFirerate));
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Purple Missile")
        {
            StartCoroutine(PowerUp(purpleBullet, purpleMissileDamage, purpleMissileFirerate));
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Blue Missile")
        {
            StartCoroutine(PowerUp(blueBullet, blueMissileDamage, blueMissileFirerate));
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Red Missile")
        {
            StartCoroutine(PowerUp(redBullet, redMissileDamage, redMissileFirerate));
            Destroy(collision.gameObject);
        }
    }
}
