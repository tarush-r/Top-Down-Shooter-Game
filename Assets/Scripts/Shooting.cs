using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    float delay = 2f;
    float countdown;
    // public GameObject player;
    //Gun gun = new Gun(0.5f, 5, 0.35f, 12f, 1, "Small Shotgun");

    public float bulletForce = 50000f;
    private float nextFire = 0f;
    private float fireRate = 100f;
    public float nextTimeToFire = 0f;

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && PlayerStats.currentGun!="grenade")
        {
            nextTimeToFire = Time.time + 1f / PlayerStats.fireRate;
            Shoot();
        }
        else
        {
            transform.Find("FireEffect").gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        for (int i = 0; i < PlayerStats.firePower; i++)
        {
            transform.Find("FireEffect").gameObject.SetActive(true);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            rb.velocity = transform.TransformDirection(Vector2.up * PlayerStats.bulletSpeed);
            Destroy(bullet, 1.5f);
        }

    }



}
