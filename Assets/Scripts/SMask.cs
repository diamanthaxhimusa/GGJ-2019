using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMask : MonoBehaviour {
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position, 20 * Time.deltaTime);
    }
}
