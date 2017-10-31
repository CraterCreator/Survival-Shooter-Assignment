using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Vector3 towerHeight;
    // Use this for initialization
    void Start()
    {
        towerHeight = transform.localScale;
        towerHeight.y = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = towerHeight;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            Destroy(col.gameObject);
            towerHeight.y -= 0.1f;
        }

        if (col.tag == "Ogre")
        {
            Destroy(col.gameObject);
            towerHeight.y -= 0.2f;
        }
    }
}
