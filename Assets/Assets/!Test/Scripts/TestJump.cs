using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

[RequireComponent(typeof(PlayerController))]
public class TestJump : Test
{
    [Header("Test Parameters")]
    public float minHeight = 1f;

    private PlayerController player;
    private float originalY;
    private float jumpApex;

    void Start()
    {
        player = GetComponent<PlayerController>();
        originalY = transform.position.y;
    }

    public override void Simulate()
    {
        // Simulate jump mechanic
        player.Jump();
    }

    public override void Check()
    {
        // Check the players current position
        float playerY = player.transform.position.y;
        float height = playerY - originalY;
        // Getthe highest point that player jumps to (the apex)
        if(height > jumpApex)
        {
            jumpApex = height;
        }

        // Check if the Y went up from original position
        if(jumpApex > minHeight)
        {
            // The test has succeeded
            IntegrationTest.Pass(gameObject);
        }
    }

    public override void Debug()
    {
        GizmosGL.color = Color.red;
        // Draw the min height the player needs to jump to
        Vector3 originalPos = new Vector3(0, originalY, 0);
        Vector3 playerPos = transform.position;

        GizmosGL.AddLine(originalPos, originalPos + Vector3.up * minHeight);

        GizmosGL.AddLine(originalPos, playerPos, 0.35f, 0.35f);
    }
}
