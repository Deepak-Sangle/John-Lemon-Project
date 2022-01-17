using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool is_Detected;

    void OnTriggerEnter(Collider other){
        if(other.transform == player){
            is_Detected = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.transform == player){
            is_Detected = false;
        }
    }

    void Update(){
        if(is_Detected){
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycasthit;
            if(Physics.Raycast(ray, out raycasthit)){
                if(raycasthit.collider.transform == player){
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
    
}
