using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private Transform GFX;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float jumpTime = 0.3f;

    [SerializeField] private float crouchHeight = 0.5f;

    private GameController gameController;


    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {

        #region Jump

        if(isGrounded && Input.GetButtonDown("Jump"))
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
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            col.radius = 0.25f;
        }
        
        if(Input.GetAxis("Vertical") >= 0 && isGrounded)
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1, GFX.localScale.z);
            col.radius = 0.5f;
            
        }

        #endregion
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameController.gameOver();
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
