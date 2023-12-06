using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] Transform playerCamera;

    // Update is called once per frame
    public void Update()
    {
        transform.LookAt(playerCamera);
    }
}