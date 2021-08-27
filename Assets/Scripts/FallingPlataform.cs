using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float FallingTime;
    
    private TargetJoint2D target;
    private BoxCollider2D boxcool;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxcool = GetComponent<BoxCollider2D>();
    }

    // Metodo para checar se tocou no personagem
    void OnCollisionEnter2D(Collision2D collision)
    {
        //se tocou cai dps de 2secs
        if(collision.gameObject.tag == "Player")
        {
            //nosso metodo vai ser chamado depois de fallingtimesegundos
            Invoke("Falling", FallingTime);
        }
    }

    //destroi se tocar em algo com a layer 9
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        target.enabled = false;
        boxcool.isTrigger = true;
    }
 
}
