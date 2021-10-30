using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private GameObject playerSprite;


    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D playerRigidBody;


    [SerializeField]
    private float deceleration;


    private Vector2 velocityDirection;


    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform feet;

    [SerializeField]
    private float jumpHeight = 2;

    [SerializeField]
    private int jumpCount = 0;

    [SerializeField]
    int maxJumps = 1;


    // Start is called before the first frame update
    void Start()
    {
        velocityDirection = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        velocityDirection = new Vector2(0, 0);


        float x = Input.GetAxis("Horizontal");

        if (x > 0)
        {
            // Look right
            playerSprite.transform.localScale = new Vector2(1, 1);

            // Set walking animation
            playerAnimator.SetBool("IsWalking", true);

            // Change Velocity direction
            velocityDirection = new Vector2(1, 0);

        }
        else if (x < 0)
        {
            // Look left
            playerSprite.transform.localScale = new Vector2(-1, 1);

            // Set walking animation
            playerAnimator.SetBool("IsWalking", true);

            // Change Velocity direction
            velocityDirection = new Vector2(-1, 0);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
            //playerAnimator.SetBool("IsJumping", false);

            if (Mathf.Abs(playerRigidBody.velocity.x) > 0.05f)
            {
                playerRigidBody.velocity = Vector2.MoveTowards(playerRigidBody.velocity, new Vector2(0, playerRigidBody.velocity.y), deceleration * Time.deltaTime);
            }
            else
            {
                playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
            }

        }


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            jumpCount++;

            // Set jumping animation
            playerAnimator.SetBool("IsJumping", true);


            // Change Velocity direction
            // rb.AddForce(new Vector2(0, Mathf.Sqrt(2.0f * jumpHeight * 9.8f)) , ForceMode2D.Impulse);
            playerRigidBody.velocity += new Vector2(0, Mathf.Sqrt(2.0f * jumpHeight * 9.8f));
        }


        RaycastHit2D hit = Physics2D.Raycast(feet.position, -Vector2.up, 0.01f, groundLayer, -100f, 100f);

        if (hit.collider != null)
        {

            jumpCount = 0;
            playerAnimator.SetBool("IsJumping", false);
        }



        playerRigidBody.AddForce(velocityDirection * speed * Time.deltaTime);
    }
}
