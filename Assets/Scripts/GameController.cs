using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;

    public Text scoreText;

    public GameObject gameOver;
    
    public static GameController instance;
   

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Metodo para alterar o texto de pontuação
    public void UpdateScoreText()
    {
        // Score text é o objeto que esta sendo manipulado e queremos mudar o valor do objeto
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
