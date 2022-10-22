using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    int direction = 1;
    float range = 1000;
    float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Shoot();
        }
        if (Input.GetKeyDown("a")) {
            direction = -1;
        }
        if (Input.GetKeyDown("d")) {
            direction = 1;
        }
    }

    void Shoot() {
        //Length of the ray
        float laserLength = 50f;

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), laserLength);

        //If the collider of the object hit is not NUll
        if (hit.collider != null) {
            if (hit.collider.tag == "Enemy") {
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.tag);
                FindObjectOfType<EnemyKnight>().health -= damage;
            }
        }
    }

}
