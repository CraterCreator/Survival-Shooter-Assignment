using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : MonoBehaviour
{
    public int health = 3;
    public float moveSpeed = 5;
    public GameObject locate;

    private int waypointNum = 0;
    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        health = 3;
        rigid = GetComponent<Rigidbody>();
        locate = GameObject.Find("Target");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = locate.transform.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (health <= 0)
        {
            rigid.velocity = new Vector3(0, transform.position.y * 60, 0);
            Invoke("BlastOff", 2);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Tower")
        {
            Tower.towerHeight.y -= 0.2f;
            Destroy(gameObject);
        }
    }
    void BlastOff()
    {
            Destroy(gameObject);
    }
}
