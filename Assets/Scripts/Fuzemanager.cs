using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuzemanager : MonoBehaviour
{
    public float damage, lifetime;
    Animator fuze;
    GameObject upgradetext;

    void Start()
    {
        damage = DataManager.Instance.rocketpower ;
        Destroy(gameObject, lifetime);
        fuze = GetComponent<Animator>();
    }

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1")
        {
          collision.GetComponent<yaratikmanager>().getdamage(damage);
          fuze.SetBool("patladimi" , true);
          

        }

    }
    public void fuzepowerupgrade()
    {
        upgradetext = GameObject.Find("Goldtext444");
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney >= 40000 && DataManager.Instance.rocketpowerupgradecounter == 0)
        {
            fuzeupgradecut(500, 40000, 50000);

        }
        else if (DataManager.Instance.mymoney >= 50000 && DataManager.Instance.rocketpowerupgradecounter == 1)
        {
            fuzeupgradecut(600, 50000, 60000);

        }
        else if (DataManager.Instance.mymoney >= 60000 && DataManager.Instance.rocketpowerupgradecounter == 2)
        {
            fuzeupgradecut(700, 60000, 70000);

        }
        else if (DataManager.Instance.mymoney >= 70000 && DataManager.Instance.rocketpowerupgradecounter == 3)
        {
            fuzeupgradecut(800, 70000, 90000);

        }
        else if (DataManager.Instance.mymoney >= 90000 && DataManager.Instance.rocketpowerupgradecounter == 4)
        {
            fuzeupgradecut(900, 90000, 100000);

        }
        else if (DataManager.Instance.mymoney >= 100000 && DataManager.Instance.rocketpowerupgradecounter == 5)
        {
            DataManager.Instance.mymoney -= 100000;
            damage = 1000;
            DataManager.Instance.rocketpower = 1000;
            upgradetext.GetComponent<Text>().text = "MAX";
            DataManager.Instance.rocketpowerupgradecounter++;

        }
        

        DataManager.Instance.SaveData();
    }
    void fuzeupgradecut(float shotpower, int fuzepowerprice,int newprice)
    {
        DataManager.Instance.mymoney -= fuzepowerprice;
        damage = shotpower;
        DataManager.Instance.rocketpower = shotpower;
        upgradetext.GetComponent<Text>().text = newprice.ToString();
        DataManager.Instance.rocketpowerupgradecounter++;
        

    }
}
