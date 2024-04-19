using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private Transform GFX;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float jumpTime = 0.3f;

    private GameController gameController;
    [SerializeField] private Animator anim;

    private float speed = 10f;
    float direction;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;
    float height;

    public Transform pistol;
    public GameObject bulletPrefab;

    private void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.mode) 
        {
        #region Jump

        if (isGrounded) anim.SetBool("jump", false);
        else anim.SetBool("jump", true);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetButton("Jump") && isJumping)
        {
            if(jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            } 
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

        #endregion

        #region Crouch

        if(Input.GetAxis("Vertical") < 0 && isGrounded)
        {
            anim.SetBool("crouch", true);
            //GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            //col.radius = 0.25f;
        }
        
        if(Input.GetAxis("Vertical") >= 0 && isGrounded)
        {
            anim.SetBool("crouch", false);
            //GFX.localScale = new Vector3(GFX.localScale.x, 1, GFX.localScale.z);
            //col.radius = 0.5f;
            
        }

        #endregion
        } else 
        {
            Debug.Log("Fase 2");
            height = Input.GetAxis("Vertical");
        }

        //Shooting logic
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, pistol.position, pistol.rotation);
    }


    // It's called by physics
    void FixedUpdate() 
    {
        if(gameController.mode)
            rb.velocity = new Vector2(rb.velocity.x, height * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            
        //    gameController.gameOver();
    
        }
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        } 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = false;
        }
    }
}
