using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject gameoverPenal;
    [SerializeField] private GameObject gameplayPenal;
    [SerializeField] private GameObject playerSelectorPenal;
    [SerializeField] private GameObject powerUpSelectorPenal;
    [SerializeField] private GameObject commanPenal;
    [SerializeField] private GameObject loadingScean;
    [SerializeField] private TextMeshProUGUI gameoverScoreText;


    public float timer = 1;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        gameoverPenal.SetActive(false);
        playerSelectorPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(false);
        gameplayPenal.SetActive(false);
        commanPenal.SetActive(false);
    }

    public void LoadMainMenu()
    {
        commanPenal.SetActive(true);
        loadingScean.SetActive(false);
    }

    public void StartGame() {
        GameManager.instance.isGamePlay = true;
        PlayerManager.instance.StartGame();
        gameplayPenal.SetActive(true);
        commanPenal.SetActive(false);
        playerSelectorPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(false);
    }

    public void PlayerSelectMenuOpen()
    {
        playerSelectorPenal.SetActive(true);
        gameplayPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(false);
    }

    public void PowerupSelectMenuOpen()
    {
        playerSelectorPenal.SetActive(false);
        gameplayPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(true);
    }


    public void Gameover()
    {
        Time.timeScale = 0;
        gameoverScoreText.text = ScoreManager.instance.scoreCount.ToString();
        gameoverPenal.SetActive(true);
    }


    public void RestartGame()
    {
        Time.timeScale = 1;
        ScoreManager.instance.scoreCount = 0;
        SceneManager.LoadScene(0);
    }

}
