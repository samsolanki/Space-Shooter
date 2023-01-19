using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingScean : MonoBehaviour
{

    [SerializeField] private Slider LoadingBar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LoadingBar.value -= Time.deltaTime;

        if (LoadingBar.value <= 0)
        {
            UIManager.instance.LoadMainMenu();
        }
    }
}
