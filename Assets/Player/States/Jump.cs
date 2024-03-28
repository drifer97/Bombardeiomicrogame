using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class Jump : State
{

    private PlayerController controller;
    
  private bool hasJumped ;

  private float cooldown;
    public Jump(PlayerController controller) : base("Jump")
    {  
    
      this.controller = controller;
    
    
    
    }

    public override void Enter() {
            base.Enter();

           hasJumped = false;
           cooldown  = 0.5f;



           controller.thisAnimator.SetBool("Bjumping", true);
             
         }

       public override void Exit() {
        base.Exit();


        controller.thisAnimator.SetBool("Bjumping", false);
       }

       public override void Update() {
        base.Update();

       cooldown -= Time.deltaTime;
       
       
        if(hasJumped && controller.isGrounded && cooldown <= 0){
              controller.stateMachine.ChangeState(controller.idlestate);
              return;
        }
       
       }

       public override void LateUpdated() {
        base.LateUpdated();
       }

       public override  void FixedUpdate() {
        base.FixedUpdate();

        if(!hasJumped){
           hasJumped = true;
           applyImpulse();

        }
       
       Vector3 WalkVector = new Vector3 (controller.movementVector.x, 0, controller.movementVector.y);
         Camera camera = Camera.main;
        WalkVector =  controller.GetForward()* WalkVector;
         WalkVector *= controller.movementSpeed *controller.movementJumpFactor ; 
         
         
         
         controller.thisRigidbody.AddForce(WalkVector,ForceMode.Force);
         controller.RotateBodyToFaceInput();
         }
       
       
       
       
       
       
       

        private void  applyImpulse(){
      
        Vector3 forceVector = Vector3.up * controller.jumpPower;
        controller.thisRigidbody.AddForce(forceVector,ForceMode.Impulse);
   

        }

}