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
    [SerializeField] private GameObject pausePenal;
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
        pausePenal.SetActive(false);
    }

    //MAIN MENU LOADING
    public void LoadMainMenu()
    {
        commanPenal.SetActive(true);
        loadingScean.SetActive(false);
    }

    //START GAME BUTTON
    public void StartGame() {
        GameManager.instance.SetIsPlayerAlive(true);
        PlayerManager.instance.StartGame();
        PlayerManager.instance.GetPlayer().SetActive(true);
        gameplayPenal.SetActive(true);
        commanPenal.SetActive(false);
        playerSelectorPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(false);
    }

    //SELECT PPLAYER MENU OPEN
    public void PlayerSelectMenuOpen()
    {
        playerSelectorPenal.SetActive(true);
        gameplayPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(false);
    }

    //SELECT BULLET MENU OPEN
    public void PowerupSelectMenuOpen()
    {
        playerSelectorPenal.SetActive(false);
        gameplayPenal.SetActive(false);
        powerUpSelectorPenal.SetActive(true);
    }

    //OPEN PAUSE MENU
    public void OpenPauseMenu()
    {
        pausePenal.SetActive(true);
        Time.timeScale = 0;
    }

    //RESUME GAME BUTTON AND CLOSE PAUSE MENU BUTTON
    public void ResumeGame()
    {
        pausePenal.SetActive(false);
        Time.timeScale = 1;
    }

    //GAME OVER SCREEN
    public void Gameover()
    {
        Time.timeScale = 0;
        GameManager.instance.SetIsPlayerAlive(false);
        gameoverScoreText.text = ScoreManager.instance.scoreCount.ToString();
        gameoverPenal.SetActive(true);
    }

    //RESTEART BUTTON
    public void RestartGame()
    {
        Time.timeScale = 1;
        GameManager.instance.SetIsPlayerAlive(true);
        ScoreManager.instance.scoreCount = 0;
        SceneManager.LoadScene(0);
    }

}
