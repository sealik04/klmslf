using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onClick;
    public GameObject loadLevelMenu;
    public GameObject mainMenu;

    public void Start()
    {
    
        mainMenu.SetActive(true);
        loadLevelMenu.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        
        if (name == "NewGame")
        {
            loadNewGame();
        }
        else if (name == "LoadLevel")
        {
            loadLevel();
        }
        else if (name == "EXIT")
        {
            Application.Quit();
        }
        else if (name == "Level1")
        {
            loadFirstLevel();
        }
        else if (name == "Level2")
        {
            loadSecondLevel();
        }
        else if (name == "Level3")
        {
            loadThirdLevel();
        }
        else if (name == "Level1Text")
        {
            loadFirstLevel();
        }
        else if (name == "Level2Text")
        {
            loadSecondLevel();
        }
        
        else if (name == "Level3Text")
        {
            loadThirdLevel();
        }
        
        
    }

    public void loadNewGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void loadLevel()
    {
        mainMenu.SetActive(false);
        loadLevelMenu.SetActive(true);
    }

    public void loadFirstLevel()
    {
        SceneManager.LoadScene("FirstScene");
    }
    
    public void loadSecondLevel()
    {
        SceneManager.LoadScene("SecondScene");
        Debug.Log("fsa");
    }
    
    public void loadThirdLevel()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void undoLevelSelect()
    {
        mainMenu.SetActive(true);
        loadLevelMenu.SetActive(false);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    
}
