using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
    public GameObject gun, overlay, weaponCamera;
    public Animator anim;
    public Camera mainCamera;
    public float zoom = 15;
    public Ogre ogre;
    public Enemy enemy;


    private float normal;
    private bool isScoped;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Inputs()
    {
        // you press left click to shoot and right click to zoom in(only works offline)
        Shooting();
        if (overlay != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                isScoped = !isScoped;
                anim.SetBool("Scoped", isScoped);

                if (isScoped)
                {
                    StartCoroutine(Scoped());
                }
                else
                {
                    UnScoped();
                }
            }
        }

    }

    // Scopes in
    IEnumerator Scoped()
    {
        yield return new WaitForSeconds(0.15f);

        overlay.SetActive(true);
        weaponCamera.SetActive(false);
        normal = mainCamera.fieldOfView;
        mainCamera.fieldOfView = zoom;
    }

    // unscopes
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
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            // Sets the gun to recoil and plays a gunshot
            StartCoroutine(Recoil());
            // Makes a raycast from the camera to the mouse at all times
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.CompareTag("OgreHead"))
                {
                    Ogre.health -= 2;
                }

                if (hit.collider.CompareTag("OgreBody"))
                {
                    Ogre.health -= 1;
                }

                if (hit.collider.CompareTag("SkeleHead"))
                {
                    Enemy.health -= 2;
                }

                if (hit.collider.CompareTag("SkeleBody"))
                {
                    Enemy.health -= 1;
                }
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
