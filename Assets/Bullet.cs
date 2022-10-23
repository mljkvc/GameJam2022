using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject pfbDmg;

    public float damage = 25f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        EnemyKnight enemy = hitInfo.GetComponent<EnemyKnight>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            
        }
        Destroy(gameObject);
    }
}
