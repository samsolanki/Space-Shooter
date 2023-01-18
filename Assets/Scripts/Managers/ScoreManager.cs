using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


    [SerializeField] private TextMeshProUGUI scoreText;

    public int scoreCount;


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
        scoreText.text = scoreCount.ToString();
    }


    public void AddScore(int scoreAmount)
    {
        scoreCount += scoreAmount;
        scoreText.text = scoreCount.ToString();
    }

    public void DecraseScore(int scoreAmount)
    {
        scoreCount -= scoreAmount;
        scoreText.text = scoreCount.ToString();
    }

}
