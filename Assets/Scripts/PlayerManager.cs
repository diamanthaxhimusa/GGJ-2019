using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject crystal;
    public GameObject lightOfCrystals;

    void Start()
    {
        print(GameManager.Instance.lights);
    }

    // Update is called once per frame
    void Update()
    {
        Transform LightCrystals = gameObject.transform.Find("LightCrystals");
        if (LightCrystals != null) {
            if (GameManager.Instance.lights == 0) {
                LightCrystals.gameObject.SetActive(false);
            } else {
                LightCrystals.gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && GameManager.Instance.lights > 0) {
            Instantiate(crystal, transform.position, Quaternion.identity);
            GameManager.Instance.lights--;
            float scale = lightOfCrystals.transform.localScale.x;
            lightOfCrystals.transform.localScale = new Vector3(scale - 0.3f, scale - 0.3f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Door")) {
            if (GameManager.Instance.lights == 5) {
                Destroy(other.gameObject);
            } else {
                print("You need More lights");
            }
        }
    }
}
