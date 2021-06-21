using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerNew : MonoBehaviour
{
    public float delaytimer = 1f;
    public Transform bspaw;
    private void Update()
    {
        delaytimer -= Time.deltaTime;
        GameObject enemyObj = ObjectPool_2.singleTon.GetSpawnObj("Enemy");
        if (enemyObj != null)
        {
            enemyObj.SetActive(true);
            enemyObj.transform.position = transform.position + new Vector3(Random.Range(-7.7f, 7.7f), 5.0f, 0);
            bspaw = enemyObj.transform;
            BulletSpawining(enemyObj.transform);
        }
    }
    void BulletSpawining(Transform bspawn)
    {

        if(delaytimer<=0)
        {
            print("lskdjfljsdklf");
            GameObject bulletTemp = ObjectPool_2.singleTon.GetSpawnObj("Bullet");
            bulletTemp.SetActive(true);
            bulletTemp.transform.position = bspawn.position;
            bulletTemp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime);
            delaytimer = 0.2f;
        }

    }
}
