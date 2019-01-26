using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
 Vector3 mouse_pos;
 Vector3 object_pos;
 float angle;
 
 void Update ()
 {
     mouse_pos = Input.mousePosition;
     mouse_pos.z = 5.23f; //The distance between the camera and object
     object_pos = Camera.main.WorldToScreenPoint(transform.position);
     mouse_pos.x = mouse_pos.x - object_pos.x;
     mouse_pos.y = mouse_pos.y - object_pos.y;
     angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
 }
}
