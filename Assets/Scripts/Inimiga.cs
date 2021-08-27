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

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

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
            // Para rotacionar o meu personagem
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            // inverte o valor de speed pra o personagem virar? Sim, pois representa o x no eixo de movimentação
            speed *= -1f;
        }
    }

    //obs: eu tava tendo um bug pq o método nunca era chamado, isso rolava pq ele tava dentro do Update()
    void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Player")
            {
                // Checa se o personagem ta batendo na cabeça do inimigo(pelo headPoint)
                float height = col.contacts[0].point.y - headPoint.position.y;

                // ou seja, bateu na cabeça
                if(height > 0)
                {
                    //da um pulinho pra cima
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);

                    // inimigo para de andar quando morre
                    speed = 0;

                    // pega a animação que botamos no animator
                    anime.SetTrigger("die");
                    
                    //desabilitar os colisores
                    boxCollider2D.enabled = false;
                    circleCollider2D.enabled = false;
                    
                    // pra o inimigo não cair da tela pq vai ficar sem os colisores
                    rig.bodyType = RigidbodyType2D.Kinematic;
                    // faz o inimigo sumir depois de 1 segundo
                    Destroy(gameObject, 0.33f);
                }
            }
        }
}
