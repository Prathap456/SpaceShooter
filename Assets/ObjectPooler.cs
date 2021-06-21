using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region singelton class
    public static ObjectPooler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> bulletPoolDictionary;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        bulletPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            bulletPoolDictionary.Add(pool.tag, objectPool);
        }

    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!bulletPoolDictionary.ContainsKey(tag))
        {
           Debug.LogWarning("pool with tag" + tag + " doesn't exist");
           return null;
        }
        GameObject objectToSpawn = bulletPoolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        bulletPoolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}