using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ContinueToGame : MonoBehaviour
{
    public void StartGame(string level)
    {
       SceneManager.LoadScene("Fight Scene", LoadSceneMode.Single);
    }
}

