using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private Animator bAnim;
    public new Vector3 respawn;
    public new Vector3 respawnSpider;
    public GameObject pj;
    public AudioClip expSound;
    AudioSource soundPlayer;

    private void Awake()
    {
        bAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<pjMov>())
        {
            bAnim.SetBool("range", true);
            Destroy(gameObject, 0.8f);
            
            soundPlayer.PlayOneShot(expSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PJ")

        {
            pj.transform.position = respawn;
        }

        if (collision.gameObject.tag == "Spider")

        {
            pj.transform.position = respawnSpider;
        }

    }
}
