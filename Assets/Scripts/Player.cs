using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    // Sets to total movespeed for all directions
    public float moveSpeed = 2f;
    // Sets up audio clips to be played
    public AudioClip gunShot;
    // Is the vector3 that creates movement
    private Vector3 moveDirection = Vector3.zero;
    // Calls the audio source already on the player
    private AudioSource source;
    // Sets to character controller to controller
    private CharacterController controller;
    #endregion

    void Awake()
    {
        // As the game starts sets time to normal and locks the mouse
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        // Gets AudioSource for source
        source = GetComponent<AudioSource>();
        // Get the CharacterController
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // if time is normal everthing will run
        if (Time.timeScale == 1)
        {
            #region Movement

            // Inputs a,d keys for horizontal movement and w,s keys for vertical movement
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            // Times's the movement by the movespeed
            moveDirection *= moveSpeed;

            // Inputs the movement to the character controller
            controller.Move(moveDirection * Time.deltaTime);

            moveDirection.y -= -9.81f * Time.deltaTime;
            #endregion
        }

    }
}
