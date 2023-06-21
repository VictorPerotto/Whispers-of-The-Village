using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject mapMenu;
    private bool pauseButtonDown;
    private bool questButtonDown;
    private bool mapButtonDown;

    private void Update()
    {
        pauseButtonDown = Input.GetKeyDown(KeyCode.Escape);
        questButtonDown = Input.GetKeyDown(KeyCode.Q);
        mapButtonDown = Input.GetKeyDown(KeyCode.Tab);

        if(questButtonDown && !pauseMenu.activeInHierarchy && !mapMenu.activeInHierarchy)
        {
            if(QuestLogUIController.Instance.gameObject.activeInHierarchy) QuestLogUIController.Instance.Hide();
            else QuestLogUIController.Instance.Show(); 
        }

        if(pauseButtonDown && !mapMenu.activeInHierarchy && !QuestLogUIController.Instance.gameObject.activeInHierarchy)
        {
            if(pauseMenu.activeInHierarchy)
            {
                Player.Instance.ReturnMove();
                Cursor.visible = false;
                pauseMenu.SetActive(false);
            }

            else
            {
                Player.Instance.StopMove();
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
        }

        if(mapButtonDown && !pauseMenu.activeInHierarchy && !QuestLogUIController.Instance.gameObject.activeInHierarchy)
        {
            if(mapMenu.activeInHierarchy)
            {
                Player.Instance.ReturnMove();
                Cursor.visible = false;
                mapMenu.SetActive(false);
            }

            else
            {
                Player.Instance.StopMove();
                Cursor.visible = true;
                mapMenu.SetActive(true);
            }
        }
    }

    public void ResumeButtonPressed()
    {
        Player.Instance.ReturnMove();
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }

    public void OptionsButtonPressed()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void ExitButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ControlsButtonPressed()
    {
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void CreditsButtonPressed()
    {
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ExitControlsButtonPressed()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ExitCreditsButtonPressed()
    {
        creditsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
