using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject locate;

    private int waypointNum = 0;

    // Use this for initialization
    void Start()
    {
        locate = GameObject.Find("Target");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = locate.transform.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
