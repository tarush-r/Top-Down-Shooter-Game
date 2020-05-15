using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDrop : MonoBehaviour
{
    public float delay=2f;
    float countdown;
    bool hasExploded=false;
    public float blastRadius=3f;
    // Start is called before the first frame update
    void Start()
    {
        countdown=delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown-=Time.deltaTime;
        if(countdown<=0 && !hasExploded)
        {
            hasExploded=true;
            Explode();
        }
    }

    void Explode()
    {
        Collider[] col=Physics.OverlapSphere(transform.position,blastRadius);
        foreach(Collider obj in col)
        {
            Rigidbody2D rb= obj.GetComponent<Rigidbody2D>();
            if(rb!=null)
            {
                print("null");
                Vector2 dir=(Vector2)rb.position-(Vector2)transform.position;
                print("Boomm");
                rb.AddForce(dir*5);
            }
            
            
        }
        Destroy(gameObject);

    }
}
