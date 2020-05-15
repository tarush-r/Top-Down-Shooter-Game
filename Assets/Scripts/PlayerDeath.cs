using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameover;
    public GameObject playerDeath;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

    //if (col.gameObject.tag.Equals("Enemy") && GameObject.Find("Player").transform.Find("ShieldEffect").gameObject.activeInHierarchy!=true)
      //  {
            if (PlayerStats.getHealth() <= 0)
            {
                gameover.SetActive(true);
                PlayerStats.currentGun="null";
                PlayerStats.currentScore=0;
                PlayerStats.firePower=0;
                PlayerStats.health=5;
                PlayerStats.coins=0;
                EnemyStats.moveSpeed = 2f;
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                //Destroy(col.gameObject);
                Destroy(gameObject);
            }
        //    PlayerStats.health -= 1f;

        //}
    }
}
