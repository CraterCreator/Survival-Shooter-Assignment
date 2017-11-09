using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // if the tower gets destroyed return to main menu
        if (towerHeight.y <= 0.2f)
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
