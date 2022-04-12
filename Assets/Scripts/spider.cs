using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spider : MonoBehaviour
{

    public float visionRadius;
    public float attackRadius;
    public float speed;
    GameObject pj;
    Vector3 initialPosition;
    Animator anim;
    Rigidbody2D rb2d;
    public AudioClip spiderSound;
    AudioSource spiderPlayer;

    // Start is called before the first frame update
    void Start()
    {
        pj = GameObject.FindGameObjectWithTag("PJ");
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = initialPosition;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, pj.transform.position - transform.position, visionRadius, 1 << LayerMask.NameToLayer("Default")); //, 1 << LayerMask.NameToLayer("Pj"));
        Vector3 forward = transform.TransformDirection(pj.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "PJ")
            {
                target = pj.transform.position;
                
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if (target != initialPosition && distance < attackRadius)
        {
            spiderPlayer.PlayOneShot(spiderSound);
            anim.SetFloat("MovX", dir.x);
            anim.SetFloat("MovY", dir.y);
            //anim.Play("Walk Down", -1, 0);
        }

        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
            anim.speed = 1;
            anim.SetFloat("MovX", dir.x);
            anim.SetFloat("MovY", dir.y);
            anim.SetBool("isWalking", true);
            
        }


        if (target == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;
            anim.SetBool("isWalking", false);
            
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

}















