using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject pistol;
    public GameObject machinegun;
    public GameObject sniper;
    public GameObject machinegun2;
    public GameObject sniper2;
    bool pickupAllowed;
    void Start()
    {
        pickupAllowed = false;
    }
    void Update()
    {
        if (pickupAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerTag")
        {
            pickupAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerTag")
        {
            pickupAllowed = false;
        }
    }

    void Pickup()
    {
        if (PlayerStats.currentGun == "sniper")
        {
            Instantiate(sniper, transform.position, Quaternion.identity);
        }
        else if (PlayerStats.currentGun == "machinegun")
        {
            Instantiate(machinegun, transform.position, Quaternion.identity);
        }
        else if (PlayerStats.currentGun == "pistol")
        {
            Instantiate(pistol, transform.position, Quaternion.identity);
        }
        else if(PlayerStats.currentGun == "machinegun2")
        {
            Instantiate(machinegun2, transform.position, Quaternion.identity);
        }
        else if (PlayerStats.currentGun == "sniper2")
        {
            Instantiate(sniper2, transform.position, Quaternion.identity);
        }
        PlayerStats.fireRate = 2f;
        PlayerStats.firePower = 1f;
        PlayerStats.bulletSpeed=8f;
        PlayerStats.damage=10f;
        PlayerStats.currentGun = "pistol";
        Destroy(gameObject);
    }
}
