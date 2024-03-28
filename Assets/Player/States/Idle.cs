using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Idle : State
{

    private PlayerController controller;
    

    public Idle(PlayerController controller) : base("Idle")
    {  
    
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
       
       if(!controller.movementVector.isZero()){

          controller.stateMachine.ChangeState(controller.walkstate);
          return;
        }
       }

       public override void LateUpdated() {
        base.LateUpdated();
       }

       public override  void FixedUpdate() {
        base.FixedUpdate();
       }



}

