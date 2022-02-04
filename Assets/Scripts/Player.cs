using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float movementX;
    [SerializeField]
    private float moveSpeed = 3f;
    public float jumpForce = 11f;
    private bool isGrounded;

    public Animator anim;
    public SpriteRenderer sr;
    public Rigidbody2D myBody;


    //public Transform activator;
    //public GameObject activateMagic;
    //public GameObject snowfall;

    

    // Start is called before the first frame update
    
    void Awake()
    {
        myBody.GetComponent<Rigidbody2D>();
        anim.GetComponent<Animator>();
        sr.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
      //  Run();
        PlayerJump();
        PlayerAnimation();
    }

    void Update()
    {
        Run();
        Shoot();
        ShootAndStand();
    }

    private void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    private void PlayerAnimation()
    {
        if(movementX > 0 && isGrounded)
        {
            anim.SetBool("walking", true);
            anim.SetBool("running", false);
            anim.SetBool("shootStand", false);
          //  anim.SetBool("shooting", true);

            sr.flipX = false;
        }
        else if(movementX < 0 && isGrounded)
        {
        //    anim.SetBool("shooting", true);
            anim.SetBool("walking", true);
            anim.SetBool("running", false);
            anim.SetBool("shootStand", false);

            sr.flipX = true;

            
        }
        else
        {
            anim.SetBool("walking", false);
            anim.SetBool("shooting", false);
        }


    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            moveSpeed = 5f;
            anim.SetFloat("running", moveSpeed);
            anim.SetBool("shooting", false);
            anim.SetBool("shootStand", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
            anim.SetFloat("running", moveSpeed);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("jumping", true);
          //  anim.SetBool("walking", false);

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        //else
        //{
        //    anim.SetBool("jumping", false);
        //}
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(1) && isGrounded)
        {
            anim.SetBool("shooting", true);
           // anim.SetBool("walking", true);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            anim.SetBool("shooting", false);
        }
    }

    private void ShootAndStand()
    {
        if(Input.GetMouseButtonDown(1) && isGrounded)
        {
            anim.SetBool("shootStand", true);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            anim.SetBool("shootStand", false);
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

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Activator"))
    //    {
    //        Debug.Log("Activating!");
    //        Instantiate(activateMagic, activator.position, activator.rotation);
    //        Instantiate(snowfall, new Vector3(0.11f, 1.18f, 0f), Quaternion.identity);

           
    //    }
    //}
   

}
