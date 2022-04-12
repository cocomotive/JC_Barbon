using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    public static musicManager daMusicManager;

    // Start is called before the first frame update
    void Start()
    {
        if (daMusicManager == null)
        {
            daMusicManager = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)

        {
            Destroy(gameObject);
        }
    }
}
