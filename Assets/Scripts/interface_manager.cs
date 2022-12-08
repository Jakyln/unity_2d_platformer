using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interface_manager : MonoBehaviour
{
    public void bouttonStart() => SceneManager.LoadScene("Level-1");

    public void bouttonMenu() => SceneManager.LoadScene("menu");
}
