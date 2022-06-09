using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string[] levels;


    public void handlePlayPressed()
    {
        SceneManager.LoadScene(levels[0]);
    }

    public void handleExitPressed()
    {
        UnityEngine.Application.Quit();
    }
}
