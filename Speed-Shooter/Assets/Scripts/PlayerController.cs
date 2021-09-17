using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 movement;
    public GameObject Gun;
    public GameObject Circle;
    public float Speed = 15f;
    public Transform gun;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }
    
    void FixedUpdate()
    {
        transform.RotateAround(Circle.transform.position, Vector3.back, movement.x * Speed * Time.deltaTime);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gun.up * bulletForce, ForceMode2D.Impulse);
    }
}