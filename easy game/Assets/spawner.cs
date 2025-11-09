using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; 

    [SerializeField] float minimumInterval;
    [SerializeField] float maximumInterval;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
    
    public IEnumerator SpawnCoroutine()
    {
        while (true){

            float waitTime = Random.Range(minimumInterval, maximumInterval);

            yield return new WaitForSeconds(waitTime);

            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
   
    }  
}
    
