using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private Animator animator;

    private int max = 15;
    private int min = -15;
    private float old_pos;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isAttacking = false;
    void Start()
    {
        old_pos = transform.position.x;
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
        if (old_pos < transform.position.x)
        {
            isMovingRight = true;
            isMovingLeft = false;
            // this.gameObject.transform.localScale = new Vector2(1f,0);
            this.gameObject.GetComponent<Animator>().Play("Player_Walk");
        }
        if (old_pos > transform.position.x)
        {
            isMovingRight = false;
            isMovingLeft = true;
            // this.gameObject.transform.localScale = new Vector2(-1f,0);
            this.gameObject.GetComponent<Animator>().Play("PlayerWalkingLeft");
        }
        if (!isMovingLeft && !isMovingRight)
        {
            isMovingLeft = false;
            isMovingRight = false;
            isAttacking = false;
            this.gameObject.GetComponent<Animator>().Play("StopPlayer");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Animator>().Play("Hit");
            isMovingLeft = false;
            isMovingRight = false;
            isAttacking = true;

        }


        old_pos = transform.position.x;

        animator.SetBool("isWalkingRight", isMovingRight);
        animator.SetBool("isWalkingLeft", isMovingLeft);
        animator.SetBool("isAttacking", isAttacking);

        moveVelocity = moveInput.normalized * speed;
        if (transform.position.x <= -15f)
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
        else if (transform.position.x >= 15f)
            transform.position = new Vector3(15f, transform.position.y, transform.position.z);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
