using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSelectorMenu : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private RectTransform[] playerSelectionPenal;

    [Header("PlayerData State")]
    [SerializeField] private PlayerDataManager[] playerData;
    [SerializeField] private TextMeshProUGUI[] playerHealthAmountText;
    [SerializeField] private TextMeshProUGUI[] playerSpeedAmountText;
    [SerializeField] private TextMeshProUGUI[] playerDamageAmountText;
    [SerializeField] private TextMeshProUGUI[] playerFirerateAmountText;

    [Header("Player Upgrade Data")]
    [SerializeField] private TextMeshProUGUI[] playerUpgradePriceText;
    [SerializeField] private Button[] upgradeButton;
    [SerializeField] private Image[] playerSelectImage;
    [SerializeField] private Button[] playerSelectButton;
    [SerializeField] private Image[] lockedIcon;
    [SerializeField] private Image[] playerImageIcon;

    private int currentPlayerIndex;

    private void Awake()
    {
        currentPlayerIndex = PlayerManager.instance.GetPlayerCurrentIndex();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPlayeData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetPlayeData()
    {
        for (int i = 0; i <playerData.Length; i++)
        {
            playerHealthAmountText[i].text = playerData[i].CurrentPlayerHealth().ToString();
            playerDamageAmountText[i].text = playerData[i].CurrentPlayerDamage().ToString();
            playerSpeedAmountText[i].text = playerData[i].CurrentPlayerSpeed().ToString();
            playerFirerateAmountText[i].text = playerData[i].CurrentPlayerFireRate().ToString();
            playerUpgradePriceText[i].text = playerData[i].PlayerBuyPrice().ToString();
            lockedIcon[i].gameObject.SetActive(!playerData[i].GetUnlockState());
            playerSelectButton[i].gameObject.SetActive(playerData[i].GetUnlockState());


            if(playerData[i].GetCurrentLevelOfPlayer() == 4)
            {
                upgradeButton[i].gameObject.GetComponent<Button>().interactable = false;
            }

            if(i == currentPlayerIndex)
            {
                playerSelectImage[i].gameObject.SetActive(true);
            }
            else
            {
                playerSelectImage[i].gameObject.SetActive(false);
            }
        }
    }


    public void OnClickPlayerSelection(int index)
    {
        if (currentPlayerIndex == index)
            return;

        playerSelectImage[currentPlayerIndex].gameObject.SetActive(false);
        PlayerManager.instance.SetCurrentPlayerIndex(index);
        currentPlayerIndex = index;
        Destroy(PlayerManager.instance.GetPlayer());
        PlayerManager.instance.SetPlayer();
        PlayerManager.instance.GetPlayer().SetActive(false);
        //DATAMANAGER TO SET CURRENT PLAYER INDEX TO INDEX
        DataManager.instance.SetCurrentPlayerIndex(index);
        playerSelectImage[index].gameObject.SetActive(true);
    }


    public void OnClickBuyOrUpgradeButton(int index)
    {
        if(DataManager.instance.totalCoin >= playerData[index].PlayerBuyPrice())
        {
            if (!playerData[index].GetUnlockState())
            {
                DataManager.instance.SubstractCoin(playerData[index].PlayerBuyPrice());
                playerData[index].SetUnlockState(true);
                DataManager.instance.CurrentsPlayerUnlockState(index);
                SetPlayerStates(index);
            }
            else if(playerData[index].GetCurrentLevelOfPlayer() < 5)
            {
                DataManager.instance.SubstractCoin(playerData[index].PlayerBuyPrice());
                playerData[index].SetPlayerLevelUp(upgradeButton[index].gameObject);
                SetPlayerStates(index);
                DataManager.instance.SetCurrentPlayerLevel(index, playerData[index].GetCurrentLevelOfPlayer());
            }
        }
    }


    public void SetPlayerStates(int index)
    {
        playerHealthAmountText[index].text = playerData[index].CurrentPlayerHealth().ToString();
        playerDamageAmountText[index].text = playerData[index].CurrentPlayerDamage().ToString();
        playerSpeedAmountText[index].text = playerData[index].CurrentPlayerSpeed().ToString();
        playerFirerateAmountText[index].text = playerData[index].CurrentPlayerFireRate().ToString();
        playerUpgradePriceText[index].text = playerData[index].PlayerBuyPrice().ToString();
        lockedIcon[index].gameObject.SetActive(!playerData[index].GetUnlockState());
        playerSelectButton[index].gameObject.SetActive(playerData[index].GetUnlockState());
    }
}
