using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    public GameObject freeze;
    public GameObject shield;
    public GameObject speed;
    public GameObject coins;
    float currentHealth;
    public GameObject death;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = EnemyStats.health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // if(!col.gameObject.tag.Equals("Bullet"))
        // { 
        //     Instantiate(death, transform.position, Quaternion.identity);
        //     Destroy(col.gameObject);
        //     Destroy(gameObject);

        // }
        if (col.gameObject.tag == "PlayerTag")
        {
            if (col.gameObject.transform.Find("ShieldEffect").gameObject.activeInHierarchy != true)
            {
                PlayerStats.damagePlayer(1);
            }
        }
        if (col.gameObject.tag.Equals("Bullet") && !col.gameObject.tag.Equals("PlayerTag"))
        {
            currentHealth -= PlayerStats.damage;
            Destroy(col.gameObject);


        }
        if (currentHealth <= 0)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            int coinsDropped = Random.Range(2, 5);
            for (int i = 0; i < coinsDropped; i++)
            {
                Instantiate(coins, new Vector2(Random.Range(transform.position.x - 0.1f, transform.position.x + 0.1f), Random.Range(transform.position.y - 0.1f, transform.position.y + 0.1f)), Quaternion.identity);
            }
            if (Random.Range(1, 6) % 5 == 0)
            {
                int rand = Random.Range(1, 3);

                if (rand == 1)
                {
                    Instantiate(freeze, transform.position, Quaternion.identity);
                }
                if (rand == 2)
                {
                    Instantiate(shield, transform.position, Quaternion.identity);
                }
                // if (rand == 2)
                // {
                //     Instantiate(speed, transform.position, Quaternion.identity);
                // }

            }
            PlayerStats.addToHighscore(1);
            Destroy(gameObject);
        }

    }
}
