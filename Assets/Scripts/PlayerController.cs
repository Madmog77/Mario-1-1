using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnLandEvent;
    public PlayerController controller;
    public Animator animator;
    public bool facingRight = true;
    public bool death = false;
    public float speed = 10;
    public float jumpforce;
    public static bool IsInputEnabled = true;
    public bool mushroom = false;
    public GameObject otherGameobject;
    public GameObject playercam;

    private Rigidbody2D rb2d;
    private camera cam;
    private collider Collider;


    //audio stuff section
    private AudioClip clip;
    private AudioSource source;
    public AudioClip jumpClip;
    public AudioClip Coin;
    public AudioClip deathsound;
    public AudioClip stomp;
    public AudioSource mainmusic;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    //ground check section 
    public bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping = false;
    bool jump = false;



    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Collider = otherGameobject.GetComponent<collider>();
        cam = playercam.GetComponent<camera>();
    }



    void Awake()
    {
        source = GetComponent<AudioSource>();
    }



    private void Update()
    {
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);

        if (Input.GetKey("escape"))
            Application.Quit();

      

        //stuff added to flip the character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }


    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }




    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
            animator.SetBool("IsJumping", false);
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = Vector2.up * jumpforce;
                animator.SetBool("IsJumping", true);


                // Audio stuff
                source.PlayOneShot(jumpClip, 1);


            }
        }
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            source.PlayOneShot(Coin, 1);
        }



        if (other.gameObject.CompareTag("deathcollider"))
        {
            death = true;
            animator.SetBool("death", true);
            speed = 0;
            source.PlayOneShot(deathsound, 1);
            mainmusic.Stop();
            Destroy(otherGameobject);
            IsInputEnabled = false;
        }


        if (other.gameObject.CompareTag("killcollider"))
        {
            source.PlayOneShot(stomp, 2);

        }



        if (other.gameObject.CompareTag("MushroomBox"))
        {
            mushroom = true;
        }
    }
}
