using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    [SerializeField] private PowerUpDataManager[] powerUpData;
    [SerializeField] private GameObject[] powerUpPrefabs;
    [SerializeField] private int currentPowerUpIndex;

    private GameObject powerUp;
    private float damage;
    private float firerate;
    private float time;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public int GetCurrentPowerUpIndex()
    {
        return currentPowerUpIndex;
    }

    public void SetCurrentPowerUpIndex(int index)
    {
        currentPowerUpIndex = index;
    }

    public float SetPowerUpDamage()
    {
        damage = powerUpData[currentPowerUpIndex].CurrentPowerUpDamage();
        return damage;
    }

    public float SetPowerUpFirerate()
    {
        firerate = powerUpData[currentPowerUpIndex].CurrentPowerUpFirerate();
        return firerate;
    }

    public float SetPowerUpTime()
    {
        time = powerUpData[currentPowerUpIndex].CurrentPowerUpTime();
        return time;
    }
}
