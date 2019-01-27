using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if(this.gameObject.CompareTag("Enemy"))
        {
             transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
       else if(this.gameObject.CompareTag("RightEnemy"))
       {
           transform.Translate(Vector2.right * speed * Time.deltaTime);
       }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stick"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
