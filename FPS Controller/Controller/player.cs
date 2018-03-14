using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float sensitivity = 3.0f;
    public float smoothing = 1.0f; 
    [Space]
    public float speed = 8.0f;

    Vector2 mouseLook; 
    Vector2 smoothed;
    GameObject parent;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        parent = this.transform.parent.gameObject;
    }

    void Update()
    {
        Look();
        Move();

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Look()
    {
        var mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseMovement = Vector2.Scale(mouseMovement, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothed.x = Mathf.Lerp(smoothed.x, mouseMovement.x, 1f / smoothing);
        smoothed.y = Mathf.Lerp(smoothed.y, mouseMovement.y, 1f / smoothing);
        mouseLook += smoothed;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        parent.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, parent.transform.up);
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        parent.transform.Translate(x, 0, z);
    }
}
