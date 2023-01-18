using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerBullet : MonoBehaviour
{

    [Header("Contrallor")]
    [SerializeField] private float bulletForce = 5;
    public int damage = 50;
    
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
      // _rigidbody.velocity = new Vector2(bulletForce, _rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }

}
