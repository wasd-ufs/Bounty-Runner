using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
    
        if(transform.position.x < 0){
            Destroy(gameObject);
        }      
    }
}
