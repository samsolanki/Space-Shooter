using System.Collections;
using System.Collections.Generic;
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
    [SerializeField][Range(0f,100f)] private float[] chance;
    [HideInInspector] public float[] weight;

   
    private float defaultSpawnTime = 5;

    private float accumlatedWeight;
    private System.Random random = new System.Random();

    private void Awake()
    {
        //CalculateWeight();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.GetIsPlayerAlive() == false)
            return;

        defaultSpawnTime -= Time.deltaTime;
       
        if (defaultSpawnTime <= 0) {
            //SpawnPower();
            PowerUpSpawner(new Vector2(transform.position.x, Random.Range(-4, 4)));
            defaultSpawnTime = spawnRate;
        }

    }


    private void PowerUpSpawner(Vector2 position)
    {
        for(int i = 0; i < powerUpData.Length; i++)
        {
            if (powerUpData[i].GetPowerUpUnlockState())
            {
                GameObject randomSpawn = powerUps[GetRandomIndex()];
                Instantiate(randomSpawn, position, Quaternion.identity);
            }
        }

        /*

        for(int i=0; i < powerUpData.Length; i++)
        {
            if (powerUpData[i].GetPowerUpUnlockState())
            {
                PowerUpPrefab randomPowerUp = powerUps[GetRandomIndex()];
                Instantiate(powe, position, Quaternion.identity);
            }
        }

        */
    }
   
   
    private int GetRandomIndex()
    {
       
            float r = random.Next() * accumlatedWeight;
            for (int i = 0; i <= weight.Length; i++)
            {
                if (weight[i] >= r)
                {
                    return i;
                }
            }
       
        return 0;
    }
    private void CalculateWeight()
    {
        /*
        accumlatedWeight = 0;
        foreach(PowerUpPrefab powerUp in powerUps)
        {
            accumlatedWeight += powerUp.chance;
            powerUp.weight = accumlatedWeight;
        }

        
        for(int i = 0; i < powerUps.Length; i++)
        {
            accumlatedWeight[i] += chance[i];
            weight[i] = accumlatedWeight[i];
        }

        */
    }
   
}
