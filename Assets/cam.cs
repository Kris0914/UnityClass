using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{   public GameObject player;
    private Camera cam2;
    private float mouseSpeed = 500f;
    private float xrot;
    private float yrot;

    // Start is called before the first frame update
    private void Start()
    {
        cam2 = Camera.main;
        Cursor. lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        xrot -= mouseY;
        yrot -= mouseX;

        xrot = Mathf.Clamp(xrot, -70f, 70f);
        cam2.transform.rotation = Quaternion.Euler(xrot, yrot, 0);
        player .transform.rotation = Quaternion.Euler (0, yrot, 0);
    }
}
