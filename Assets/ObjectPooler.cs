using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class GalaxyPool
    {
        public string name;
        public GameObject obj;
        public int size;
    }
    public Dictionary<string, Queue<GameObject>> galaxypool;
    public List<GalaxyPool> galaxypools;

    public static ObjectPooler instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        galaxypool = new Dictionary<string, Queue<GameObject>>();

        foreach(GalaxyPool pool in galaxypools)
        {
            Queue<GameObject> pooledobjs = new Queue<GameObject>();
            for(int i = 0;i< pool.size; i++)
            {
                GameObject obj = Instantiate(pool.obj);
                obj.SetActive(false);
                pooledobjs.Enqueue(obj);
            }
            galaxypool.Add(pool.name, pooledobjs);
        }
    }
    public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        if(!galaxypool.ContainsKey(tag))
        {
            Debug.LogError("Pool tag not found");
            return null;
        }
        GameObject objToSpawn = galaxypool[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        galaxypool[tag].Enqueue(objToSpawn); ;
        return objToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
