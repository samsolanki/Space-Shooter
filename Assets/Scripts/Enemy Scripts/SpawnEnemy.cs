using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{


    [Space]
    [Header("Setting")]
    [SerializeField] private float spawnRateLevel1 = 3;
    [SerializeField] private float spawnRateLevel2 = 2;
    [SerializeField] private float spawnRateLevel3 = 2;
    [SerializeField] private float spawnRateLevel4 = 2;
    [SerializeField] private float spawnRateLevel5 = 2;
    [SerializeField] private float spawnRateLevel6 = 2;
    [SerializeField] private float spawnRateLevel7 = 2;
    [SerializeField] private float spawnRateLevel8 = 2;
    [SerializeField] private float spawnRateLevel9 = 2;
    [SerializeField] private float spawnRateLevel10 = 2;



    [Header("Levels")]
    [SerializeField] private GameObject[] level1;
    [SerializeField] private GameObject[] level2;
    [SerializeField] private GameObject[] level3;
    [SerializeField] private GameObject[] level4;
    [SerializeField] private GameObject[] level5;
    [SerializeField] private GameObject[] level6;
    [SerializeField] private GameObject[] level7;
    [SerializeField] private GameObject[] level8;   
    [SerializeField] private GameObject[] level9;
    [SerializeField] private GameObject[] level10;

    private float defauleSpwanRate;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        defauleSpwanRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGamePlay == false)
            return;


        score = ScoreManager.instance.scoreCount;
        defauleSpwanRate -= Time.deltaTime;
        if(defauleSpwanRate <= 0 && score <= 100)
        {
            print("Method called");
            SpaenEnemy(level1);
            defauleSpwanRate = spawnRateLevel1;
        }if(defauleSpwanRate <= 0 && (score >= 100 && score <= 200))
        {
            print("Level 2 Loaded");
            SpaenEnemy(level2);
            defauleSpwanRate = spawnRateLevel2;
        }
         if (defauleSpwanRate <= 0 && (score >= 200 && score <= 400))
        {
            print("Level 3 Loaded");
            SpaenEnemy(level3);
            defauleSpwanRate = spawnRateLevel3;
        }
        if (defauleSpwanRate <= 0 && (score >= 400 && score <= 650))
        {
            print("Level 4 Loaded");
            SpaenEnemy(level4);
            defauleSpwanRate = spawnRateLevel4;
        }
        if (defauleSpwanRate <= 0 && (score >= 650 && score <= 900))
        {
            print("Level 5 Loaded");
            SpaenEnemy(level5);
            defauleSpwanRate = spawnRateLevel5;
        }
        if (defauleSpwanRate <= 0 && (score >= 900 && score <= 1100))
        {
            print("Level 6 Loaded");
            SpaenEnemy(level6);
            defauleSpwanRate = spawnRateLevel6;
        }
        if (defauleSpwanRate <= 0 && (score >= 1100 && score <= 1300))
        {
            print("Level 7 Loaded");
            SpaenEnemy(level7);
            defauleSpwanRate = spawnRateLevel7;
        }
        if (defauleSpwanRate <= 0 && (score >= 1300 && score <= 1500))
        {
            print("Level 8 Loaded");
            SpaenEnemy(level8);
            defauleSpwanRate = spawnRateLevel8;
        }
        if (defauleSpwanRate <= 0 && (score >= 1500 && score <= 1700))
        {
            print("Level 9 Loaded");
            SpaenEnemy(level9);
            defauleSpwanRate = spawnRateLevel9;
        }
        if (defauleSpwanRate <= 0 && (score >= 1700 && score <= 2000))
        {
            print("Level 10 Loaded");
            SpaenEnemy(level10);
            defauleSpwanRate = spawnRateLevel10;
        }
    }

    private void SpaenEnemy(GameObject[] level)
    {
        int ramdomMeteor = Random.Range(0, level.Length);
        float randomPos = Random.Range(-4f, 4f);

        GameObject planet = Instantiate(level[ramdomMeteor], new Vector2(transform.position.x, randomPos), Quaternion.identity) as GameObject;
    }

}

