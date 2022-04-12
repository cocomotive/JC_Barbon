using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletL : MonoBehaviour

{

    private Rigidbody2D rb;
    public float bulletLeft;
    public GameObject pj;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * bulletLeft;
                
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.8f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PJ")

        {
            Destroy(gameObject);

        }

        else

        {
            Destroy(gameObject, 1.8f);
        }

    }
}
