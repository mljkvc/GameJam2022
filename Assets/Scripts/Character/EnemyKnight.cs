using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;
    public Transform enemy;

    public GameObject floatingTextPrefab;
    public GameObject playerObject;

    public float detectionRadius = 7f;
    private float attackRadius = 1.5f;
    private float attackTime = 3.5f;
    private Vector2 moveDelta;
    public float moveForce = 1.5f;
    public float health = 100f;

    private bool dead = false;
    private bool isPlayerDead = false;
    private bool isTriggered = false;
    private float timeTriggered;

    private Animator animEnemy;
    private string WALK_ANIMATION = "EnemyWalk";
    private string ATTACK_ANIMATION = "EnemyAttack";
    private string DEATH_ANIMATION = "EnemyDeath";
    
    public bool weaponInUse = false;
    //public ShootingEnemy shootingEnemy;

    // float meleeRange = 10;
    // bool moving = true;

    public GameObject deathEffect;


    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        enemy = GetComponent<Transform>();

        animEnemy = GetComponent<Animator>();
        //shootingEnemy.enemyKnight = this;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (dead || isPlayerDead)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        if (isTriggered && Time.time - timeTriggered > attackTime)
        {
            AttackPlayer();
            timeTriggered = Time.time;

            animEnemy.SetBool(ATTACK_ANIMATION, true);
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
        if (dead)
            return;
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
            dead = true;
            Destroy (this.gameObject, 1f);
            animEnemy.Play(DEATH_ANIMATION);
        }
    }

    public void AttackPlayer()
    {
        if (isPlayerDead)
            return;
        
        isPlayerDead = FindObjectOfType<Player>().TakeDamage(25);
    }

    public void CheckIfPlayerNearby() {
        if (Vector2.Distance(player.position, enemy.position) <= detectionRadius) {
            if (Vector2.Distance(player.position, enemy.position) <= attackRadius)
            {
                if (!isTriggered || (isTriggered && Time.time - timeTriggered > 0.4))
                {
                    isTriggered = true;
                    timeTriggered = Time.time;
                    AttackPlayer();

                    animEnemy.SetBool(ATTACK_ANIMATION, true);
                }
            }
            else
            {
                MoveEnemy();
            }
        }
        else {
            animEnemy.SetBool(WALK_ANIMATION, false);
            rb.velocity = Vector3.zero;
        }
    }

    public void MoveEnemy() {
        //Vector3 originalScale = transform.localScale;
        //transform.Translate(moveDelta * Time.deltaTime * moveForce);

        moveDelta = (player.position - enemy.position).normalized;
        rb.velocity = (moveDelta * Time.deltaTime * moveForce);
        Debug.Log(rb.velocity);

        if (moveDelta.x > 0)
            transform.localEulerAngles = new Vector3(0, 0, 0);
        else if (moveDelta.x < 0)
            transform.localEulerAngles = new Vector3(0, -180, 0);

        animEnemy.SetBool(WALK_ANIMATION, true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animEnemy.SetBool(ATTACK_ANIMATION, true);
            isTriggered = true;
            timeTriggered = Time.time;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            animEnemy.SetBool(ATTACK_ANIMATION, false);
            isTriggered = false;
            timeTriggered = Time.time;
        }
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