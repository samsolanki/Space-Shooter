using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private PlayerPrefsData playerPrefsData = new PlayerPrefsData();


    public PlayerDataManager[] playerData;
    public PowerUpDataManager[] powerUpData;
    public int totalCoin;
    public int currentPlayerLevel;
    public int currentPlayerIndex;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        Debug.Log("Daata Manager is Loaded");
        if (PlayerPrefs.HasKey(playerPrefsData.KEY_TOTAL_COINS))
        {
            GetPlayerData();
            GetPowerUpData();
            print("Game Already Loaded");
        }
        else
        {
            FirstTimeGameStarted();
            print("FirstTime Game Load");
        }
    }

    public void FirstTimeGameStarted()
    {
        for (int i = 0; i < playerData.Length; i++) {
            PlayerPrefs.SetInt(playerPrefsData.KEY_CURRENT_PLAYER_LEVEL + i, 0);

            if (playerData[i].GetUnlockState())
            {
                PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_PLAYER + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_PLAYER + i, 0);
            }
        }

        for(int i = 0; i < powerUpData.Length; i++)
        {
            PlayerPrefs.SetInt(playerPrefsData.KEY_CURRENT_POWERUP_LEVEL + i, 0);

            if (powerUpData[i].GetPowerUpUnlockState())
            {
                PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_POWERUP + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_POWERUP + i, 0);
            }
        }
        Debug.Log("First Time Load");
        PlayerPrefs.SetInt(playerPrefsData.KEY_TOTAL_COINS, totalCoin);
        PlayerPrefs.SetInt(playerPrefsData.KEY_SELECTED_PLAYER_INDEX, currentPlayerIndex);
    }

    public void GetPlayerData()
    {
        Debug.Log("Already Loaded");
        PlayerPrefs.GetInt(playerPrefsData.KEY_TOTAL_COINS);
        CoinUI.instance.CalcCoin();
        PlayerPrefs.GetInt(playerPrefsData.KEY_SELECTED_PLAYER_INDEX);

        for(int i=0; i < playerData.Length; i++)
        {
            //GET PALYER INDEX AND SET TO PLAYER DATA
            playerData[i].SetCurrentLevelOfPlayer(PlayerPrefs.GetInt(playerPrefsData.KEY_CURRENT_PLAYER_LEVEL + i));

            //CHECK PLAYER IS UNLOCKED OR NOT
            if(PlayerPrefs.GetInt(playerPrefsData.KEY_UNLOCK_PLAYER + i) == 0)
            {
                playerData[i].SetUnlockState(false);
            }
            else
            {
                playerData[i].SetUnlockState(true);
            }
        }

        
    }

    public void GetPowerUpData()
    {
        for (int i = 0; i < powerUpData.Length; i++)
        {
            //POWER UPN DAYA AND SET TO PLAYER DATA
            powerUpData[i].SetCurrentPowerUpLevel(PlayerPrefs.GetInt(playerPrefsData.KEY_CURRENT_POWERUP_LEVEL + i));

            //CHECK IS PLAYER IS UNCLOCKED
            if (PlayerPrefs.GetInt(playerPrefsData.KEY_UNLOCK_POWERUP + i) == 0)
            {
                Debug.Log(PlayerPrefs.GetInt(playerPrefsData.KEY_UNLOCK_POWERUP + i));
                powerUpData[i].SetPowerUpUnlockState(false);
            }
            else
            {
                powerUpData[i].SetPowerUpUnlockState(true);
            }
        }
    }

    public void SetCurrentPlayerLevel(int index , int value)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_CURRENT_PLAYER_LEVEL + index, value);
    }

    public void SetPowerUpLevel(int index , int value)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_CURRENT_POWERUP_LEVEL + index, value);
    }

    public void SetCurrentPlayerIndex(int index)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_SELECTED_PLAYER_INDEX, index);
    }

    public void CurrentsPlayerUnlockState(int index)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_PLAYER + index, 1);
    }

    public void PowerUpUnlockState(int index)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_POWERUP + index, 1);
    }


    //COIN 
    public void AddCoin(int addAmount)
    {
        totalCoin += addAmount;
        CoinUI.instance.CalcCoin();
        PlayerPrefs.SetInt(playerPrefsData.KEY_TOTAL_COINS, totalCoin);
    }

    public void SubstractCoin(int substractAmount)
    {
        totalCoin -= substractAmount;
        CoinUI.instance.CalcCoin();
        PlayerPrefs.SetInt(playerPrefsData.KEY_TOTAL_COINS, totalCoin);

    }
}
