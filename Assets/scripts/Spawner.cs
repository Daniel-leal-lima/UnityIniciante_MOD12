using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObjectRuntimeSet player;
    [SerializeField] Transform[] spawnLocations;
    [SerializeField] GameObject monsterPrefab;
    [SerializeField] Transform enemiesHolder;
    private GameObject target;
    private void Start()
    {
        target = player.GetItemIndex(0);
        StartCoroutine(nameof(SpawnLogic));
    }
    IEnumerator SpawnLogic()
    {
        while (target!=null)
        {
            float probability = Time.deltaTime * Random.Range(0, 3);
            if (probability < 3) Spawn();
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }
    }
    void Spawn()
    {
        int randomNumber = Random.Range(0, spawnLocations.Length);
        Transform location = spawnLocations[randomNumber];
        GameObject spawnedObj = Instantiate(monsterPrefab, location.position, Quaternion.identity);
        spawnedObj.transform.SetParent(enemiesHolder);
    }
}
