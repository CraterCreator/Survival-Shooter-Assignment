using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
    public GameObject gun, overlay, weaponCamera;
    public Animator anim;
    public Camera mainCamera;
    public float zoom = 15;
    private float normal;

    private bool isScoped;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shooting();

        if(Input.GetMouseButtonDown(1))
        {
            isScoped = !isScoped;
            anim.SetBool("Scoped", isScoped);

            if(isScoped)
            {
                StartCoroutine(Scoped());
            }
            else
            {
                UnScoped();
            }
        }

    }

    IEnumerator Scoped()
    {
        yield return new WaitForSeconds(0.15f);

        overlay.SetActive(true);
        weaponCamera.SetActive(false);
        normal = mainCamera.fieldOfView;
        mainCamera.fieldOfView = zoom;
    }

    void UnScoped()
    {
        overlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normal;
    }

    void Shooting()
    {
        RaycastHit hit;

        // When you left click the gun shoots
        if (Input.GetMouseButtonDown(0))
        {
            // Sets the gun to recoil and plays a gunshot
            StartCoroutine(Recoil());
            // Makes a raycast from the camera to the mouse at all times
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000, Color.red);
            if (Physics.Raycast(ray, out hit, 1000))
            {

            }
        }
    }

    // Moves the gun up to -10 on the x then back down
    IEnumerator Recoil()
    {
        for (int i = 0; i < 10; i++)
        {
            gun.transform.Rotate(new Vector3(-1, 0, 0));
            yield return new WaitForEndOfFrame();

            if (i >= 9)
            {
                for (int e = 0; e > -10; e--)
                {
                    gun.transform.Rotate(new Vector3(1, 0, 0));
                    yield return new WaitForEndOfFrame();
                }

            }
        }

    }
}
