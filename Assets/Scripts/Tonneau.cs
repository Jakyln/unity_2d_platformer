using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonneau : MonoBehaviour
{
    [SerializeField]
    public GameObject explosion;
    [SerializeField]
    public GameObject entityCollision;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "SquareCollide")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        Debug.Log(collision.gameObject.name);
    }
}
