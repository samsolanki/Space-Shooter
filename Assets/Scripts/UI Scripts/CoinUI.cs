using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{

    public static CoinUI instance;

    [SerializeField] private TextMeshProUGUI coinAmountText;
    private float coinAmount;
    private float tragetCoins;
    private float animationTime = 1;


    private void Awake()
    {
        instance = this;
    }


    private void OnEnable()
    {
        coinAmount = DataManager.instance.totalCoin;
        tragetCoins = DataManager.instance.totalCoin;
        coinAmountText.text = coinAmount.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if(coinAmount != tragetCoins)
        {
            coinAmount = Mathf.Lerp(coinAmount, tragetCoins, animationTime * Time.deltaTime);

            if(tragetCoins - coinAmount < 10)
            {
                coinAmount = tragetCoins; 
            }

            coinAmountText.text = coinAmount.ToString();
        }
    }

    public void CalcCoin()
    {
        tragetCoins = DataManager.instance.totalCoin;
    }
}
