using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Animator tAnim;
    public GameObject pj;
    
    //public GameObject bullet;
    public Transform turretsite;
    //public float delay;
    //public float bulletRate;
    public float turretCd = 4;
    public GameObject bulletDown1;


    // Start is called before the first frame update

    private void Awake()
    {
        tAnim = GetComponent<Animator>();
    }

    void Start()
    {
        //InvokeRepeating("fire", delay, bulletRate);
    }

    // Update is called once per frame
    void Update()
    {
        turretCd -= Time.deltaTime;

        if (turretCd == 5)

        {
            tAnim.SetBool("shooting", true);
        }

        else if (turretCd <= 0)
        {
            tAnim.SetBool("shooting", false);
            turretCd = 4;
        }



    }

    public void fire()
    {
        GameObject bulletCopy = Instantiate(bulletDown1, turretsite.position, turretsite.rotation);

        //if (bulletDown1.gameObject.layer == 9)

        //{
        //    Destroy(bulletDown1);

        //}

        //else

        //{
        //    Destroy(bulletDown1, 1.8f);
        //}
    }



}
