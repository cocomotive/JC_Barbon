using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pjMov : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator animator;
    Vector2 mov;
    public GameObject pj;
    public GameObject limitMap;
    public new Vector3 respawn;
    public float speed;
    public float boostSpeedCD;
    private int boost;
    private bool speedBoost;
    public float boostPainCD;
    private bool speedPain;
    private int pain;
    public float timer = 60f;
    public float currentTimer;
    public int points;
    public Image timeUI;
    public Text UiText;
    public AudioClip axeSound, bootSound, potionSound, doorSound, godSound, powerSound, spiderSound;
    AudioSource soundPlayer;
    public GameObject door, door2, door3, victoria;
    public float godBoostPainCD;
    public float godBoostSpeedCD;




    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        speed = 4;
        currentTimer = timer;
        soundPlayer = GetComponent<AudioSource>();
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

        //if (Input.GetKeyDown("space"))
        //{
        //    animator.SetBool("walking", false);
        //    animator.SetTrigger("attack");
        //}

        if (speedBoost)
        {
            boostSpeedCD += Time.deltaTime;
            if (boostSpeedCD >= 4)
            {
                speed = 4;
                boostSpeedCD = 0;
                speedBoost = false;
            }
        }

        if (speedPain)
        {
            boostPainCD += Time.deltaTime;
            if (boostPainCD >= 4)
            {
                speed = 4;
                boostPainCD = 0;
                speedPain = false;
            }
        }



        if (currentTimer <= 0)
        {
            Debug.Log("Perdiste, te quedaste sin tiempo gil");
            speed = 0;
            animator.SetBool("walking", false);
            currentTimer = 0;
            SceneManager.LoadScene(4);

        }
        else
        {
            currentTimer -= Time.deltaTime;
            timeUI.fillAmount = currentTimer / timer;
            if (currentTimer == 0)
            {
                currentTimer = 0;
            }
        }

        if (points == 50) //&& Input.GetKey(KeyCode.Space))

        {

            //sprite.color = Color.red;
            //speed = speed * 1.2f;
            door.SetActive(true);
            door2.SetActive(true);
            door3.SetActive(true);
            victoria.SetActive(true);
            soundPlayer.PlayOneShot(doorSound);

        }

        else
        {
            door.SetActive(false);
            door2.SetActive(false);
            door3.SetActive(false);
            victoria.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + mov * speed * Time.fixedDeltaTime);
        body.velocity = new Vector2(0, 0);
    }





    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == 12)

    //    {
    //        pj.transform.position = respawn;

    //    }

    //}
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 12)
        {
            speedPain = true;
            speed = 0.5f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == 13)

        {
            speedBoost = true;
            speed = 6;
            Destroy(other.gameObject);
            soundPlayer.PlayOneShot(bootSound);
        }

        if (other.gameObject.layer == 14)

        {
            Debug.Log("EEEEH Corres rapido chinwenwencha! Ganaste");
            speed = 0;
            //currentTimer = 0;
            animator.SetBool("walking", false);
            SceneManager.LoadScene(7);
        }

        if (other.gameObject.layer == 15)

        {
            //timerFX.rest();
            pain = Random.Range(1, 11);
            currentTimer -= pain;
            Destroy(other.gameObject);
            Debug.Log("Esta posion te saca tiempo... ojo lo que tomas");
            Debug.Log("perdiste " + pain + " segundos.");
            soundPlayer.PlayOneShot(potionSound);
        }

        if (other.gameObject.layer == 16)

        {
            boost = Random.Range(1, 6);
            currentTimer += boost;
            Destroy(other.gameObject);
            Debug.Log("Esta posion da tiempo... como alla... alla le estan dando...");
            Debug.Log("recuperaste " + boost + " segundos.");
            soundPlayer.PlayOneShot(potionSound);
        }

        if (other.gameObject.layer == 17)

        {
            points++;
            Destroy(other.gameObject);
            UiText.text = points.ToString();
            soundPlayer.PlayOneShot(axeSound);

        }

        if (other.gameObject.layer == 18)

        {
            SceneManager.LoadScene(4);
        }

        if (other.gameObject.layer == 20 && points == 50)

        {
            SceneManager.LoadScene(3);
        }



    }
    //public void MenuButton()
    //{
    //    SceneManager.LoadScene(0);
    //}
}
