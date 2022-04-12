using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretL : MonoBehaviour
{
    private Animator tAnimL;
    public GameObject pj;
    public Transform turretsite;
    public float turretCd = 4;
    public GameObject bulletLeft1;



    private void Awake()
    {
        tAnimL = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fireL()
    {
        GameObject bulletLCopy = Instantiate(bulletLeft1, turretsite.position, turretsite.rotation);
                
    }
}
