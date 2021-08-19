using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

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
}
