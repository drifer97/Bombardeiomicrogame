using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class BoyanceScript : MonoBehaviour
{

   public float underwaterDrag = 3f;

   public float underwaterAngularDrag = 1f;

   public float airDrag = 0f;


   public float airAngularDrag = 0.05f;


   
   
   public float buoyancyForce = 1;
   
   private bool HasTouchedWater;
   
   
   private Rigidbody thisRigidbody;
   
    // Start is called before the first frame update
    void Awake() {
        thisRigidbody = GetComponent<Rigidbody>();
    }
    
        
    

    // Update is called once per frame
    void FixedUpdate()
    {
       
       float diffy = transform.position.y ;
       bool isUnderwater = diffy <0;
       if(isUnderwater){

         HasTouchedWater = true;
       }
       
       if(!HasTouchedWater){

        return;
       }
       
       
       if(isUnderwater){
       Vector3 vector = Vector3.up * buoyancyForce * -diffy;
        thisRigidbody.AddForce(vector, ForceMode.Acceleration);
       }
        thisRigidbody.drag = isUnderwater ? underwaterDrag : airDrag;
        thisRigidbody.angularDrag = isUnderwater ? underwaterAngularDrag : airAngularDrag;
    
    
    
    
    }
}
