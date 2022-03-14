using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MermiManager : MonoBehaviour
{
    public float damage, lifetime;
    
    void Start()
    {

        Destroy(gameObject,lifetime);
        
    }


    
    
}

