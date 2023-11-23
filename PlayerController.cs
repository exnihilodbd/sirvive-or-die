using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController ch_controller;
    Transform meshPlayer;
    float inputX, inputZ;
    // for mobile
    public FixedJoystick joystick;
    Vector3 v_move;
    float moveSpeed;
    float gravity;
    public Animator _animator;
    
    public void Start()
    {
         
        GameObject tmpPlayer = GameObject.FindGameObjectWithTag("Player");
        meshPlayer = tmpPlayer.transform.GetChild(0);
        ch_controller = tmpPlayer.GetComponent<CharacterController>();
        moveSpeed = 0.1f;
        gravity = 0.6f;
    }
    public void Update()
    {
       // inputX = Input.GetAxis("Horizontal");
      //  inputZ = Input.GetAxis("Vertical");
        // for mobile
        inputX = joystick.Horizontal;
        inputZ = joystick.Vertical;
        if (inputX == 0 && inputZ == 0)
        {
            _animator.SetBool("move", false);
        }
        else
            _animator.SetBool("move", true);

    }
    private void FixedUpdate()
    {
        if(ch_controller.isGrounded)
        {
            v_move.y = 0f;
        }
        else
            v_move.y -= gravity * Time.deltaTime;
        v_move = new Vector3(inputX * moveSpeed,v_move.y,inputZ * moveSpeed);
        ch_controller.Move(v_move);
        if (v_move.x != 0 || v_move.z != 0)
        {
            Vector3 lookDir = new Vector3(v_move.x, 0, v_move.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
