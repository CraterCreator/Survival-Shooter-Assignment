using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]

public class MouseLook : MonoBehaviour
{
    // Sets the 2 settings for the camera depending on what its doing
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    // Sets the rotation of the camera to rotate the player
    public RotationalAxis axis = RotationalAxis.MouseX;

    // Sets the speed the camera moves
    public float sensitivity = 15f;

    // Sets the limits the camera can look up and down
    public float minimumY = -60f;
    public float maximumY = 60f;

    // sets the rotation of the yaxis
    float rotationY = 0;

    // Update is called once per frame
    void Update()
    {
        // if time is normal everthing will run
        if (Time.timeScale == 1)
        {
            // Locks the cursor and makes it invisible
            Cursor.lockState = CursorLockMode.Locked;

            // if the enum is set to MouseX rotate only to the left and right moving the player with it
            if (axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            }
            // If the enum is set to MouseY rotate only up and down locking at the minimum and maximum heights
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivity;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }
}












