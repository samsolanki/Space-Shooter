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
    [SerializeField] private TextMeshProUGUI gameoverScoreText;


    public float timer = 1;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        gameoverPenal.SetActive(false);

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
