using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yazidestroy : MonoBehaviour
{
    public int lifetime;
    void Start()
    {
        Destroy(gameObject,lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
