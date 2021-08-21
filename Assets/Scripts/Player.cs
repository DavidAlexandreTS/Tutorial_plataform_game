using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Animator anime;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // Move the character
    void Move()
    {
        // Create moves on x
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        // Personagem indo para a direita
        if(Input.GetAxis("Horizontal") > 0)
        {
            // Character is walking
            anime.SetBool("walk", true);

            // Personagem virado pra direita
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        // Personagem indo para a esquerda
        if(Input.GetAxis("Horizontal") < 0)
        {
            // Character is walking
            anime.SetBool("walk", true);

            // Para virar o bonito pra esquerda
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        // Sempre que o personagem tiver parado Input.GetAxis("Horizontal") será 0
        if(Input.GetAxis("Horizontal") == 0)
        {
            // Character is not walking
            anime.SetBool("walk", false);
        }
        
    }

    // Character jump rsrs
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anime.SetBool("walk", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce * 1.2f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
            
        }
    }

    // Metodo para checar se o personagem alguma coisa
    void OnCollisionEnter2D(Collision2D collision)
    {
        // se o personagem tocou no chao
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anime.SetBool("walk", false);
        }

        // se o personagem tocou no espinho
        if(collision.gameObject.tag == "Spike")
        {
            // print da unity
            //Debug.Log("Tocou o espinho!");
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    // Metodo para checar se o personagem saiu do chao \o/
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
