using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float movespeed;
    public float walkspeed;
    private Vector3 moveDirection;
    private CharacterController controller;
    private AudioSource footsteps;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anime = GetComponent<Animator>();
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        float vert = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0,0,vert);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *=walkspeed;
        controller.Move(moveDirection*Time.deltaTime);
        float iswalking;
        if(vert==0){
            iswalking = 0f;
        }
        else{
            iswalking = 1.0f;
        }
        anime.SetFloat("IsWalking", iswalking);
        if(iswalking!=0){
            if(!footsteps.isPlaying){
                footsteps.Play();
            }
        }
        else{
            footsteps.Stop();
        }
    }
}
