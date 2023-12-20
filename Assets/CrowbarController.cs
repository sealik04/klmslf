using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarController : MonoBehaviour
{
    public GameObject Crowbar;
    bool canAttack = true;
    public float AttackCD = 0.5f;
    public AudioSource swing;
    public bool canDamage = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canDamage = true;
            if (canAttack)
            {
                CrowbarAttack();
                swing.Play(0);
            }
        }
    }

    public void CrowbarAttack()
    {
        canAttack = false;
        Animator animator = Crowbar.GetComponent<Animator>();
        animator.SetTrigger("Attack");
        StartCoroutine(ResetAttackCD());
    }

    IEnumerator ResetAttackCD()
    {
        yield return new WaitForSeconds(AttackCD);
        canAttack = true;
    }
}
