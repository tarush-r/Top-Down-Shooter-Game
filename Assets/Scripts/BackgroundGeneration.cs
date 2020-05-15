using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{

    public GameObject cube;
    int distance=4;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        x=cube.transform.position.x;
        y=cube.transform.position.y;
        z=cube.transform.position.z;
        //GameObject[] cubeLine = new GameObject[10];
        for(int i=0;i<100;i++)
        {
            for(int j=0;j<100;j++)
            {
                //Instantiate(cube, new Vector3(Random.Range(x+distance-1, x+distance+1), y, z), Quaternion.identity);
                Instantiate(cube, new Vector3(Random.Range(x+distance-1, x+distance+1), Random.Range(y-1, y+1), Random.Range(z-1, z+1)), Quaternion.identity);
                Instantiate(cube, new Vector3(Random.Range(x+distance-1, x+distance+1), Random.Range(y-1, y+1), Random.Range(z+2, z+4)), Quaternion.identity);
                Instantiate(cube, new Vector3(Random.Range(x+distance-1, x+distance+1), Random.Range(y-1, y+1), Random.Range(z+5, z+7)), Quaternion.identity);

                
                x+=distance;
            }
            x=cube.transform.position.x;;
            y+=distance;
            
            //y+=distance;

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
