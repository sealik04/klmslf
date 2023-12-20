using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public AudioSource pickedUp;
    public bool canPickUp;
    public Transform holdPos;
    public float pickUpRange = 10f; //délka ze které může hráč vzít předmět
    private GameObject heldObj; //objekt, který hráč zvedne
    private Rigidbody heldObjRb; //rigidbody toho objektu
    private int LayerNumber; //layer index
    
    void Start()
    {
        canPickUp = true;
        LayerNumber = LayerMask.NameToLayer("holdLayer"); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //bind na E
        {
            if (heldObj == null) 
            {
                //raycast, který kontroluje, jestli se hráč kouká na objekt
                RaycastHit hit;
                if (canPickUp && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                        //pickup objektu
                        PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                    DropObject();
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)//pickup objektu
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldObj = pickUpObj; //proměnná si bere ten objekt, na který míří raycast
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //proměnná holdObjRb si bere parametr rigidbody toho objektu
            heldObjRb.isKinematic = false;
            heldObjRb.useGravity = false;
            heldObjRb.transform.parent = holdPos.transform; 
            heldObj.layer = LayerNumber; //změní layer objektu na holdLayer
            pickedUp.Play(0);
        }
    }
    void DropObject() //puštění toho objektu, všechny parametry se nastaví na defaultní null
    {
        heldObj.layer = 0; 
        heldObjRb.isKinematic = false;
        heldObjRb.useGravity = true;
        heldObj.transform.parent = null; 
        heldObj = null; 
    }
    /*void MoveObject()
    {
        //objekt, který hráč drží je v empty objektu, takže je neustále v jedné statické pozici
        heldObj.transform.position = holdPos.transform.position;
    }*/

}