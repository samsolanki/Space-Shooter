using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] gamesSets;
    [SerializeField] private float spawnTime;
    [SerializeField] private float moveSpeed = 5;

    private float defaultSpwanTime;

    // Start is called before the first frame update
    void Start()
    {
        defaultSpwanTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            for(int i =0; i < gamesSets.Length; i++)
            {
                GameObject games = Instantiate(gamesSets[Random.Range(0, gamesSets.Length)], new Vector2(transform.position.x, Random.Range(-3, 3)), Quaternion.identity) as GameObject;
            }

            spawnTime = defaultSpwanTime;
        }
    }

}
