using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerup : MonoBehaviour
{

    public GameObject PickupEffect;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerTag"))
        {

            
            if (PlayerStats.getHealth() < 5)
            {
                Instantiate(PickupEffect, GameObject.Find("Player").transform.position, Quaternion.identity);
                PlayerStats.setHealth(1);
                Destroy(gameObject);
            }
            
        }
    }

}
