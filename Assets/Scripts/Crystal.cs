using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public bool pickupAllowed;

    void Update() {
        if (pickupAllowed && Input.GetKeyDown(KeyCode.E)) {
            PickUp();
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pickupAllowed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pickupAllowed = false;
        }
    }

    void PickUp() {
        Destroy(gameObject);
    }
}
