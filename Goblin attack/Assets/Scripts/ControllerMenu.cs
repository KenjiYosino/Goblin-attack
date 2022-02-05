using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonsMenu;
    [SerializeField] private GameObject buttonsExit;
    [SerializeField] private GameObject buttonsLoad;
   
    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }

    public void Loading()
    {
        buttonsMenu.SetActive(false);
        buttonsLoad.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
