using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructor : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Untagged"){
           
                Destroy(collision.gameObject);
            

        }
          
    }
}
