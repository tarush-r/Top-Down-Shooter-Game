using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerup : MonoBehaviour
{
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
        //PlayerStats stats =player.GetComponent<PlayerStats>();
        //PlayerStats.moveSpeed *= 2;
        //player.transform.localScale *= 0.5f;
        Instantiate(PickupEffect, GameObject.Find("Player").transform.position, Quaternion.identity);
        EnemyStats.moveSpeed = 0f;
        Enemy2Stats.shoot=false;
        Enemy2Stats.rotate=false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5);
        //print("after");
        Enemy2Stats.shoot=true;
        Enemy2Stats.rotate=true;
        EnemyStats.moveSpeed = 2f;
        //player.transform.localScale /= 0.5f;
        //PlayerStats.moveSpeed/=2;
        //Debug.Log("Picked up");
        Destroy(gameObject);
    }
}
