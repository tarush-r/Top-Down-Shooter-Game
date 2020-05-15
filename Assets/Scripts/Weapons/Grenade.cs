using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject pistol;
    public GameObject machinegun;
    public GameObject sniper;
    public GameObject grenade;
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
        else
        {

        }
        PlayerStats.fireRate = 0.3f;
        PlayerStats.firePower = 1f;
        PlayerStats.bulletSpeed=5f; 
        PlayerStats.damage=50f;
        PlayerStats.currentGun = "grenade";
        Destroy(gameObject);
    }
}
