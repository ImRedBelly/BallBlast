using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] blocks;
    public float timeSpawn;

    private void OnEnable()
    {
        StartCoroutine(SpawnObject(blocks));
    }


    public IEnumerator SpawnObject(GameObject[] objects)
    {
        while (true)
        {
            int dropObjects = Random.Range(0, objects.Length);
            Instantiate(objects[dropObjects], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
