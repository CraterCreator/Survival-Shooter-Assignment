using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpeed : Test
{
    public float minDis = 8;
    public Player player;

    private float oldPosZ;

    void Start()
    {
        oldPosZ = transform.position.z;
    }

    public override void Simulate()
    {
        player.Movement(0, 1);
    }

    public override void Check()
    {
        float newPosZ = transform.position.z;
        float dis = newPosZ - oldPosZ;

        if(dis >= minDis)
        {
            IntegrationTest.Pass(gameObject);
        }
    }

}
