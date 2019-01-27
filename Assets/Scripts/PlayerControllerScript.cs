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
        float move = Input.GetAxis("Horizontal");
        Vector2 moveInput = new Vector2(move, 0f);
        Animator animator = this.gameObject.GetComponent<Animator>();
        animator.SetFloat("velocityX", move);
        if (Mathf.Abs(move) > 0)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Hit");
            isMovingLeft = false;
            isMovingRight = false;
            isAttacking = true;
        }


        old_pos = transform.position.x;

        // animator.SetBool("isWalkingRight", isMovingRight);
        // animator.SetBool("isWalkingLeft", isMovingLeft);
        // animator.SetBool("isAttacking", isAttacking);

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
