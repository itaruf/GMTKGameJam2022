using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawnablePrefab;
    [SerializeField] private float _spawnFrequenceLowerRange=0.7f;
    [SerializeField] private float _spawnFrequenceHigherRange=1.5f;
    [SerializeField] private GameObject _spawnObjectsContainer;
    private bool _spawningAllowed = true;
    // Start is called before the first frame update
    void Start()
    {
        Event.current._onStartMiniGame += StartSpawn;
        Event.current._onEndMiniGame += StopSpawn;
        // StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }
    
    public void StopSpawn()
    {
        _spawningAllowed = false;
    }

    IEnumerator SpawnCoroutine()
    {
        while (_spawningAllowed)
        {
            yield return new WaitForSeconds(Random.Range(_spawnFrequenceLowerRange,_spawnFrequenceHigherRange));
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject Object = GameObject.Instantiate(_spawnablePrefab, _spawnablePrefab.transform.position, Quaternion.identity);
        Object.transform.parent = _spawnObjectsContainer.transform;
    }
}
