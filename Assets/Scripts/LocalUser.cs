using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalUser : MonoBehaviour
{
    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Assigns the inputs for the offline player
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        player.Movement(h, v);
    }
}
