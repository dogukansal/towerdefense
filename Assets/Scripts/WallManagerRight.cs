using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallManagerRight : MonoBehaviour
{
     float health;
    bool dead = false;
    public Slider slider;
    public Transform floatingtext;
    
    

    void Start()
    {
        controlwall();


    }

    public void controlwall()
    {
        if (DataManager.Instance.wallhealright > 0f && DataManager.Instance.whichlevel >= 10)
        {
            gameObject.SetActive(true);
            if (DataManager.Instance.wallhealthupgradecounter == 0)
            {
                slider.maxValue = 8000f;
                
            }
            else if (DataManager.Instance.wallhealthupgradecounter == 1)
            {
                slider.maxValue = 12000;
               
            }
            else if (DataManager.Instance.wallhealthupgradecounter == 2)
            {
                slider.maxValue = 20000;
                
            }
            else if (DataManager.Instance.wallhealthupgradecounter == 3)
            {
                slider.maxValue = 30000;
                
            }
            else if (DataManager.Instance.wallhealthupgradecounter == 4)
            {
                slider.maxValue = 40000;
                
            }
            
            
            slider.value = DataManager.Instance.wallhealright;

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void getdamage(float damage)
    {

        Instantiate(floatingtext, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        DataManager.Instance.wallhealright -= damage;
        DataManager.Instance.wallhealthdatasave();

        if ((DataManager.Instance.wallhealright - damage) >= 0)
        {
            DataManager.Instance.wallhealright -= damage;
        }
        else
        {
            health = 0f;
            DataManager.Instance.wallhealright = 0f;
            DataManager.Instance.wallhealthdatasave();
        }
        slider.value = DataManager.Instance.wallhealright;
        amidead();
    }

    void amidead()
    {

        if (DataManager.Instance.wallhealright <= 0)
        {

            dead = true;
            gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1")
        {

            collision.GetComponent<yaratikmanager>().stopanimation();


        }
        if (collision.tag == "yaratikmermisi1")
        {

            getdamage(collision.GetComponent<MermiManager>().damage);
            Destroy(collision.gameObject);


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1")
        {

            collision.GetComponent<yaratikmanager>().stopanimation2();


        }
    }
    public void wallcanyenilemeright() //wallý koyuyo
    {
        gameObject.SetActive(true);
        if (DataManager.Instance.wallhealthupgradecounter == 0)
        {
            slider.maxValue = 8000f;
            slider.value = 8000f;
            DataManager.Instance.wallhealright = 8000f;
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 1)
        {
            slider.maxValue = 12000;
            slider.value = 12000;
            DataManager.Instance.wallhealright = 12000;
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 2)
        {
            slider.maxValue = 20000;
            slider.value = 20000;
            DataManager.Instance.wallhealright = 20000;
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 3)
        {
            slider.maxValue = 30000;
            slider.value = 30000;
            DataManager.Instance.wallhealright = 30000;
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 4)
        {
            slider.maxValue = 40000;
            slider.value = 40000;
            DataManager.Instance.wallhealright = 40000;
        }
        DataManager.Instance.SaveData();
        
    }
    public void wallcanupgraderight() 
    {
        slider.maxValue = DataManager.Instance.wallmaxheal;
    }
}
