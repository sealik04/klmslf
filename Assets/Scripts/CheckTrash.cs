using System;
using UnityEngine;

public class CheckTrash : MonoBehaviour
{
    public string targetTag; 
    public float scoreValue = 5f;
    //public GameObject reaper;
    [SerializeField] PlayerController playerController;
    public AudioSource objectIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(other.gameObject);
            IncreaseScore();
            objectIn.Play(0);
        }
        else if(playerController.playerScore >= 5)
        {
            DecreaseScore(5);
        }
        else if(playerController.playerScore < 5)
        {
            playerController.currHealth -= 25;
        }
        /*else if(other.CompareTag("Radio"))
        {
            Instantiate(reaper);
        }*/
    }

    private void IncreaseScore()
    {
        playerController.playerScore += scoreValue;
    }

    private void DecreaseScore(int amount)
    {
        playerController.playerScore -= amount;
    }
}