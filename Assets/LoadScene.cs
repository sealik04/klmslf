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
        Debug.Log(name + " Game Object Clicked", this);
        
        onClick.Invoke();     
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

    public void undoLevelSelect()
    {
        mainMenu.SetActive(true);
        loadLevelMenu.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
