using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //  ObjectPooler.Instance.SpawnFromPool("bullet", transform.position, Quaternion.identity);
    }
   GameObject temp1;
    // Update is called once per frame
    void FixedUpdate()
    {

        if (time >= 3.0f)
        {
            if (temp1 != null)
               temp1.SetActive(false);
            Vector3 enemySpawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 5.0f, 0);
            GameObject temp = ObjectPooler.Instance.SpawnFromPool("Enemy", enemySpawnPosition, Quaternion.Euler(0f,0f,180f));
            temp1 = temp;
            time = 0.0f;


        }
        time += Time.deltaTime;

    }
}