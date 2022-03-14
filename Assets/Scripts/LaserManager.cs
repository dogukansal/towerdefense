using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserManager : MonoBehaviour
{
    public float damage, lifetime;
    
    
    
    void Start()
    {
        Destroy(gameObject, lifetime);
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1")
        {
            if (!collision.GetComponent<yaratikmanager>().amided)
            {
                collision.GetComponent<yaratikmanager>().getdamage(damage);
            }
            
        }

    }
    
}
