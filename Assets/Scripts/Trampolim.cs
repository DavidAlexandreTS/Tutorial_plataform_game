using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public float JumpForce;

    private Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anime.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
