using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : ScriptableObject
{
    public bool pickable = false;

    void Update() {
        if(pickable) {
            Destroy(this);
        }
    }
}
