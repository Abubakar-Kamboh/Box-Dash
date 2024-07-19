using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject Gameplay;
    public GameObject PausedMenu;
    public GameObject spawnerOb;
    public GameObject GameOverScreen;
    public GameObject player;
    public AudioSource DeathAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null)
        {
            GameOverScreen.SetActive(true);
        }
        
        
    }
    public void playButton()
    {
        Gameplay.SetActive(true);
        mainMenu.SetActive(false);
        PausedMenu.SetActive(false);
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
    public void PauseButton()
    {
        //Gameplay.SetActive(false);
        mainMenu.SetActive(false);
        PausedMenu.SetActive(true);
        if(PausedMenu.active==true)
        {
            Gameplay.SetActive(false);
            spawnerOb.SetActive(false);
        }
    }
    public void resumeButton()
    {
        Gameplay.SetActive(true);
        mainMenu.SetActive(false);
        PausedMenu.SetActive(false);
    }
    public void restart()
    {
        SceneManager.LoadScene(0 );   
    }
    public void mainmenuButton()
    {
        DeathAudioSource.Play();
        mainMenu.SetActive(true);
        GameOverScreen.SetActive(false);
        Gameplay.SetActive(false);
        SceneManager.LoadScene(0 ); 
    }
}
