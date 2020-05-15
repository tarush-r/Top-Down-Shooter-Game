using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public GameObject PickupEffect;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerTag"))
        {

            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        //Instantiate(shieldEffect, GameObject.Find("Player").transform.position, GameObject.Find("Player").transform.rotation);
        //shieldEffect.GetComponent<SpriteRenderer>().enabled = true;
        Instantiate(PickupEffect, GameObject.Find("Player").transform.position, Quaternion.identity);
        GameObject.Find("Player").transform.Find("ShieldEffect").gameObject.SetActive(true);

        //GameObject.Find("ShieldEffect").transform.SetParent(GameObject.Find("Player").transform);
        //float health = PlayerStats.health;
        //GameObject.Find("Player").GetComponent<PolygonCollider2D>().enabled=false; 
        //PlayerStats.health = 10000f;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(10);
        //PlayerStats.health = health;
        //GameObject.Find("Player").GetComponent<PolygonCollider2D>().enabled=true;
        GameObject.Find("Player").transform.Find("ShieldEffect").gameObject.SetActive(false);
        //player.transform.localScale /= 0.5f;
        //PlayerStats.moveSpeed/=2;
        //Debug.Log("Picked up");
        Destroy(gameObject);
    }
}
