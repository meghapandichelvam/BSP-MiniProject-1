using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{

    private AudioSource clickClip;

    private void Start()
    {
        clickClip = GetComponent<AudioSource>();
    }
    public void playgame()
    {
        SceneManager.LoadScene("Story");
    }
    public void quitgame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void ButtonPress()
    {
        clickClip.Play();
    }
    
}
