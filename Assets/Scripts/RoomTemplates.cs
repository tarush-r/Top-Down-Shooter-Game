using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject closedRoom;
    public List<GameObject> rooms;
    public GameObject boss;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject portal;


    void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    rooms[i].GetComponent<TriggerScript>().lastRoom=true;
                    //Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    //GameObject spawnedPortal = Instantiate(portal, rooms[i].transform.position, Quaternion.identity);
                    //spawnedPortal.SetActive(false);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

}
