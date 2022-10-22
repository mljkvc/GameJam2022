using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider2D;
    private RaycastHit2D hit_x, hit_y;
    private Vector3 moveDelta;

    public float moveForce = 1.5f;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private int _attack = 6;
    private int _defense = 6;
    private int _maximumHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        movePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        animatePlayer();

        if(Input.GetButtonDown("Fire1"))
        {
            attackPlayer();
        }

    }

    private void movePlayer() 
    {
        // Get info for moving
        Vector3 originalScale = transform.localScale;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0 && originalScale.x < 0)
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        else if (moveDelta.x < 0 && originalScale.x > 0)
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));

        // Meke sure we can move in x and y direction
        hit_x = Physics2D.BoxCast(
            transform.position, 
            boxCollider.size, 
            0,
            new Vector2(moveDelta.x, 0), 
            Mathf.Abs(moveDelta.x * Time.deltaTime * moveForce),
            LayerMask.GetMask("Fighter")
            );
        hit_y = Physics2D.BoxCast(
            transform.position, 
            boxCollider.size, 
            0, 
            new Vector2(0, moveDelta.y), 
            Mathf.Abs(moveDelta.y * Time.deltaTime * moveForce),
            LayerMask.GetMask("Fighter")
            );

        if (hit_x.collider != null || hit_y.collider != null)
        {
            Debug.Log("AHA");
        }

        /*
        Physics2D.CircleCast(
            transform.position, 
            circleCollider2D.radius, 
            new Vector2(Mathf.Abs(moveDelta * Time.deltaTime * moveForce))
        );
        */

        if (hit_x.collider == null && hit_y.collider == null)
        {
            // We can move
            transform.Translate(moveDelta * Time.deltaTime * moveForce);

        }

    }

    private void attackPlayer()
    {
        
    }

    private void animatePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
            anim.SetBool(WALK_ANIMATION, true);
        else 
            anim.SetBool(WALK_ANIMATION, false);
    }
}
