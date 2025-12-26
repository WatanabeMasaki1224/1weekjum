using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    Rigidbody2D rb;
    private bool ground;
    Vector2 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void Update()
    {
       float x = Input.GetAxisRaw("Horizontal");
       rb.velocity  = new Vector2 (x* moveSpeed,rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && ground) 
        { 
            rb.velocity = new Vector2(rb.velocity.x,jumpPower);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground")
         || col.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            ground  = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground")
         || col.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            ground = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Pit"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
    }
}
