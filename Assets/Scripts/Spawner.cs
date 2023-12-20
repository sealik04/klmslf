using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] trash;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randomObject;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitUntil());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitUntil()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randomObject = Random.Range(0, 4);

            Vector3 spawnPoint = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1,
                Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(trash[randomObject], spawnPoint + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }

        yield return new WaitForSeconds(120f);
        
        stop = true;
    }
}
