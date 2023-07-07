using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject creditsMenu;

    public void Continue()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }

    public void Controls()
    {
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Credits()
    {
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ExitControlsButton()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitCreditsButton()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
