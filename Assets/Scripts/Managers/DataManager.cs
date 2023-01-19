using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private PlayerPrefsData playerPrefsData = new PlayerPrefsData();


    public PlayerDataManager[] playerData;
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
        if (PlayerPrefs.HasKey(playerPrefsData.KEY_TOTAL_COINS))
        {
            GetPlayerData();
        }
        else
        {
            FirstTimeGameStarted();
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

        PlayerPrefs.SetInt(playerPrefsData.KEY_TOTAL_COINS, totalCoin);
        PlayerPrefs.SetInt(playerPrefsData.KEY_SELECTED_PLAYER_INDEX, currentPlayerIndex);
    }

    public void GetPlayerData()
    {

        PlayerPrefs.GetInt(playerPrefsData.KEY_TOTAL_COINS);
        PlayerPrefs.GetInt(playerPrefsData.KEY_SELECTED_PLAYER_INDEX);

        for(int i=0; i < playerData.Length; i++)
        {
            //GET PALYER INDEX AND SET TO PLAYER DATA
            playerData[i].SetCurrentLevelOfPlayer(PlayerPrefs.GetInt(playerPrefsData.KEY_CURRENT_PLAYER_LEVEL + i));

            //CHECK PLAYER IS UNLOCKED OR NOT
            if(PlayerPrefs.GetInt(playerPrefsData.KEY_UNLOCK_PLAYER + i) == 0)
            
                playerData[i].SetUnlockState(false);
            else
                playerData[i].SetUnlockState(true);
        }
    }

    public void SetCurrentPlayerLevel(int index , int value)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_CURRENT_PLAYER_LEVEL + index, value);
    }

    public void SetCurrentPlayerIndex(int index)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_SELECTED_PLAYER_INDEX, index);
    }

    public void CurrentsPlayerUnlockState(int index)
    {
        PlayerPrefs.SetInt(playerPrefsData.KEY_UNLOCK_PLAYER + index, 1);
    }


    //COIN 
    public void AddCoin(int addAmount)
    {
        totalCoin += addAmount;
        PlayerPrefs.SetInt(playerPrefsData.KEY_TOTAL_COINS, totalCoin);
    }

    public void SubstractCoin(int substractAmount)
    {
        totalCoin -= substractAmount;
        PlayerPrefs.SetInt(playerPrefsData.KEY_TOTAL_COINS, totalCoin);
    }
}
