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
    private string afficherScore;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == entityCollision.name)
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            //score = score - 1;
            //PlayerPrefs.SetString(" ", score.ToString());
            //this.updateScore();
        }
    }

    public void Update()
    {
        Vector3 positionTonneau = gameObject.transform.position;

        if (positionTonneau.y <= -3)
        {
            Destroy(gameObject);
            score = score +1;
            Debug.Log(score);

            PlayerPrefs.SetString("score", score.ToString());
            this.updateScore();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void updateScore()
    {
        afficherScore = GameObject.Find("txt_score").GetComponent<TextMeshProUGUI>().text =
            "Score : " + PlayerPrefs.GetString("score");
        int meilleurScore = PlayerPrefs.GetInt("best_score");
        if (meilleurScore < score)
        {
            PlayerPrefs.SetInt("meilleurScore", score);
        }


    }
}
