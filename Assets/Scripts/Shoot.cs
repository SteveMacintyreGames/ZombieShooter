using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Camera camera;
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
       FireGun();        
    }

    private void FireGun()
    {
        Vector3 centerOfScreen = new Vector3(0.5f,0.5f,0f);
        Ray rayOrigin = camera.ViewportPointToRay(centerOfScreen);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(rayOrigin, out hit))
            {
                Debug.Log("You just shot" + hit.transform.name);
            }
            else
            {
                Debug.Log("You missed!");
            }
        }
    }
}
