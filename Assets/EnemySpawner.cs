using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyship;
    public float repeatTime = 3.0f;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 1f, repeatTime); ;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime; 
        if(time>7.0f)
        {
            repeatTime--;
            time = 0;
        }
    }
    private void SpawnEnemies()
    {
        transform.position = new Vector3(Random.Range(-8, 8), 5.0f, 0);
        GameObject enemy = Instantiate(enemyship,transform.position,transform.rotation * Quaternion.Euler(0f,180f,0f));
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down;
    }
}
