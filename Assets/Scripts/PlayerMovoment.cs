using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovoment : MonoBehaviour
{
    //PlayerStats stats = new PlayerStats();
    float moveSpeed = PlayerStats.moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject coinPickup;
    public Camera camera;
    Vector2 movement;
    Vector2 mousePos;
    // Update is called once per frame
    void Start()
    {
        Enemy2Stats.shoot=true;
        Enemy2Stats.rotate=true;
        EnemyStats.moveSpeed=2f;
    }
    void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        //var direction=Input.mousePosition-Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - camera.WorldToScreenPoint(transform.position);
        // var angle=Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        // transform.rotation=Quaternion.AngleAxis(angle, Vector3.forward);



    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * PlayerStats.moveSpeed * Time.fixedDeltaTime);
        //Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = transform.position - mousePos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        // Vector2 lookDirection = mousePos - rb.position;
        // float angle=Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg;
        // //rb.rotation=angle;
        // transform.rotation=Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Instantiate(coinPickup, col.transform.position, Quaternion.identity);
            PlayerStats.setCoin(1);
            Destroy(col.gameObject);

        }
    }
}
