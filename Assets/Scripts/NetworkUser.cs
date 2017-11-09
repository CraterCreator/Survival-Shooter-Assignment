using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkUser : NetworkBehaviour
{
    public Camera cam;
    public AudioListener aLister;

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        if (!isLocalPlayer)
        {
            cam.enabled = false;
            aLister.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Assign the inputs to the player
        if (isLocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            player.Movement(h, v);
        }
    }
}
