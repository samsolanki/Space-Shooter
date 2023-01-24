using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerUpEnum
{
    Missile,
    Shield
}

public class PowerUps : MonoBehaviour
{
    [SerializeField] private Sprite powerUpSprite;
    [SerializeField] private float powerUpDamage;
    [SerializeField] private float time;


    private void Awake()
    {
        powerUpDamage = PowerUpManager.instance.SetPowerUpDamage();
        time = PowerUpManager.instance.SetPowerUpTime();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime);
        time -= Time.deltaTime;
    }

    public void PowerUp()
    {

    }

    public void Shield()
    {

    }
}
