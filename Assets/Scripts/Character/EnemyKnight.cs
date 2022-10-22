using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform player;
    Transform enemy;

    public GameObject floatingTextPrefab;

    public int detectionRadius = 5;
    private Vector2 moveDelta;
    public float moveForce = 1.5f;
    public float health = 100f;
    bool dead = false;

    private Animator animEnemy;
    private string WALK_ANIMATION = "EnemyWalk";
    private string DIE_ANIMATION = "EnemyDeath";
    public bool weaponInUse = false;
    //public ShootingEnemy shootingEnemy;

    // float meleeRange = 10;
    bool moving = true;

    public GameObject deathEffect;


    // Start is called before the first frame update
    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        enemy = GetComponent<Transform>();

        animEnemy = GetComponent<Animator>();
        //shootingEnemy.enemyKnight = this;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (IsDead() == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        
        CheckIfPlayerNearby();
        if (!dead) {
            dead = IsDead();
        }
    }

    bool IsDead() {
        if (health > 0) {
            return false;
        }
        else {
            return true;
        }
    }

    public void TakeDamage(float damage)
    {
        // Trigger floating text

        if (floatingTextPrefab)
        {
            //ShowFloatingText();
        }

        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            // Die
            Destroy (this.gameObject, 2f);
            animEnemy.Play(DIE_ANIMATION);
        }
    }

    void CheckIfPlayerNearby() {
        if (Vector2.Distance(player.position, enemy.position) <= detectionRadius && moving && health >= 0) {
            MoveEnemy();
        }
        else {
            animEnemy.SetBool(WALK_ANIMATION, false);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void MoveEnemy() {
        Vector3 originalScale = transform.localScale;
        moveDelta = (player.position - enemy.position).normalized;
        transform.Translate(moveDelta * Time.deltaTime * moveForce);

        if (moveDelta.x > 0 && originalScale.x < 0)
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        else if (moveDelta.x < 0 && originalScale.x > 0)
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));

        animEnemy.SetBool(WALK_ANIMATION, true);
    }

    /*
    void ShowFloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = "25 HP";
        go.GetComponent<TextMesh>().color = Color.yellow;
        go.GetComponent<TextMesh>().fontSize = 15;
    }
    */

    /*
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            if (!weaponInUse) {
                weaponInUse = true;
                moving = false;
                //StartCoroutine(shootingEnemy.Klanje());
            }
        }
        Debug.Log(weaponInUse);
    }
    private void OnCollisionExit2D(Collision2D collision) {
        weaponInUse = false;
        moving = true;
    }
    /*void CheckCollision() {
        Debug.Log("Kolizija");
        if (Vector2.Distance(enemy.position, player.position) <= meleeRange) {
            if (!weaponInUse) {
                weaponInUse = true;
                StartCoroutine(shootingEnemy.Klanje());
            }
            Debug.Log(FindObjectOfType<Player>().health);
        }
    }*/

    

}