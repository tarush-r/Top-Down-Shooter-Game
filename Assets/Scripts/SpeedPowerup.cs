using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject speedEffect;
    // Start is called before the first frame update
    public GameObject PickupEffect;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerTag"))
        {

            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(PickupEffect, GameObject.Find("Player").transform.position, Quaternion.identity);
        //Instantiate(shieldEffect, GameObject.Find("Player").transform.position, GameObject.Find("Player").transform.rotation);
        //shieldEffect.GetComponent<SpriteRenderer>().enabled = true;
        

        //GameObject.Find("ShieldEffect").transform.SetParent(GameObject.Find("Player").transform);
        
        PlayerStats.moveSpeed = 10f;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(10);
        PlayerStats.moveSpeed = 4f;
        //player.transform.localScale /= 0.5f;
        //PlayerStats.moveSpeed/=2;
        //Debug.Log("Picked up");
        Destroy(gameObject);
    }
}
