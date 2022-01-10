using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _secondsBetweenSpawnMin;

    private float _elapsedTimeSpawn = 0;
    private float _elapsedTimeSpawnDown = 0;

    private void Start()
    {
        Initialize(_prefabs);
    }

    private void Update()
    {
        _elapsedTimeSpawn += Time.deltaTime;
        _elapsedTimeSpawnDown += Time.deltaTime;

        if(_elapsedTimeSpawn >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject gameObject))
            {
                _elapsedTimeSpawn = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetObject(gameObject, _spawnPoints[spawnPointNumber].position);
            }
        }

        if(_secondsBetweenSpawn > _secondsBetweenSpawnMin)
        {
            if(_elapsedTimeSpawnDown >= 30)
            {
                _elapsedTimeSpawnDown = 0;
                _secondsBetweenSpawn -= 0.2f;

                if(_secondsBetweenSpawn < _secondsBetweenSpawnMin)
                    _secondsBetweenSpawn = _secondsBetweenSpawnMin;
            }
        }
    }

    private void SetObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    }
}
