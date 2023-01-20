using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public bool isPlayerAlive;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive == true)
        {
            print(isPlayerAlive);
        }

        ClearPlayerPrefsData();
    }


    public bool GetIsPlayerAlive()
    {
        return isPlayerAlive;
    }

    public void SetIsPlayerAlive(bool isPlayerAlive)
    {
        this.isPlayerAlive = isPlayerAlive;
    }

    public void GameOver()
    {

    }


    private void ClearPlayerPrefsData()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Data is cleared");
            PlayerPrefs.DeleteAll();
        }
    }
}
