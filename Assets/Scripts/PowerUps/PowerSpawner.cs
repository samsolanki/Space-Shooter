using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PowerUpPrefab
{
    public string name;
    public PowerUpDataManager prefabs;
    public bool isPowerUnlocked;
    [Range(0f,100f)]public double chance = 100;
    [HideInInspector]public double weight;
} 

public class PowerSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 20;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private PowerUpDataManager[] powerUpData;
    [SerializeField] private float probalityOfMissile1 = 100;
    [SerializeField] private float probalityOfMissile2 = 80;
    [SerializeField] private float probalityOfMissile3 = 60;
    [SerializeField] private float probalityOfMissile4 = 50;
    [SerializeField] private float probalityOfMissile5 = 30;
    [SerializeField] private float probalityOfMissile6 = 50;
    [SerializeField] private float probalityOfMissile7 = 70;
    [SerializeField] private float probalityOfMissile8 = 100;
   
   
    private float defaultSpawnTime = 5;
    


    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.GetIsPlayerAlive() == false)
            return;

        defaultSpawnTime -= Time.deltaTime;
       
        if (defaultSpawnTime <= 0) {
            SpawnPowerUps();
            defaultSpawnTime = spawnRate;
        }

    }


    public void SpawnPowerUps()
    {
        for (int i = 0; i < powerUpData.Length; i++)
        {
            if (powerUpData[i].GetPowerUpUnlockState())
            {
                if (i == 0)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile1)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 1 )
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile2)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 2)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile3)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 3)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile4)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 4)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile5)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 5)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile6)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 6)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile7)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                else if (i == 7)
                {
                    int randomValue = Random.Range(0, 100);
                    if (randomValue <= probalityOfMissile8)
                    {
                        Instantiate(powerUps[i], new Vector3(transform.position.x, Random.Range(-4, 4)), Quaternion.identity);
                    }
                }
                
            }
        }
    }
   
}
