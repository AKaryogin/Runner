using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pools = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for(int i = 0; i < _capacity; i++)
        {
            GameObject pool = Instantiate(prefab, _container.transform);
            pool.SetActive(false);

            _pools.Add(pool);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for(int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject pool = Instantiate(prefabs[randomIndex], _container.transform);
            pool.SetActive(false);

            _pools.Add(pool);
        }
    }

    protected bool TryGetObject(out GameObject gameObject)
    {
        gameObject = _pools.FirstOrDefault(p => p.activeSelf == false);

        return gameObject != null;
    }
}
