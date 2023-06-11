using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

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
        if (!menu_to_open)
        {
            return;
        }
        else
        {
            menu_to_open.SetActive(true);
        }
        
    }
    public void CloseMenu()
    {
        if (!menu_to_open)
        {
            return;
        }
        else
        {
            menu_to_open.SetActive(false);
        }
        
    }

   
}
