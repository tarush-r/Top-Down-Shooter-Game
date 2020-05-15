using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    int i = -1;
    string newstr;
    char[] ch = new char[4];
    public GameObject enemy;
    public GameObject enemy2;
    float randx, randy;
    int flag2=0;
    Vector2 spwanLocation;
    public bool lastRoom = false;
    public float spawnRate = 1f;
    float nextSpawn = 0f;
    private int enemyCount = 0;
    int flag = 0;
    public GameObject bossStar;
    int buildIndex;
    public GameObject bossAsterisk;

    public GameObject portal;
    GameObject currentBoss;
    public bool portalSpawnned=false;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount=0;
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        currentBoss=bossStar;
        for (int j = 0; j < 4; j++)
        {
            ch[j] = '0';
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && flag == 1 && enemyCount != 10)
        {
            if (lastRoom && flag2==0)
            {
                if(buildIndex==1)
                {
                    currentBoss = Instantiate(bossStar, transform.position, Quaternion.identity);
                }
                else if(buildIndex==2)
                {
                    currentBoss = Instantiate(bossAsterisk, transform.position, Quaternion.identity);
                }
                
                flag2=1;
            }
            if(!lastRoom)
            {
                nextSpawn = Time.time + spawnRate;

                randx = Random.Range(transform.position.x - 3, transform.position.x + 3);
                randy = Random.Range(transform.position.y - 3, transform.position.y + 3);
                spwanLocation = new Vector2(randx, randy);
                if(buildIndex==1)
                {
                    Instantiate(enemy, spwanLocation, Quaternion.identity);
                }
                else if(buildIndex==2)
                {
                    Instantiate(enemy2 , spwanLocation, Quaternion.identity);
                }
                
                enemyCount++;

            }


        }
        if(!portalSpawnned && lastRoom && currentBoss==null)
        {
            Instantiate(portal, transform.position, Quaternion.identity);
            portalSpawnned=true;
        }
        if (!GameObject.FindGameObjectWithTag("Enemy") && enemyCount == 10 && !GameObject.FindGameObjectWithTag("Enemy2"))
        {
            for (int x = 0; x <= i; x++)
            {
                newstr = ch[x] + "Door";
                transform.Find(newstr).gameObject.SetActive(false);
                Destroy(gameObject.GetComponent<TriggerScript>());
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
                transform.Find(newstr).gameObject.SetActive(true);
            }

        }
    }
}
