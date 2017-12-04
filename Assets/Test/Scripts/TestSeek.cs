using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSeek : Test
{
    public float minRange = 1f;
    public GameObject target;

    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public override void Check()
    {
        float distance = Vector3.Distance(enemy.transform.position, target.transform.position);

        if(minRange >= distance)
        {
            IntegrationTest.Pass(gameObject);
        }
        else
        {
            IntegrationTest.Fail(gameObject);
        }
    }

    public override void Debug()
    {

    }
}
