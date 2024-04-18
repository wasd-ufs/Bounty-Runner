using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject Score;
    private GameController gameController;
    private Spawner spawner;

    private void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        spawner = FindObjectOfType(typeof(Spawner)) as Spawner;
    }

    //Start menu
    public void play()
    {
        spawner.spawnTime = 3f;
        spawner.obstacleSpeed = 6;
        StartMenu.SetActive(false);
        Score.SetActive(true);
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
        Score.SetActive(false);
        gameController.RestartGame();
    }
}
