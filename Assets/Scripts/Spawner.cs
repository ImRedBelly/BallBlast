using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] blocks;

    void Start()
    {
        StartCoroutine(SpawnObject(blocks));
    }

    IEnumerator SpawnObject(GameObject[] objects)
    {
        
        while (true)
        {
            int dropObjects = Random.Range(0, objects.Length);
            Instantiate(objects[dropObjects], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(13f);
        }
    }
}
