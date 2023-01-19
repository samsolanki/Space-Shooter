using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] PlayerDataManager[] playerData;
    [SerializeField] GameObject[] playerPrefabs;

    public int currentPlayerIndex;

    private GameObject player;
    private float health;
    private float damage;
    private float speed;
    private float firerate;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        currentPlayerIndex = PlayerPrefs.GetInt("SelectedPlayerIndex", 0);
    }


    public int GetPlayerCurrentIndex()
    {
        return currentPlayerIndex;
    }

    public void SetCurrentPlayerIndex(int index)
    {
        currentPlayerIndex = index;
    }

    public void StartGame()
    {
        InstantiatePlayer();
    }

    public void InstantiatePlayer()
    {
        player = Instantiate(playerPrefabs[0], transform.position, Quaternion.identity) as GameObject;
        player.transform.position = new Vector3(-5, 0, 0);
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    //GETTING SETTING METHODD OF PROPERTY TO SET FOR PLAYER

    public float SetHealth()
    {
        health = playerData[currentPlayerIndex].CurrentPlayerHealth();
        return health;
    }

    public float SetSpeed()
    {
        speed = playerData[currentPlayerIndex].CurrentPlayerSpeed();
        return speed;
    }
    public float SetDamage()
    {
        damage = playerData[currentPlayerIndex].CurrentPlayerDamage();
        print("Damage :" + damage);
        return damage;
    }

    public float SetFirerate()
    {
        firerate = playerData[currentPlayerIndex].CurrentPlayerFireRate();
        return firerate;
    }

}
