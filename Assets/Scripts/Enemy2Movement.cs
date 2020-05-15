using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject death;

    public GameObject coins;
    public GameObject shield;
    public GameObject freeze;

    float currentHealth;
    //Gun gun = new Gun(0.5f, 5, 0.35f, 12f, 1, "Small Shotgun");

    public float bulletForce = .0002f;
    private float nextFire = 0f;
    private float fireRate = 1.5f;
    public float nextTimeToFire = 0f;

    //public GameObject player;
    private Rigidbody2D rb;
    //public float moveSpeed = EnemyStats.moveSpeed;
    GameObject player;
    private Vector2 movement;
    Vector2 direction;
    Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Enemy2Stats.health;
        rb = this.GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("PlayerTag"))
        {
            player = GameObject.FindWithTag("PlayerTag").gameObject;
            target = new Vector2(player.transform.position.x, player.transform.position.y);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerStats.addToHighscore(1);
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
            Destroy(gameObject);
        }
        //var direction=Input.mousePosition-Camera.main.WorldToScreenPoint(transform.position);
        if (GameObject.FindWithTag("PlayerTag") && Enemy2Stats.rotate)
        {
            direction = Camera.main.WorldToScreenPoint(player.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
        }


        if (Time.time >= nextTimeToFire && Enemy2Stats.shoot)
        {
            nextTimeToFire = Time.time + 1f / Enemy2Stats.fireRate;
            Shoot();
        }

    }
    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("PlayerTag"))
        {
            Vector3 playerDirection = GameObject.Find("Player").transform.position - transform.position;
            // float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            playerDirection.Normalize();
            movement = playerDirection;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            if (Vector2.Distance(player.transform.position, transform.position) == 2)
            {
                transform.position = this.transform.position;

            }
            if (Vector2.Distance(player.transform.position, transform.position) < 2)
            {
                //transform.position = Vector2.MoveTowards(transform.position, movement, -EnemyStats.moveSpeed* Time.deltaTime);
                rb.MovePosition((Vector2)transform.position + (movement * -EnemyStats.moveSpeed * Time.deltaTime));
            }
            else
            {
                moveCharacter(movement);
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            Destroy(GameObject.Find("EnemySpawner"));
            EnemyStats.moveSpeed = 0f;
        }
    }

    void moveCharacter(Vector2 playerDirection)
    {
        // if((player.transform.position.x-transform.position.x)>1 && (player.transform.position.y-transform.position.y)>1)

        //transform.position = Vector2.MoveTowards(transform.position, playerDirection, EnemyStats.moveSpeed * Time.deltaTime);
        rb.MovePosition((Vector2)transform.position + (playerDirection * EnemyStats.moveSpeed * Time.deltaTime));

    }
    void Shoot()
    {
        for (int i = 0; i < Enemy2Stats.firePower; i++)
        {
            // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            // //rb.MovePosition();
            // //bullet.transform.position= Vector2.MoveTowards(bullet.transform.position, target, 20*Time.deltaTime);
            // Destroy(bullet, 1.5f);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            rb.velocity = transform.TransformDirection(Vector2.up * Enemy2Stats.bulletSpeed);
            Destroy(bullet, 5f);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerTag" && !col.transform.Find("ShieldEffect").gameObject.activeInHierarchy)
        {
            print("sdvsfrbgeagae");
            PlayerStats.damagePlayer(1);
        }
        if (col.gameObject.tag == "Bullet")
        {
            currentHealth -= PlayerStats.damage;
        }
    }
}
