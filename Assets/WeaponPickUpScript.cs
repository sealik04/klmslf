using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpScript : MonoBehaviour
{
    /*PlayerController playerController;
    public PickUpScript pickUpScript;
    public Transform weaponHoldPos;
    public float weaponPickUpRange = 10f; 
    private GameObject heldWeapon; 
    private Rigidbody heldWeaponRb; 
    private int LayerNumber; 
    
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //bind na E
        {
            if (heldWeapon == null) 
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponPickUpRange))
                {
                        PickUpWeapon(hit.transform.gameObject);
                        var weaponHP = GameObject.Find("weaponHoldPosition");
                        var crowbarController = weaponHP.GetComponent<CrowbarController>();
                        crowbarController.enabled = true;
                        pickUpScript.canPickUp = false;
                }
            }
            else
            {
                    pickUpScript.canPickUp = true;
                    DropWeapon();
            }
        }
    }
    void PickUpWeapon(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldWeapon = pickUpObj; 
            heldWeaponRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldWeaponRb.isKinematic = true;
            heldWeaponRb.useGravity = true;
            heldWeaponRb.transform.parent = weaponHoldPos.transform; 
            heldWeapon.layer = LayerNumber; 
            heldWeaponRb.transform.localRotation = Quaternion.Euler(new Vector3(176f, -10f, -68f));
            heldWeaponRb.transform.localPosition = new Vector3(0.05f, -0.32f, 0.62f);
        }
    }
    void DropWeapon() 
    {
        heldWeapon.layer = 0; 
        heldWeaponRb.isKinematic = false;
        heldWeaponRb.useGravity = true;
        heldWeapon.transform.parent = null; 
        heldWeapon = null; 
    }*/

}
