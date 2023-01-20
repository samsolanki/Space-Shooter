using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    //CURRENT INDEX OF PLAYER
    [SerializeField] private int currentPlayerLevel = 0;
    [SerializeField] private bool isUnlocked = false;
    public int initialPrice;
    [SerializeField] private int[] upGradePrice;

    [SerializeField][Range(50f,500f)] private float[] playerHealth;
    [SerializeField] [Range(5f, 20f)] private float[] playerSpeed;
    [SerializeField] [Range(50f, 500f)] private float[] playerDamage;
    [SerializeField] [Range(0.05f, 5f)] private float[] playerFirerate;
    

    //GETTING PLAYER HEALTH LEVEL VIA
    public float CurrentPlayerHealth()
    {
        return playerHealth[currentPlayerLevel];
    }

    //GETTING PLAYER SPEED LEVEL VIA
    public float CurrentPlayerSpeed()
    {
        return playerSpeed[currentPlayerLevel];
    }

    //GETTING PLAYER DAMAGE LEVEL VIA
    public float CurrentPlayerDamage()
    {
        return playerDamage[currentPlayerLevel];
    }

    //GETTING PLAYER FIRERATE LEVEL VIA
    public float CurrentPlayerFireRate()
    {
        return playerFirerate[currentPlayerLevel];
    }

    public bool GetUnlockState()
    {
        return isUnlocked;
    }

    public void SetUnlockState(bool isUnlocked)
    {
        this.isUnlocked = isUnlocked;
    }


    public int GetCurrentLevelOfPlayer()
    {
        return currentPlayerLevel;
    }

    public void SetCurrentLevelOfPlayer(int index)
    {
        currentPlayerLevel = index;
    }


    public int PlayerBuyPrice()
    {   //IF PLAYER IS UNLOCKED SHOW LEVEL VIA PRICE ELSE BASE PRICE
        if (isUnlocked)
            return upGradePrice[currentPlayerLevel];

        return initialPrice;
    }


    public void SetPlayerLevelUp(GameObject gameObject)
    {
        currentPlayerLevel++;
        if (currentPlayerLevel == playerHealth.Length - 1)
            gameObject.SetActive(false);
    }
}
