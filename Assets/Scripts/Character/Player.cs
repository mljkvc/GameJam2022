using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
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
        Vector3 originalScale = transform.localScale;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0 && originalScale.x < 0)
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        else if (moveDelta.x < 0 && originalScale.x > 0)
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));

        transform.Translate(moveDelta * Time.deltaTime * moveForce);
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
