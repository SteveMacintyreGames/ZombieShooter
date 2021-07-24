using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Camera camera;
    [SerializeField] private GameObject _bloodSplat;
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
            if(Physics.Raycast(rayOrigin, out hit, Mathf.Infinity, 1 << 9 | 1 << 0))
            {
                Debug.Log("You just shot" + hit.transform.name);
                if(hit.transform.tag == "Enemy")
                {
                    Health health = hit.transform.GetComponent<Health>();
                    if (health != null)
                    {
                        GameObject bloodSplat = Instantiate(_bloodSplat, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy (bloodSplat, .75f);
                        health.Damage(50);
                    }
                }
                
            }
            else
            {
                Debug.Log("You missed!");
            }
        }
    }
}
