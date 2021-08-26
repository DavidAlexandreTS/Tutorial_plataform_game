using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimiga : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anime;

    private bool colliding;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;

    public LayerMask lay;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Aqui estamos movimentando o inimigo, o velocity é uma classe do rigidbody que
        // adiciona velocidade a um corpo(o que faz o ngc se movimentar na tela)
        rig.velocity = new Vector2(speed, rig.velocity.y);//não quer alterar o eixo y

        //o Linecast desenha um colision em 2 posições na tela(invisível)
        //passar o lay ali, significa que o inimigo meio que "pode bater"
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, lay);//isso aqui retorna verdadeiro ou falso
        
        // verdadeiro, entra aqui se bater em algo
        if(colliding)
        {
            // inverte o valor de speed pra o personagem virar? Sim, pois representa o x no eixo de movimentação
            speed = -speed;

        }
    }
}
