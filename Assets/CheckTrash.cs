using UnityEngine;

public class CheckTrash : MonoBehaviour
{
    public string targetTag; 
    public int scoreValue = 10; 

    private int currentScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Correct object entered the collider: " + other.name);
            IncreaseScore();
        }
        else
        {
            Debug.Log("Incorrect object entered the collider: " + other.name);
        }
    }

    private void IncreaseScore()
    {
        currentScore += scoreValue;
        Debug.Log("Score increased! Current score: " + currentScore);
    }
}