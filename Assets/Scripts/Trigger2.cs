using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    int i = -1;
    string newstr;
    char[] ch = new char[4];
    public GameObject enemy;
    public GameObject enemy2;
    float randx, randy;
    int flag2 = 0;
    Vector2 spwanLocation;
    public float spawnRate = 1f;
    float nextSpawn = 0f;
    private int enemyCount = 0;
    int flag = 0;
    public GameObject bossStar;
    int buildIndex;
    bool asteriskSpawned = false;
    public GameObject bossAsterisk;
    GameObject currentBoss;
    bool starSpawned = false;

    void Start()
    {
        enemyCount = 0;
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        currentBoss = bossStar;
        for (int j = 0; j < 4; j++)
        {
            ch[j] = '0';
        }
    }

    void Update()
    {
        if (newstr == "LDoor" && !starSpawned && flag == 1)
        {
            Instantiate(bossStar, transform.position, Quaternion.identity);
            starSpawned = true;
        }
        if (newstr == "BDoor" && !asteriskSpawned && flag == 1)
        {
            Instantiate(bossAsterisk, transform.position, Quaternion.identity);
            asteriskSpawned = true;
        }
        if (newstr == "RDoor" || newstr=="TDoor")
        {
            if (Time.time > nextSpawn && flag == 1 && enemyCount != 10)
            {
                    nextSpawn = Time.time + spawnRate;

                    randx = Random.Range(transform.position.x - 3, transform.position.x + 3);
                    randy = Random.Range(transform.position.y - 3, transform.position.y + 3);
                    spwanLocation = new Vector2(randx, randy);
                    if (newstr == "RDoor")
                    {
                        Instantiate(enemy, spwanLocation, Quaternion.identity);
                    }
                    else if (newstr == "TDoor")
                    {
                        Instantiate(enemy2, spwanLocation, Quaternion.identity);
                    }

                    enemyCount++;
            }
        }
        if (!GameObject.FindGameObjectWithTag("Enemy") && enemyCount == 10 && !GameObject.FindGameObjectWithTag("Enemy2") && (newstr=="LDoor" || newstr=="LDoor"))
        {
            for (int x = 0; x <= i; x++)
            {
                newstr = ch[x] + "Door";
                transform.Find(newstr).gameObject.SetActive(false);
            }
        }
        if (!GameObject.FindGameObjectWithTag("star") && !GameObject.FindGameObjectWithTag("asterisk") && !GameObject.FindGameObjectWithTag("Enemy")  && !GameObject.FindGameObjectWithTag("Enemy2"))
        {
            for (int x = 0; x <= i; x++)
            {
                newstr = ch[x] + "Door";
                print(newstr);
                transform.Find(newstr).gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string name = transform.name;
        if (col.gameObject.tag == "PlayerTag")
        {
            flag = 1;

            foreach (char c in name)
            {
                if (c == 'T' || c == 'B' || c == 'L' || c == 'R')
                {
                    i++;
                    ch[i] = c;
                }
            }
            for (int x = 0; x <= i; x++)
            {
                newstr = ch[x] + "Door";
                print(newstr);
                transform.Find(newstr).gameObject.SetActive(true);
            }

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerTag")
        {
            starSpawned = false;
            asteriskSpawned = false;
            enemyCount=0;
            flag = 0;
        }
    }

}
