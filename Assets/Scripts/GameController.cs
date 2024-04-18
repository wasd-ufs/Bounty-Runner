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
        //Possibilidade de começar com qualquer modo
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

        //50% de chance de mudar o modo ao atingir o limite de duração
        // Acrescenta mais 10s caso não mude 
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
        //Modo de jogo padrão
    }

    void GameMode1()
    {
        //Modo mudança de gravidade
    }

    void GameMode2()
    {
        //Modo padrão porém de ponta-cabeça
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
        //Falta pausar a movimentação dos obstáculos
        player.SetActive(false);
        spawner.spawnTime = -1;
        spawner.obstacleSpeed = 0;
        GameOverScreen.SetActive(true);
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {   
        //Falta destruir obstáculos restantes
        GameOverScreen.SetActive(false);
        StartMenu.SetActive(true);
        Start();
    }
}
