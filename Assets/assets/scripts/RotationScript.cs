using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
   
   public float  degreePerSecond = 10;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       float stepY = degreePerSecond * Time.deltaTime;
        transform.Rotate(0,stepY,0);
    }
}
