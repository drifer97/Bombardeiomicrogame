using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    public float movementSpeed = 10f;

    public float jumpPower = 10;

    public float movementJumpFactor = 1f;
    

    [HideInInspector] public StateMachine stateMachine;
   
   
   [HideInInspector] public Idle idlestate;
    
    
    
    [HideInInspector] public walk walkstate;

    [HideInInspector] public Jump jumpState;


    
    [HideInInspector] public Dead deadState;

   [HideInInspector] public bool hasJumpInput;
    
    [HideInInspector] public bool isGrounded;
    
    
    
    [HideInInspector] public Vector2 movementVector;


    [HideInInspector] public Rigidbody thisRigidbody;
     public Collider thisCollider;
  [HideInInspector] public Animator thisAnimator;
     void Awake() {
        
        thisRigidbody = GetComponent<Rigidbody>();
        thisAnimator = GetComponent<Animator>();
        
    }
    void Start()
    {
       stateMachine = new StateMachine();
       idlestate = new Idle(this);
       walkstate = new walk(this);
       jumpState = new Jump(this);
       deadState = new Dead(this);
       stateMachine.ChangeState(idlestate);
         
        
        }

    // Update is called once per frame
           void Update(){
          if(GameManager.Instance.isGameOver){
               if(stateMachine.currentStateName != deadState.name){
                           stateMachine.ChangeState(deadState);

               }
          }
           bool isUp = Input.GetKey(KeyCode.W);
           bool isDown = Input.GetKey(KeyCode.S);
           bool isLeft = Input.GetKey(KeyCode.A);
           bool isRight = Input.GetKey(KeyCode.D);
           float Inputx = isRight ? 1 : isLeft ? -1 : 0;
           float Inputy = isUp ? 1 : isDown ? -1 : 0;
         
         movementVector = new Vector2 (Inputx,Inputy);

         hasJumpInput = Input.GetKey(KeyCode.Space);
           
         float velocity = thisRigidbody.velocity.magnitude;
          float velocityRate = velocity/movementSpeed;
        
         thisAnimator.SetFloat("fVelocity", velocityRate);
         
        
           DetectGround();

           

         stateMachine.Update();  
         }
    


         void LateUpdated() {
       stateMachine.LateUpdated();
       }
         

         void FixedUpdate() {
          stateMachine.FixedUpdate(); 
       
          }



          public Quaternion GetForward(){

           Camera camera = Camera.main;
           float eulerY = camera.transform.eulerAngles.y;
           return Quaternion.Euler(0,eulerY,0);
          }
         
        
              public void  RotateBodyToFaceInput() {
                
                Camera camera = Camera.main;

               if (movementVector.isZero())return;
                
                Vector3 inputVector = new Vector3 ( movementVector.x, 0, movementVector.y);
                Quaternion q1 = Quaternion.LookRotation(inputVector, Vector3.up);
                Quaternion  q2 =  Quaternion.Euler(0,camera.transform.eulerAngles.y,0);
                Quaternion toRotation = q1 * q2;
                Quaternion newRotation = Quaternion.LerpUnclamped(transform.rotation,toRotation, 0.5f);



                thisRigidbody.MoveRotation(newRotation);


              }
        
        private void DetectGround() {
        // Reset flag
        isGrounded = false;

        // Detect ground
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;
        Bounds bounds = thisCollider.bounds;
        float radius = bounds.size.x * 0.33f;
        float maxDistance = bounds.size.y * 0.33f;
        if(Physics.SphereCast(origin, radius, direction, out var hitInfo, maxDistance)) {
            GameObject hitObject = hitInfo.transform.gameObject;
            if(hitObject.CompareTag("Platform")) {
                isGrounded = true;
            }
        }
    }


   


}
         

        



    
