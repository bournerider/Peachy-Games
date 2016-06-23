using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ContinueToGame : MonoBehaviour
{
    void Start()
    {
       SceneManager.LoadScene("Fight Scene", LoadSceneMode.Single);
    }
}

