using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tonneau : MonoBehaviour
{
    /*[SerializeField]
    public GameObject explosion;*/
    [SerializeField]
    public GameObject entityCollision;
    private int score = 0;
    [SerializeField]
    public Text afficherScore;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == entityCollision.name)
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            score = score - 1;
            PlayerPrefs.SetString(" ", score.ToString());
            this.updateScore();
        }
    }

    public void Update()
    {
        Vector3 positionTonneau = gameObject.transform.position;
        Vector3 positionMario = entityCollision.transform.position;



        if (positionTonneau.y <= -3)
        {
            Destroy(gameObject);
            score = score + 1;
            //afficherScore = score.ToString();
            this.updateScore();
        }

        if (positionTonneau.y < positionMario.y)
        {

        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void updateScore()
    {
        Debug.Log("test :",GameObject.Find("score"));
        Debug.Log("test :",GameObject.Find("afficherScore"));
        
        
    }
}
