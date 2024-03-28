using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class walk : State
{
    
    private PlayerController controller;

    

    public walk(PlayerController controller) : base("walk"){
                 this.controller = controller;

    }


    
  public override void Enter() {
            base.Enter();
          
           

         }

       public override void Exit() {
        base.Exit();
       }

       public override void Update() {
            base.Update();

              if(controller.hasJumpInput){

            controller.stateMachine.ChangeState(controller.jumpState);
            return;
        }

         if(controller.movementVector.isZero()){

            controller.stateMachine.ChangeState(controller.idlestate);
            return;
        }

       }

       public override void LateUpdated() {
        base.LateUpdated();
       }

       public override  void FixedUpdate() {
        base.FixedUpdate(); 
        
        
         Vector3 WalkVector = new Vector3 (controller.movementVector.x, 0, controller.movementVector.y);
         Camera camera = Camera.main;
        WalkVector =  controller.GetForward()* WalkVector;
         WalkVector *= controller.movementSpeed ; 
         
         
         
         controller.thisRigidbody.AddForce(WalkVector,ForceMode.Force);
         controller.RotateBodyToFaceInput();
         
            
         
         }

}