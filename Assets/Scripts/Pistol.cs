using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] public float damage = 20f;
    [SerializeField] public float fireRate;
    [SerializeField] public float fireDistance;
    [SerializeField] public Transform bulletPoint;
    public AudioSource gunShot;

    bool fireCD;
    RaycastHit hit;

    public void Fire(string enemyTag)
    {
        if(fireCD) return;
        gunShot.Play(0);

        Ray ray = new Ray();
        ray.origin = bulletPoint.position;
        ray.direction = bulletPoint.TransformDirection(Vector3.forward);

        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.tag);
            if (hit.collider.CompareTag(enemyTag))
            {
                var healthControl = hit.collider.GetComponent<HealthController>();
                healthControl.ApplyDamage(damage);
            }
        }

        fireCD = true;
        StartCoroutine(StopCooldownAfterTime());
    }

    public IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        fireCD = false;
    }

    public bool UseTap()
    {
        return fireRate == 0;
    }
}
