using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//public class stateMachine : MonoBehaviour
//{
    // Start is called before the first frame update
  //  void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
//}



public class StateMachine{

  private State currentState;

  public string currentStateName {get;private set;}

   public void Update(){

     currentState?.Update();
   }

   public void LateUpdated(){


      currentState?.LateUpdated();

   }

   public void FixedUpdate(){

    currentState?.FixedUpdate();
   }





 public void ChangeState(State newState) {
    

   currentState?.Exit();
    currentState = newState;
    currentStateName = newState.name;
    newState.Enter();

 }
}