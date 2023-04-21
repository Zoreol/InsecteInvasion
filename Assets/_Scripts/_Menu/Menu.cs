using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu_to_open;
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenMenu()
    {
        menu_to_open.SetActive(true);
    }
    public void CloseMenu()
    {
        menu_to_open.SetActive(false);
    }
}
