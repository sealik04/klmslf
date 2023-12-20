using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public CrowbarController cc;
    public HealthController enemyHealth;
    public float damageAmount = 50f;
    private bool hasDamaged = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasDamaged && collision.collider.CompareTag("Enemy"))
        {
                var enemyHealth1 = collision.collider.GetComponent<HealthController>();
                enemyHealth1?.ApplyDamage(damageAmount);
                hasDamaged = true;
                collision.collider.GetComponent<Animator>().SetTrigger("TakeDamage");
                StartCoroutine(CooldownDamage());
        }
        else if(!cc.canDamage)
        {
            hasDamaged = false;
        }
    }

    void OnCollisionStay(Collision other)
    {
        
    }


    IEnumerator CooldownDamage()
    {
        yield return new WaitForSeconds(0.5f);

        hasDamaged = false;
    }
}
