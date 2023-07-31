using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private float timeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 5;
        rb.velocity = transform.right * speed;

        //Set position to be the indicator so that we don't hit ourselves
        //Vector3 startPos = 
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
            thisDies();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        /*
         if(enemy != null){
        enemy.TakeDamage(damage);
        }
         */
        thisDies();
        }

    void thisDies()
    {
        Destroy(gameObject);
    }


}
