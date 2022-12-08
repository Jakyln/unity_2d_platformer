using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyEvent : UnityEvent
{
}
public class SpawnTonneau : MonoBehaviour
{
    public MyEvent m_MyEvent;
    [SerializeField]
    public Vector3 spawnPoints;
    [SerializeField]
    public float startSpeed;
    [SerializeField]
    public bool startRight;
    [SerializeField]
    public Rigidbody2D spawnTarget;

    // Start is called before the first frame update
    void Start()
    {
        if (m_MyEvent == null)
        {
            m_MyEvent = new MyEvent();
        }
        m_MyEvent.AddListener(SpawnTarget);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTarget()
    {
        Rigidbody2D rb = Instantiate(spawnTarget, spawnPoints, Quaternion.identity);
        rb.velocity = new Vector2((startRight ? 1 : -1) * startSpeed, 1.0f);
        rb.transform.SetParent(this.transform);
    }
}
