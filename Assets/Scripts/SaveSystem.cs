using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    public Transform Player;
    [SerializeField]
    public GameObject TonneauSpawner;
    [SerializeField]
    public Rigidbody2D Tonneau;
    public bool content_loaded = false;

    private const string SAVE_SCORE = "Key_CurrentScore";
    private const string SAVE_PLAYER_POS_X = "Key_PlayerCurrentPosX";
    private const string SAVE_PLAYER_POS_Y = "Key_PlayerCurrentPosY";
    private const string SAVE_PLAYER_POS_Z = "Key_PlayerCurrentPosZ";
    private const string SAVE_TONNEAU_NUMBER = "Key_SaveTonneauNumber";
    private const string SAVE_TONNEAU_POS_X = "Key_TonneauCurrentPosX";
    private const string SAVE_TONNEAU_POS_Y = "Key_TonneauCurrentPosY";
    private const string SAVE_TONNEAU_POS_Z = "Key_TonneauCurrentPosZ";
    private const string SAVE_TONNEAU_VEL_X = "Key_TonneauCurrentVelX";
    private const string SAVE_TONNEAU_VEL_Y = "Key_TonneauCurrentVelY";

    // Start is called before the first frame update
    void Start()
    {
        // chemin vers le dossier de l'application
        //string appFolder = Application.persistentDataPath;
        Debug.Log("Start");
        LoadGame();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("OnApplicationPause - true");
            SaveGame();
        }
        else
        {
            Debug.Log("OnApplicationPause - false");
            LoadGame();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            Debug.Log("OnApplicationFocus - false");
            SaveGame();
        }
        else
        {
            Debug.Log("OnApplicationFocus - true");
            LoadGame();
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        SaveGame();
    }

    private void SaveGame()
    {
        PlayerPrefs.SetFloat(SAVE_PLAYER_POS_X, Player.localPosition.x);
        PlayerPrefs.SetFloat(SAVE_PLAYER_POS_Y, Player.localPosition.y);
        PlayerPrefs.SetFloat(SAVE_PLAYER_POS_Z, Player.localPosition.z);
        PlayerPrefs.SetInt(SAVE_TONNEAU_NUMBER, TonneauSpawner.transform.childCount);
        Debug.Log(TonneauSpawner.transform.childCount);
        for (int i = 0; i < TonneauSpawner.transform.childCount; i++)
        {
            PlayerPrefs.SetFloat(SAVE_TONNEAU_POS_X + "_" + i, 
                TonneauSpawner.transform.GetChild(i).localPosition.x);
            PlayerPrefs.SetFloat(SAVE_TONNEAU_POS_Y + "_" + i,
                TonneauSpawner.transform.GetChild(i).localPosition.y);
            PlayerPrefs.SetFloat(SAVE_TONNEAU_POS_Z + "_" + i,
                TonneauSpawner.transform.GetChild(i).localPosition.z);
            PlayerPrefs.SetFloat(SAVE_TONNEAU_VEL_X + "_" + i,
                TonneauSpawner.transform.GetChild(i).GetComponentInChildren<Rigidbody2D>().velocity.x);
            PlayerPrefs.SetFloat(SAVE_TONNEAU_VEL_Y + "_" + i,
                TonneauSpawner.transform.GetChild(i).GetComponentInChildren<Rigidbody2D>().velocity.y);
        }
        PlayerPrefs.Save();
        
    }

    private void LoadGame()
    {
        Debug.Log("load save");
        if (PlayerPrefs.HasKey(SAVE_PLAYER_POS_X) && content_loaded == false)
        {
            float player_x = PlayerPrefs.GetFloat(SAVE_PLAYER_POS_X);
            float player_y = PlayerPrefs.GetFloat(SAVE_PLAYER_POS_Y);
            float player_z = PlayerPrefs.GetFloat(SAVE_PLAYER_POS_Z);
            Player.localPosition = new Vector3(player_x, player_y, player_z);
            Debug.Log(PlayerPrefs.GetInt(SAVE_TONNEAU_NUMBER));
            for (int i = 0; i < PlayerPrefs.GetInt(SAVE_TONNEAU_NUMBER); i++)
            {
                float tonneau_x = PlayerPrefs.GetFloat(SAVE_TONNEAU_POS_X + "_" + i) +
                    TonneauSpawner.transform.localPosition.x - 0.9f;
                float tonneau_y = PlayerPrefs.GetFloat(SAVE_TONNEAU_POS_Y + "_" + i) +
                    TonneauSpawner.transform.localPosition.y - 0.1f;
                float tonneau_z = PlayerPrefs.GetFloat(SAVE_TONNEAU_POS_Z + "_" + i) + 
                    TonneauSpawner.transform.localPosition.z;
                float tonneau_vel_x = PlayerPrefs.GetFloat(SAVE_TONNEAU_VEL_X);
                float tonneau_vel_y = PlayerPrefs.GetFloat(SAVE_TONNEAU_VEL_Y);
                Debug.Log(i + " - " + tonneau_x + " " + tonneau_y + " " + tonneau_z);
                Rigidbody2D rb = Instantiate(Tonneau,
                    new Vector3(tonneau_x, tonneau_y, tonneau_z), Quaternion.identity);
                rb.velocity = new Vector2(tonneau_vel_x, tonneau_vel_y);
                rb.transform.SetParent(TonneauSpawner.transform);
            }
            content_loaded = true;
        }
    }
}
