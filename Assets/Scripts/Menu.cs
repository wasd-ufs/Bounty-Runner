using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    
    private GameController gameController;
    

    private void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
      
    }

    //Start menu
    public void play()
    {
        
        
        StartMenu.SetActive(false);
        
        SceneManager.LoadScene(1);
    }

    public void options()
    {
        Debug.Log("Options");
    }

    public void exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //Gameover menu
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
