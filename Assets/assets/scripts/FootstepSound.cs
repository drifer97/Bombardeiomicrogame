using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepSound; // O som do passo
    

    void Update()
    {
         if(Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A)) || ((Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.D)))) {

             footstepSound.enabled = true;

         }
         else
         {
             footstepSound.enabled = false;
         }
    }

   
}
