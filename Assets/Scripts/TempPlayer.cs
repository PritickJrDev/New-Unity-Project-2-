using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    private float movementX;
    public float moveSpeed=5f;
    public float jumpForce = 10f;
    private bool isGrounded;


    void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
        sr.GetComponent<SpriteRenderer>();
        anim.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        WalkAnimation();
        
    }

    void FixedUpdate()
    {
        JumpAnimation();
    }

    public void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    public void JumpAnimation()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("jumping", true);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void WalkAnimation()
    {
        if(movementX > 0)
        {
            anim.SetBool("walking", true);
            sr.flipX = false;
        }
        else if(movementX < 0)
        {
            anim.SetBool("walking", true);
            
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jumping", false);
        }
    }
}


















