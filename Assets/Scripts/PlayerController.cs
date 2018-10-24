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
    private Rigidbody2D rb2d;
    public bool facingRight = true;
    public bool death = false;
    public float speed = 10;
    public float jumpforce;
    public static bool IsInputEnabled = true;
    public bool mushroom = false;
    public GameObject otherGameobject;

    public GameObject playercam;
    private camera cam;
    private collider Collider;
    //private GameObject sound;

    //ground check
    public bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping = false;
    bool jump = false;

    //audio stuff
    private AudioClip clip;
    private AudioSource source;
    public AudioClip jumpClip;
    public AudioClip Coin;
    public AudioClip deathsound;
    public AudioClip stomp;
    public AudioSource mainmusic;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;



    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Collider = otherGameobject.GetComponent<collider>();
        cam = playercam.GetComponent<camera>();
        //sound = otherGameobject.GetComponent<GameObject>();
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

        /*if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
            
        }*/



        //stuff I added to flip my character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }


    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
            animator.SetBool("IsJumping", false);
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;
                animator.SetBool("IsJumping", true);


                // Audio stuff
                source.PlayOneShot(jumpClip, 1);


            }
            //animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            source.PlayOneShot(Coin, 1);
        }



        //if (other.gameObject.CompareTag("CoinBox"))
        // {
        //      other.gameObject.SetActive(false);
        //  }

        if (other.gameObject.CompareTag("deathcollider"))
        {
            death = true;
            animator.SetBool("death", true);
            speed = 0;
            source.PlayOneShot(deathsound, 1);
            mainmusic.Stop();
            //cam.offset = new Vector3(0, 0, 0);
            Destroy(otherGameobject);
            IsInputEnabled = false;
        }

        // if (other.gameObject.CompareTag("killcollider"))
        // {
        //     animator.SetBool("GoombaDeath", true);

        // }

        if (other.gameObject.CompareTag("MushroomBox"))
        {
            mushroom = true;
        }

        if (other.gameObject.CompareTag("killcollider"))
        {
            source.PlayOneShot(stomp, 2);

        }


    }
}
