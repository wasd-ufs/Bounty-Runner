using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private float modeDuration;
    private float modeTime;

    private float scorepoints;

    public bool mode = false;

    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject Despawner;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Nave;


       


    // Start is called before the first frame update
    void Start()
    {

        player.SetActive(true);
        //Possibilidade de come�ar com qualquer modo
        modeTime = 0;
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
                mode = !mode;
                if (mode) Instantiate(Nave, Nave.transform.position, Nave.transform.rotation);
                modeTime = 0;
            } else
            {
                modeTime -= 10f;
            }
        }
    }

    IEnumerator ModeTransition()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Nave, Nave.transform.position, Nave.transform.rotation); 
    }

    public void gameOver()
    {
        
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
