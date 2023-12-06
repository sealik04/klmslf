using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public float throwForce = 500f; //sílá hodu objektu
    public float pickUpRange = 5f; //délka ze které může hráč vzít předmět
    private GameObject heldObj; //objekt, který hráč zvedne
    private Rigidbody heldObjRb; //rigidbody toho objektu
    private int LayerNumber; //layer index
    
    void Start()
    {
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
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
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
        if (heldObj != null) 
        {
            MoveObject(); 
            if (Input.GetKeyDown(KeyCode.Mouse0)) //bind na levé myšítko, hození objektu, který hráč drží
            {
                ThrowObject();
            }

        }
    }
    void PickUpObject(GameObject pickUpObj)//pickup objektu
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldObj = pickUpObj; //proměnná si bere ten objekt, na který míří raycast
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //proměnná holdObjRb si bere parametr rigidbody toho objektu
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; 
            heldObj.layer = LayerNumber; //změní layer objektu na holdLayer
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject() //puštění toho objektu, všechny parametry se nastaví na defaultní null
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; 
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; 
        heldObj = null; 
    }
    void MoveObject()
    {
        //objekt, který hráč drží je v empty objektu, takže je neustále v jedné statické pozici
        heldObj.transform.position = holdPos.transform.position;
    }
    void ThrowObject() //zahození objektu
    {
        //stejná funkce jako DropObject, ale je k tomu přidaný Force, takže se objekt zahodí
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    
}