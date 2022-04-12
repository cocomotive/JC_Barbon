using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    public int playScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void TutoButton()
    {
        SceneManager.LoadScene(2);
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene(5);
    }

    public void exit()
    {
        Application.Quit();
    }
    public void Play2()
    {
        SceneManager.LoadScene(6);
    }
}
