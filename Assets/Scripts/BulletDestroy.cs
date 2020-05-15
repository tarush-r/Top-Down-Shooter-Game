using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        // if(col.gameObject.tag=="Wall")
        // {
        //     Destroy(gameObject);
        // }
        if (col.gameObject.tag == "PlayerTag")
        {
            if (col.gameObject.transform.Find("ShieldEffect").gameObject.activeInHierarchy != true)
            {
                PlayerStats.damagePlayer(1);
            }
        }
        Destroy(gameObject);

    }
}
