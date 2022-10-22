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

    Rigidbody2D rb;

    private Animator animEnemy;
    private string WALK_ANIMATION = "EnemyWalk";

    // Start is called before the first frame update
    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        enemy = GetComponent<Transform>();

        animEnemy = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if (Vector2.Distance(player.position, enemy.position) <= detectionRadius) {
            MoveEnemy();
        }
        else {
            rb.velocity = Vector3.zero;
            animEnemy.SetBool(WALK_ANIMATION, false);
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
}