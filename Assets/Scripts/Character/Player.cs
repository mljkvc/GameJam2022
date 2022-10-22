using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider2D;
    private RaycastHit2D boxHit_x, boxHit_y, circleHit_x, circleHit_y;
    private Vector3 moveDelta;
    private Rigidbody2D rb;

    public float moveForce = 1.5f;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string ATTACK_ANIMATION = "Attack";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
        boxHit_x = Physics2D.BoxCast(
            transform.position, 
            boxCollider.size, 
            0,
            new Vector2(moveDelta.x, moveDelta.y), 
            Mathf.Abs(moveDelta.x * Time.deltaTime * moveForce),
            LayerMask.GetMask("Fighter")
            );
        boxHit_y = Physics2D.BoxCast(
            transform.position, 
            boxCollider.size, 
            0, 
            new Vector2(0, moveDelta.y), 
            Mathf.Abs(moveDelta.y * Time.deltaTime * moveForce),
            LayerMask.GetMask("Fighter")
            );
        
        
        if (boxHit_x.collider != null || boxHit_y.collider != null)
        {
            
        }
        
        
        /*Physics2D.CircleCast(
            transform.position, 
            circleCollider2D.radius, 
            new Vector2(Mathf.Abs(moveDelta * Time.deltaTime * moveForce))
        );*/
        

        if (boxHit_x.collider == null && boxHit_x.collider == null && circleHit_x == false)
        {
            // We can move
            rb.velocity = (moveDelta * Time.deltaTime * moveForce);

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

        // Check if we should attack
        if (Input.GetButtonDown("Fire1") && anim.GetBool(ATTACK_ANIMATION) == false)
        {
            // Start attacking
            anim.SetBool(ATTACK_ANIMATION, true);
            attackPlayer();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            // Stop attacking
            anim.SetBool(ATTACK_ANIMATION, false);
        }
    }
}
