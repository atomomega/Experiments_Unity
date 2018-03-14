using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour {

    public Transform parent;
    public Transform camera;
    [Space]
    public GameObject viewmodel;
    [Space]
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    [Space]
    public float damage = 10f;

    RaycastHit raycast;

	void Start () {
        GameObject.Instantiate(viewmodel, position, Quaternion.Euler(rotation), parent);
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            PrimaryFire();
        }

	}

    void PrimaryFire()
    {
        Vector3 dir = new Vector3(parent.eulerAngles.x, camera.eulerAngles.y, 0f);
        if(Physics.Raycast(parent.position, dir, out raycast))
        {
            Debug.Log("Hit An Object: " + raycast.transform.name);   
        }

    }
}
