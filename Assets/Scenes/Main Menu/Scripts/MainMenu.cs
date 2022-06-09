using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject splashMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject characterSelectMenu;
    [SerializeField] string[] levels;

    GameObject activeMenu;

    void Awake()
    {
        splashMenu.SetActive(false);
        settingsMenu.SetActive(false);
        characterSelectMenu.SetActive(false);
        SetActiveMenu(splashMenu);
    }

    private void SetActiveMenu(GameObject obj)
    {
        if (activeMenu == null)
            activeMenu = obj;
        else
            activeMenu.SetActive(false);

        activeMenu = obj;
        activeMenu.SetActive(true);
    }

    public void splash_handleStartPressed()
    {
        SetActiveMenu(characterSelectMenu);
    }

    public void splash_handleExitPressed()
    {
        UnityEngine.Application.Quit();
    }

    public void splash_handleSettingsPressed()
    {
        SetActiveMenu(settingsMenu);
    }
    public void settings_handleFullscreenPressed()
    {
        UnityEngine.Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    public void settings_handleEscape()
    {
        SetActiveMenu(splashMenu);
    }

    public void character_handleCharacter0Selected()
    {
        SceneManager.LoadScene(levels[0]);
    }
    public void character_handleCharacter1Selected()
    {
        SceneManager.LoadScene(levels[0]);
    }
    public void character_handleCharacter2Selected()
    {
        SceneManager.LoadScene(levels[0]);
    }
    public void character_handleEscape()
    {
        SetActiveMenu(splashMenu);
    }

}
