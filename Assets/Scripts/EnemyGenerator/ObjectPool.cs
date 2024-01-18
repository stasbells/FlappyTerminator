using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<Enemy> _pool = new List<Enemy>();
    protected int _capacity;

    protected void Initialize(Enemy enemy)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(enemy, _container.transform);

            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void ResetInactiveObjects()
    {
        foreach (var item in _pool)
        {
            if (item.gameObject.activeSelf == false)
                item.transform.position = _container.transform.position;
        }
    }

    protected bool TryGetObject(out Enemy resault)
    {
        resault = _pool.FirstOrDefault(enemy => enemy.gameObject.activeSelf == false);

        return resault != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
            item.transform.position = _container.transform.position;
        }
    }

    protected int GetActiveObjectsCount()
    {
        int count = 0;

        foreach (var item in _pool)
        {
            if (item.gameObject.activeSelf == true)
                count++;
        }

        return count;
    }
}