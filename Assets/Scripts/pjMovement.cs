using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pjMovement : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator animator;
    Vector2 mov;
    public GameObject bullet;
    public GameObject pj;
    public new Vector3 respawn;
    float horizontal;
    float vertical;
    public float runSpeed = 4.0f;
    public float boostSpeedCD;
    private bool speedBoost;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (mov != Vector2.zero)
        {
            animator.SetFloat("movX", mov.x);
            animator.SetFloat("movY", mov.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("walking", false);
            animator.SetTrigger("attack");
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + mov * runSpeed * Time.fixedDeltaTime);
        body.velocity = new Vector2(0, 0);

        if (speedBoost)
        {
            boostSpeedCD += Time.deltaTime;
            if (boostSpeedCD >= 4)
            {
                runSpeed = 4;
                boostSpeedCD = 0;
                speedBoost = false;
            }
        }



        //rb2d.velocity


        if (horizontal > 0)
        {
            sprite.flipX = true;
            animator.SetBool("isWalkingSide", true);
        }

        else if (horizontal < 0)
        {
            sprite.flipX = false;
            animator.SetBool("isWalkingSide", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)

        {
            pj.transform.position = respawn;

        }

        //if (collision.gameObject.layer == 13)

        //{
        //    boostSpeedCD -= Time.deltaTime;
        //    runSpeed = 6;

        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)

        {
            speedBoost = true;
            runSpeed = 6;
            Destroy(other.gameObject);
        }
       
    }
}

