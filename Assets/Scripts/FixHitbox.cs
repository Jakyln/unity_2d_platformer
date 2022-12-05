using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixHitbox : MonoBehaviour
{
    int my1stInt;
    public int my2ndInt;
    int my3rdInt;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    public SpriteRenderer targetRenderer;


    Transform itemPrefab;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        System.Console.WriteLine("Hello");

        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((S.x / 2), 0);



        Debug.Log("Start is called");
        //selTransform = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
