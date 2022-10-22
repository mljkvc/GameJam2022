using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public EnemyKnight enemyKnight;
    int direction = 1;
    float range = 1000;
    float damage = 10;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() { 
    }

    public IEnumerator Klanje() {
        //Length of the ray
        float laserLength = 10f;

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), laserLength);
        if (hit.collider == null) {
            hit = Physics2D.Raycast(transform.position, new Vector2(-direction, 0), laserLength);
        }

        //If the collider of the object hit is not NUll
        if (hit.collider != null) {
            if (hit.collider.tag == "Player") {
            //Hit something, print the tag of the object
            //Debug.Log("Hitting: " + hit.collider.tag);
                FindObjectOfType<Player>().health -= damage;
            }
        }
        yield return new WaitForSeconds(1);
        enemyKnight.weaponInUse = false;
    }

}
