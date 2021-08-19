using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mulango : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();

            // g minusculo pega o proprio objeto que ta dentro do script
            // G maiusculo é declaração de variável
            Destroy(gameObject, 0.25f);
        }
    }
}
