using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Untagged"){
           
                Destroy(collision.gameObject);
            

        }
          
    }
}
