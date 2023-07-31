using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovementPlatformer : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float hMove;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    public LayerMask whatIsGround;

    private bool isJumping;
    private float jumpTimeCounter;
    public float jumpTime;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 7f;
        jumpTime = 1f;
        jumpForce = 7f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (rb.rotation.z != 0)
        //    StandUp();

        //This works for horizontal movement but need to also jump to have a platformer.
        hMove = Input.GetAxisRaw("Horizontal");

        //float h = hMove * speed * Time.deltaTime;

        //Vector3 move = new Vector3(hMove, 0f, 0f);

        rb.velocity = new Vector2(hMove * speed, rb.velocity.y);

        //transform.Translate(move);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    /*
    void StandUp()
    {
        //Rotate the Z axis back towards 0
        if (rb.rotation.z < 1 && rb.rotation.z > -1)
            rb.rotation = new Vector3(0, 0, 0);
        else if (rb.rotation.z > 0)
            rb.rotation = new Vector3(0, 0, rb.rotation.z - 1);
        else if (rb.rotation.z < 0)
            rb.rotation = new Vector3(0, 0, rb.rotation.z + 1);

    }*/
}
