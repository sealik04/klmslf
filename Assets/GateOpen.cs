using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject[] gates;
    public Vector3[] targetRotations; 
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(30f);
        
        for (int i = 0; i < gates.Length; i++)
        {
            ChangeRotation(gates[i], targetRotations[i]);
        }
        
    }

    private void ChangeRotation(GameObject gateToRotate, Vector3 targetRotation)
    {
        gateToRotate.transform.rotation = Quaternion.Euler(targetRotation);
    }
}
