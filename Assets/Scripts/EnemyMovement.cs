using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public GameObject player;
    private Rigidbody2D rb;
    //public float moveSpeed = EnemyStats.moveSpeed;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("PlayerTag"))
        {
            Vector3 playerDirection = GameObject.Find("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            playerDirection.Normalize();
            movement = playerDirection;
        }
        else
        {
            Destroy(GameObject.Find("EnemySpawner"));
            EnemyStats.moveSpeed=0f;
        }
        
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 playerDirection)
    {
        rb.MovePosition((Vector2)transform.position + (playerDirection * EnemyStats.moveSpeed * Time.deltaTime));
    }
}
