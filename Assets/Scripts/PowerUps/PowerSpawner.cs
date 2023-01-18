using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpPrefab
{
    public string name;
    public GameObject prefabs;
    [Range(0f,100f)]public double chance = 100;
    [HideInInspector]public double weight;
} 

public class PowerSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 20;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private PowerUpPrefab[] powerUps;
   
    private float defaultSpawnTime = 5;

    private double accumlatedWeight;
    private System.Random random = new System.Random();

    private void Awake()
    {
        CalculateWeight();
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        defaultSpawnTime -= Time.deltaTime;
       
        if (defaultSpawnTime <= 0) {
            //SpawnPower();
            PowerUpSpawner(new Vector2(transform.position.x, Random.Range(-4, 4)));
            defaultSpawnTime = spawnRate;
        }

    }


    private void PowerUpSpawner(Vector2 position)
    {
        PowerUpPrefab randomPowerUp = powerUps[GetRandomIndex()];
        Instantiate(randomPowerUp.prefabs, position, Quaternion.identity);

        Debug.Log("Power up name " + randomPowerUp.name + " Change " + randomPowerUp.chance);
    }


    private int GetRandomIndex()
    {
        double r = random.NextDouble() * accumlatedWeight;
        for(int i = 0; i <= powerUps.Length; i++)
        {
            if(powerUps[i].weight >= r)
            {
                return i;
            }
        }

        return 0;
    }

    private void CalculateWeight()
    {
        accumlatedWeight = 0;
        foreach(PowerUpPrefab powerUp in powerUps)
        {
            accumlatedWeight += powerUp.chance;
            powerUp.weight = accumlatedWeight;
        }
    }

}
