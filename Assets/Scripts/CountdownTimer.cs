using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float time;
    public float scoreRequired;
    public GameObject failedScreen;
    public GameObject successScreen;
    public GameObject UserInterface;
    public CrowbarController CrowbarController;
    WeaponController weaponController;
    
    void Update()
    {
        if (playerController.playerScore == scoreRequired)
        {
            SceneManager.LoadScene("chooselevel");
            playerMovement.speed = 0;
            time = 0;
            Cursor.lockState = CursorLockMode.Confined;
            UserInterface.SetActive(false);
            successScreen.SetActive(true);
            mouseLook.gameOver = true;
        }
        
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        
        else if (time <= 0 && playerController.playerScore < scoreRequired)
        {
            SceneManager.LoadScene("chooselevel");
            playerMovement.speed = 0;
            time = 0;
            Cursor.lockState = CursorLockMode.Confined;
            UserInterface.SetActive(false);
            failedScreen.SetActive(true);
            successScreen.SetActive(false);
            CrowbarController.Crowbar.SetActive(false);
            mouseLook.gameOver = true;
        }
        else if (time <= 0 && playerController.playerScore >= scoreRequired)
        {
            SceneManager.LoadScene("chooselevel");
            playerMovement.speed = 0;
            time = 0;
            Cursor.lockState = CursorLockMode.Confined;
            UserInterface.SetActive(false);
            successScreen.SetActive(true);
            failedScreen.SetActive(false);
            CrowbarController.Crowbar.SetActive(false);
            mouseLook.gameOver = true;
        }
        
        
        if(playerController.currHealth <= 0)
        {
            SceneManager.LoadScene("chooselevel");
            playerMovement.speed = 0;
            time = 0;
            Cursor.lockState = CursorLockMode.Confined;
            UserInterface.SetActive(false);
            failedScreen.SetActive(true);
            successScreen.SetActive(false);
            CrowbarController.Crowbar.SetActive(false);
            mouseLook.gameOver = true;
        }
        
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        countdownText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
}
