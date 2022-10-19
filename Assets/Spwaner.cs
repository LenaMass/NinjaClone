using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnF());
        IEnumerator spawnF()
        {
            while (true)
            {
                float delay = Random.Range(minDelay, maxDelay);
                
                yield return new WaitForSeconds(delay);
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];
                GameObject spwanedFruit = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
                Destroy(spwanedFruit, 3f);
            } 
        }
    }
}
