using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float moveSpeed = 4f; 
    //public static int limit = 20;
    public static float health = 5f;
    public static float currentScore=0f;

    public static float firePower=0f;

    public static float fireRate=1f;
    public static float bulletSpeed=1f;
    public static float damage=0f;
    public static string currentGun; 
    public static int coins=0;

    public static void damagePlayer(int hitpoint)
    {
        health=health-hitpoint;
    }

    public static void setCoin(int coinsPicked)
    {
        coins+=coinsPicked;
    }

    public static string getCoins()
    {
        return coins.ToString();
    }

    public static float getHealth()
    {
        return health;
    }

    public static void setHealth(float h)
    {
        health+=h;
    }

    public static void addToHighscore(float points)
    {
        currentScore+=points;
    }
}
