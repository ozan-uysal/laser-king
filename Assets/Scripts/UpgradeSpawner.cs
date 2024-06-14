using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    public BoxCollider2D collider2D;
    public GameObject[] spawnObjects;
    public Vector2 spawnTimes = new Vector2(5,10);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimes.x, spawnTimes.y));
            Spawn();
        }
    }

    void Spawn()
    {
        float spawnX = Random.Range(collider2D.bounds.min.x, collider2D.bounds.max.x);
        float spawnY = Random.Range(collider2D.bounds.min.y, collider2D.bounds.max.y);
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], new Vector3(spawnX, spawnY), Quaternion.identity);
    }
}
