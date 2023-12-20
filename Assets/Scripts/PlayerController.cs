using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerScore;
    public TextMeshProUGUI scoreText;
    public float playerMaxHealth = 10f;
    public float currHealth;
    MouseLook mouseLook;
    PlayerMovement playerMovement;
    CountdownTimer cdTimer;


    void Start()
    {
        currHealth = playerMaxHealth;
        if (Input.GetKeyDown(KeyCode.Y))
        {
            var player = GameObject.Find("FPP");
            var controller = player.GetComponent<WeaponController>();
            controller.enabled = false;
        }

        playerScore = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public void TakeDamage(float amount)
    {
        currHealth -= amount;
    }
    
    
}
