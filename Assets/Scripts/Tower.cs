using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static Vector3 towerHeight;
    // Use this for initialization
    void Start()
    {
        towerHeight = transform.localScale;
        towerHeight.y = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = towerHeight;
        if (towerHeight.y <= 0.2f)
        {
            Time.timeScale = 0;
        }
    }
}
