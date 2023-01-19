using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMenu : MonoBehaviour
{

    [SerializeField] private GameObject[] playerSprite;
    [SerializeField] private int[] price;

    private GameObject[] player;

    // Start is called before the first frame update
    void Start()
    {
        //SETTING PLAYER SPRITE LENGHT TO PLAYER GAMEOBJECT
        player = new GameObject[playerSprite.Length];

        for (int i =0; i < playerSprite.Length; i++)
        {
            player[i] = transform.GetChild(i).gameObject;
            player[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = playerSprite[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            player[i].transform.GetChild(0).transform.GetChild(5).GetComponentInChildren<TextMeshProUGUI>().text = price[i].ToString();
            player[i].transform.GetComponentInChildren<Button>().onClick.AddListener(() => SelectCharcter(i));
        }    
    }
    public void SelectCharcter(int index)
    {
        Debug.Log("You select player " + index);
    }
    
}
