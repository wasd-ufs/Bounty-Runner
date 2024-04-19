using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private float modeDuration;
    private float modeTime;

    private float scorepoints;

    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject Despawner;
    [SerializeField] private GameObject player;


       


    // Start is called before the first frame update
    void Start()
    {

        player.SetActive(true);
        //Possibilidade de come�ar com qualquer modo
        modeTime = 0;
        GameMode0();
        scorepoints = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("modeTime: " + modeTime);
        //Debug.Log("gameMode: " + gameMode);
        if (spawner.spawnTime > 0)
        {
            scorepoints += Time.deltaTime;
            ScoreText.text = "Score: " + scorepoints.ToString("N0");
        }
        modeTime += Time.deltaTime;

        //50% de chance de mudar o modo ao atingir o limite de dura��o
        // Acrescenta mais 10s caso n�o mude 
        if (modeTime >= modeDuration)
        {
            if (Random.Range(0, 2) == 1)
            {
                ChangeMode(Random.Range(0, 5));
                modeTime = 0;
            } else
            {
                modeTime -= 10f;
            }
        }
    }

    void ChangeMode(int mode)
    {
        if (mode == 0) GameMode0();
        else if (mode == 1) GameMode1();
        else if (mode == 2) GameMode2();
        else if (mode == 3) GameMode3();
        else GameMode4();

    }

    void GameMode0()
    {
        //Modo de jogo padr�o
    }

    void GameMode1()
    {
        //Modo mudan�a de gravidade
    }

    void GameMode2()
    {
        //Modo padr�o por�m de ponta-cabe�a
    }

    void GameMode3()
    {
        //Modo flappy bird
    }

    void GameMode4()
    {
        //Modo subir e descer a barra
    }

    public void gameOver()
    {
        //Falta pausar a movimenta��o dos obst�culos
        
        player.SetActive(false);
        spawner.spawnTime = -1;
        spawner.obstacleSpeed = 0;
        SceneManager.LoadScene(2);
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {   
        //Falta destruir obst�culos restantes
        
        StartMenu.SetActive(true);
        Start();
        SceneManager.LoadScene(1);
    }
}
