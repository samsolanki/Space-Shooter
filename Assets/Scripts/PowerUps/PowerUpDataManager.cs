using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDataManager : MonoBehaviour
{

    [SerializeField] private int currentPowerUpLevel;
    [SerializeField] private bool isPowerUpUnlocked = false;
    [SerializeField] private int initialPowerUpPrice;

    [SerializeField] private int[] upgradePrice;
    [SerializeField] [Range(5f, 20f)] private float[] powerUpDamage;
    [SerializeField] [Range(0.05f, 5f)] private float[] powerUpFirerate;
    [SerializeField] [Range(1f, 10f)] private float[] powerUpTime;

    //GET POWER UP DAMAGE LEVEL VIA
    public float CurrentPowerUpDamage()
    {
        return powerUpDamage[currentPowerUpLevel];
    }

    //GET POWER UP FIRERATE LEVEL VIA
    public float CurrentPowerUpFirerate()
    {
        return powerUpFirerate[currentPowerUpLevel];
    }

    //GET POWER UP SPEED LEVEL VIA
    public float CurrentPowerUpTime()
    {
        return powerUpTime[currentPowerUpLevel];
    }


    //Get LOCK STATE
    public bool GetPowerUpUnlockState()
    {
        //Debug.Log("is power pu unlock :" + isPowerUpUnlocked);
        return isPowerUpUnlocked;
    }

    public void SetPowerUpUnlockState(bool isPowerUpUnlocked)
    {
        this.isPowerUpUnlocked = isPowerUpUnlocked;
    }

    public int GetCurrentPowerUpLevel()
    {
        return currentPowerUpLevel;
    }

    public void SetCurrentPowerUpLevel(int powerUpLevel)
    {
        this.currentPowerUpLevel = powerUpLevel;
    }

    public int BuyPowerUp()
    {
        if (isPowerUpUnlocked)
            return upgradePrice[currentPowerUpLevel];

        return initialPowerUpPrice;
    }

    public void SetPowerUpLevel(GameObject gameObject)
    {
        currentPowerUpLevel++;
        if (currentPowerUpLevel == powerUpDamage.Length - 1)
            gameObject.SetActive(false);
    }

}
