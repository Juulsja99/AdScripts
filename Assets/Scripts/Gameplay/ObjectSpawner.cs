using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fallingObject;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float spawnRangeX = 2.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f,spawnInterval);
    }

    private void SpawnObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        Instantiate(fallingObject, spawnPosition, Quaternion.identity);
    }
}
