using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
   public Transform target;
   public float speed = 10f;

   void LateUpdate()
   {
       Vector3 handPos = target.transform.position;
       transform.position = Vector3.Lerp(transform.position, handPos, Time.deltaTime * speed);
       transform.rotation = Quaternion.Euler(target.transform.rotation.eulerAngles);
   }
}
