using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMermiManager : MonoBehaviour
{
    public float damage, lifetime;
    GameObject cointext;
    void Start()
    {

        damage = DataManager.Instance.bulletpower;
        Destroy(gameObject, lifetime);

    }


    public void bulletpowerupgrade()
    {
        cointext = GameObject.Find("Goldtext22");
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney >= 450 && DataManager.Instance.bulletpowerupgradecounter == 0)
        {
            saldirigucuupgradecut(20, 450, 1500);

        }
        else if (DataManager.Instance.mymoney >= 1500 && DataManager.Instance.bulletpowerupgradecounter == 1)
        {
            saldirigucuupgradecut(50, 1500, 15000);

        }
        else if (DataManager.Instance.mymoney >= 15000 && DataManager.Instance.bulletpowerupgradecounter == 2)
        {
            saldirigucuupgradecut(75, 15000, 50000);

        }
        else if (DataManager.Instance.mymoney >= 50000 && DataManager.Instance.bulletpowerupgradecounter == 3)
        {
            saldirigucuupgradecut(150, 50000, 80000);

        }
        else if (DataManager.Instance.mymoney >= 80000 && DataManager.Instance.bulletpowerupgradecounter == 4)
        {
            saldirigucuupgradecut(200, 80000, 100000);

        }
        else if (DataManager.Instance.mymoney >= 100000 && DataManager.Instance.bulletpowerupgradecounter == 5)
        {
            saldirigucuupgradecut(250, 100000, 150000);

        }
        else if (DataManager.Instance.mymoney >= 150000 && DataManager.Instance.bulletpowerupgradecounter == 6)
        {
            saldirigucuupgradecut(300, 150000, 200000); //300

        }
        else if (DataManager.Instance.mymoney >= 200000 && DataManager.Instance.bulletpowerupgradecounter == 7)
        {
            saldirigucuupgradecut(350, 200000, 300000); //350

        }
        else if (DataManager.Instance.mymoney >= 300000 && DataManager.Instance.bulletpowerupgradecounter == 8)
        {
            saldirigucuupgradecut(400, 300000, 350000); //450

        }
        else if (DataManager.Instance.mymoney >= 350000 && DataManager.Instance.bulletpowerupgradecounter == 9)
        {
            DataManager.Instance.mymoney -= 350000;
            damage = 500;
            DataManager.Instance.bulletpower = 500; //500
            cointext.GetComponent<Text>().text = "MAX";
            DataManager.Instance.bulletpowerupgradecounter++;

        }
        DataManager.Instance.SaveData();
    }
    void saldirigucuupgradecut(float shotpower, int bulletpowerprice, int newprice)
    {
        DataManager.Instance.mymoney -= bulletpowerprice;
        damage = shotpower;
        DataManager.Instance.bulletpower = shotpower;
        cointext.GetComponent<Text>().text = newprice.ToString();
        DataManager.Instance.bulletpowerupgradecounter++;


    }
}
