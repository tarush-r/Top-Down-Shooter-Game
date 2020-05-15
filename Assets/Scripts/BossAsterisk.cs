using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAsterisk : MonoBehaviour
{
    public Transform f1;
    public Transform f2;
    public Transform f3;
    public Transform f4;
    public Transform f5;
    public Transform f6;
    public Transform f7;
    public Transform f8;
    float bossHealth = 1000f;



    public GameObject bullet;
    private float fireRate = 1.5f;
    private float nextTimeToFire = 0f;
    private float bulletSpeed = 3f;
    public GameObject bossDeath;

    Vector2 center;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private Vector2 movementDirection;
    int rotationDirection = 1;
    Rigidbody2D rb;
    Transform healthbar;
    HealthBar bar;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        center = transform.position;
        latestDirectionChangeTime = 0f;
        healthbar=GameObject.Find("Canvas").transform.Find("Health Bar");
        healthbar.gameObject.SetActive(true); 
        bar=healthbar.gameObject.GetComponent<HealthBar>();
        print(bar);

    }


    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(center.x - 2.8f, center.x + 2.8f), Random.Range(center.y - 2.8f, center.y + 2.8f));
    }

    void Update()
    {
        bar.setBossHealth(bossHealth);
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            if (rotationDirection == 1)
            {
                rotationDirection = -1;
            }
            else
            {
                rotationDirection = 1;
            }
            calcuateNewMovementVector();
            // if((int)Random.Range(1, 3)==1)
            // {
            //     movementDirection=GameObject.FindGameObjectWithTag("PlayerTag").transform.position;
            // }


        }
        transform.position = Vector2.MoveTowards(transform.position, movementDirection, 2 * Time.deltaTime);
        transform.Rotate(new Vector3(0f, 0f, rotationDirection * 100f) * Time.deltaTime);
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (bossHealth <= 0)
        {
            Instantiate(bossDeath, transform.position, Quaternion.identity);
            PlayerStats.addToHighscore(100);
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        GameObject b1 = Instantiate(bullet, f1.position, f1.rotation);
        Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
        rb1.velocity = f1.up * bulletSpeed;
        Destroy(b1, 1.5f);


        GameObject b2 = Instantiate(bullet, f2.position, f2.rotation);
        Rigidbody2D rb2 = b2.GetComponent<Rigidbody2D>();
        rb2.velocity = f2.up * bulletSpeed;
        Destroy(b1, 1.5f);

        GameObject b3 = Instantiate(bullet, f3.position, f3.rotation);
        Rigidbody2D rb3 = b3.GetComponent<Rigidbody2D>();
        rb3.velocity = f3.up * bulletSpeed;
        Destroy(b1, 1.5f);

        GameObject b4 = Instantiate(bullet, f4.position, f4.rotation);
        Rigidbody2D rb4 = b4.GetComponent<Rigidbody2D>();
        rb4.velocity = f4.up * bulletSpeed;
        Destroy(b1, 1.5f);

        GameObject b5 = Instantiate(bullet, f5.position, f5.rotation);
        Rigidbody2D rb5 = b5.GetComponent<Rigidbody2D>();
        rb5.velocity = f5.up * bulletSpeed;
        Destroy(b1, 1.5f);

        GameObject b6 = Instantiate(bullet, f6.position, f6.rotation);
        Rigidbody2D rb6 = b6.GetComponent<Rigidbody2D>();
        rb6.velocity = f6.up * bulletSpeed;
        Destroy(b6, 1.5f);

        GameObject b7 = Instantiate(bullet, f7.position, f7.rotation);
        Rigidbody2D rb7 = b7.GetComponent<Rigidbody2D>();
        rb7.velocity = f7.up * bulletSpeed;
        Destroy(b7, 1.5f);

        GameObject b8 = Instantiate(bullet, f8.position, f8.rotation);
        Rigidbody2D rb8 = b8.GetComponent<Rigidbody2D>();
        rb8.velocity = f8.up * bulletSpeed;
        Destroy(b8, 1.5f);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerTag")
        {
            if (col.gameObject.transform.Find("ShieldEffect").gameObject.activeInHierarchy != true)
            {
                PlayerStats.damagePlayer(1);
            }

        }
        if (col.gameObject.tag == "Bullet")
        {
            bossHealth -= PlayerStats.damage;
        }

    }
}
