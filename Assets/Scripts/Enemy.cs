using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int health = 3;
    public float moveSpeed = 10;
    public GameObject locate;

    private int waypointNum = 0;
    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        health = 2;
        rigid = GetComponent<Rigidbody>();
        locate = GameObject.Find("Target");
    }
    // Update is called once per frame
    void Update()
    {
        // Moves towards the tower
        Vector3 dir = locate.transform.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        // If out of health fly off then destroy
        if (health <= 0)
        {
            rigid.velocity = new Vector3(0, transform.position.y * 60, 0);
            Invoke("BlastOff", 2);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Once hitting the tower it falls a little
        if (col.gameObject.tag == "Tower")
        {
            Tower.towerHeight.y -= 0.1f;
            Destroy(gameObject);
        }
    }
    void BlastOff()
    {
        Destroy(gameObject);
    }
}
