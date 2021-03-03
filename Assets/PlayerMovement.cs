using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField]
    float xmin, xmax;
    public GameObject bullet;
    public float offset;
    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yposition = transform.position.y;
        yposition = -4.3f;
        transform.Translate(new Vector3(xInput, transform.position.y, 0) * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), yposition, 0);
        FireBullet();
    }
    private void FireBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bullet.transform.position = new Vector3(transform.position.x,transform.position.y + offset,0);
            Instantiate(bullet, bullet.transform.position, Quaternion.identity);
        }
    }
}
