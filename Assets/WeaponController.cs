using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Pistol pistol;

    [SerializeField] string enemyTag = "Enemy";

    bool fire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fire = false;
        }

        if (fire)
        {
            pistol.Fire(enemyTag);

            if (pistol.UseTap())
            {
                fire = false;
            }
        }
    }
}
