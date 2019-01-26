using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject crystal;

    int lights;

    void Start()
    {
        lights = GameManager.Instance.Lights;
        print(lights);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && lights >= 0) {
            Instantiate(crystal, transform.position, Quaternion.identity);
            lights--;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Door")) {
            if (lights == 5) {
                Destroy(other.gameObject);
            } else {
                print("You need More lights");
            }
        }
    }
}
