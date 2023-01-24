using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpSelector : MonoBehaviour
{

    [SerializeField] private RectTransform[] powerUpPenal;

    [Header("PowerUp Data")]
    [SerializeField] private PowerUpDataManager[] powerUpData;
    [SerializeField] private TextMeshProUGUI[] powerUpDamageAmountText;
    [SerializeField] private TextMeshProUGUI[] powerUpFirerateAmountText;
    [SerializeField] private TextMeshProUGUI[] powerUpTimeAmountText;

    [Header("Upgrade powerUp")]
    [SerializeField] private Button[] buyButton;
    [SerializeField] private TextMeshProUGUI[] buyButtonPrice;
    [SerializeField] private Image[] lockImage;
    [SerializeField] private Sprite[] powerUpSprite;

    private int currentPowerUpIndex;


    private void Awake()
    {
        
    }

    private void Start()
    {
        SetPowerData();
    }

    public void SetPowerData()
    {
        for (int i = 0; i < powerUpData.Length; i++)
        {
            powerUpDamageAmountText[i].text = powerUpData[i].CurrentPowerUpDamage().ToString();
            powerUpFirerateAmountText[i].text = powerUpData[i].CurrentPowerUpFirerate().ToString();
            powerUpTimeAmountText[i].text = powerUpData[i].CurrentPowerUpTime().ToString();
            lockImage[i].gameObject.SetActive(!powerUpData[i].GetPowerUpUnlockState());
            buyButtonPrice[i].text = powerUpData[i].BuyPowerUp().ToString();

            if (powerUpData[currentPowerUpIndex].GetCurrentPowerUpLevel() == 4)
            {
                buyButton[currentPowerUpIndex].interactable = false;
            }
        }
    }

    public void BuyPowerUpButton(int index)
    {
        if(DataManager.instance.totalCoin >= powerUpData[index].BuyPowerUp())
        {
            if (!powerUpData[index].GetPowerUpUnlockState()) {
                DataManager.instance.SubstractCoin(powerUpData[index].BuyPowerUp());
                powerUpData[index].SetPowerUpUnlockState(true);
               // print("Status of power up " + powerUpData[index].GetPowerUpUnlockState());
                DataManager.instance.PowerUpUnlockState(currentPowerUpIndex);
                DataManager.instance.SetCurrentPowerUpIndex(index);
                SetPowerUpState(index);
            }
            else if (powerUpData[index].GetCurrentPowerUpLevel() < 5)
            {
                DataManager.instance.SubstractCoin(powerUpData[index].BuyPowerUp());
                powerUpData[index].SetPowerUpLevel(buyButton[index].gameObject);
                DataManager.instance.SetPowerUpLevel(index, powerUpData[index].GetCurrentPowerUpLevel());
                SetPowerUpState(index);
            }
        }
        

    }


    public void SetPowerUpState(int index) 
    {
        powerUpDamageAmountText[index].text = powerUpData[index].CurrentPowerUpDamage().ToString();
        powerUpFirerateAmountText[index].text = powerUpData[index].CurrentPowerUpFirerate().ToString();
        powerUpTimeAmountText[index].text = powerUpData[index].CurrentPowerUpTime().ToString();
        lockImage[index].gameObject.SetActive(!powerUpData[index].GetPowerUpUnlockState());
        buyButtonPrice[index].text = powerUpData[index].BuyPowerUp().ToString();
    }

}
