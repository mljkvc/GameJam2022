using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : MonoBehaviour
{
    public int detectionRadius = 5;
    Transform player;
    Transform enemy;
    private Vector2 moveDelta;
    public float moveForce = 1.5f;
    public float health = 100f;
    bool dead = false;

    private Animator animEnemy;
    private string WALK_ANIMATION = "EnemyWalk";
    public bool weaponInUse = false;
    public ShootingEnemy shootingEnemy;

    float meleeRange = 10;
    bool moving = true;


    // Start is called before the first frame update
    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        enemy = GetComponent<Transform>();

        animEnemy = GetComponent<Animator>();
        shootingEnemy.enemyKnight = this;
    }

    // Update is called once per frame
    private void FixedUpdate() {
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
            Debug.Log("DEAD");
            return true;
        }
    }

    void CheckIfPlayerNearby() {
        if (Vector2.Distance(player.position, enemy.position) <= detectionRadius && moving) {
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
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            if (!weaponInUse) {
                weaponInUse = true;
                moving = false;
                StartCoroutine(shootingEnemy.Klanje());
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