using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public Transform yuzunudegistir;

    bool durum = false;
    float zaman;
    float sonrakizaman = 0.4f;
    Animator animator;
    void Start()
    {
        zaman = Time.time;
    }

    
    void Update()
    {
        degistir();
        degistir2();
    }
    void degistir()
    {
        if (DataManager.Instance.muzik)
        {
            if (Time.time > zaman)
            {
                this.gameObject.GetComponent<Animator>().enabled = true;
                yuzunudegistir.transform.eulerAngles = new Vector3(yuzunudegistir.transform.eulerAngles.x, yuzunudegistir.transform.eulerAngles.y + 180, yuzunudegistir.transform.eulerAngles.z);
                zaman = Time.time + sonrakizaman;
                durum = true;
                
            }
        }
        else
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
        }
        


    }
    void degistir2()
    {
        if (DataManager.Instance.muzik)
        {
            if (Time.time > zaman && durum)
            {
                this.gameObject.GetComponent<Animator>().enabled = false;
                yuzunudegistir.transform.eulerAngles = new Vector3(yuzunudegistir.transform.eulerAngles.x, yuzunudegistir.transform.eulerAngles.y - 180, yuzunudegistir.transform.eulerAngles.z);
                zaman = Time.time + sonrakizaman;
                durum = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
        }


    }
}
