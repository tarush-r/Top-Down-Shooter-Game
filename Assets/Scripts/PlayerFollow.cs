using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float smoothSpeed = 1f;
    private Vector3 offset = new Vector3(0, 0, (float)(-5.5));

    void FixedUpdate()
    {
        if (GameObject.FindWithTag("PlayerTag"))
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }

    }
}
