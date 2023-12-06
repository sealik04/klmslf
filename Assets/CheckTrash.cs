using UnityEngine;

public class CheckTrash : MonoBehaviour
{
    public GameObject spravnyObjekt;
    public Collider spravnyCollider;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontrigger enter");
        Debug.Log("detekovaný colider: " +other.name);
        
        if (other.gameObject == spravnyObjekt)
        {
            Debug.Log("object detected");
            
            if (other.GetComponent<Collider>() == spravnyCollider)
            {
                Debug.Log("jupijej");
            }
            else
            {
                Debug.Log("špatný collider");
                Debug.Log("proč kurva");
            }
        }
        else
        {
            Debug.Log("idk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left ontrigger");
        
    }
}