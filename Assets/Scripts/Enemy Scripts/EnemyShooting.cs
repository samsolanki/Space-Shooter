using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;

    [Header("Setting")]
    [SerializeField] private float fireRate = 1;
    [SerializeField] private float bulletForce = 30;
    public int damage = 50;

    private bool shooting;
    private float coolDownTime = 1;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
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

    private void Shoot()
    {
        anim.SetTrigger("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity) as GameObject;
        bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
        Destroy(bullet, 3);
    }
}
