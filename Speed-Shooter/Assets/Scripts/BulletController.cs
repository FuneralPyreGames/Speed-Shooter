using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= -9 || gameObject.transform.position.x >= 9 || gameObject.transform.position.y <= -5 || gameObject.transform.position.y >= 5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision){

    }
}
