using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float powerUpTimer = 5;
    [SerializeField] private Sprite powerUpSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime);

        powerUpTimer -= Time.deltaTime;

    }

    public void PowerUp()
    {

    }
}
