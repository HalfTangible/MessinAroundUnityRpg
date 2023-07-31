using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//https://stackoverflow.com/questions/37543472/using-preferred-keys-to-move-a-player-in-unity
//https://www.youtube.com/watch?v=whzomFgjT50
//https://github.com/jayakusuma13/Unity-Turn-Based-JRPG/blob/master/scripts/PlayerController.cs

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private float hMove;
    private float vMove;
    //private animator anim;
    public bool canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    void Update()
    {
        if(!canMove) 
            return;

        //if(Input.GetKey(KeyCode.P))
        //anim.SetTrigger("IsAttacking");

        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        //anim.SetFloat("h",hMove);
        //anim.SetFloat("v",vMove);

        float h = hMove * speed * Time.deltaTime;
        float v = vMove * speed * Time.deltaTime;

        Vector3 move = new Vector3(h, v, 0f);

        transform.Translate(move);
    }
    


}

    /*
    // Update is called once per frame
	void Update () {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }*/
    /*
    void FixedUpdate()
    {
        //Console.WriteLine("FixedUpdate");
        Movement();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    */


    /*
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.WriteLine("Left");
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.WriteLine("Right");
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.WriteLine("Down");
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.WriteLine("Up");
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
    }
}*/
    /*if (Input.GetKey(KeyCode.LeftArrow)) //Sprite moves too quickly
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }*/