using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonneau : MonoBehaviour
{
    /*[SerializeField]
    public GameObject explosion;*/
    [SerializeField]
    public GameObject entityCollision;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == entityCollision.name)
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
