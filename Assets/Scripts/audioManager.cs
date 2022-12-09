using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
