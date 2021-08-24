using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirRight;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        // Se for verdadeiro minha serra vai pra direita
        if(dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // Se falso a serra vai pra esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Time.deltaTime retorna o tempo real do jogo
        timer += Time.deltaTime;

        if(timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
