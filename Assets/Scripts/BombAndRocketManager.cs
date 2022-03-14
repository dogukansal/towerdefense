using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombAndRocketManager : MonoBehaviour
{
    public float damage, lifetime;
    Animator bomba;
    bool bombapatladi = false;
    GameObject upgradetext;
    void Start()
    {
        damage = DataManager.Instance.bombpower;
        Destroy(gameObject, lifetime);
        bomba = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        kontrol();
    }
    void kontrol()
    {
        if (gameObject.GetComponent<CircleCollider2D>().radius == 4)
        {
            
            bomba.SetBool("patladi", true);
            gameObject.layer = 0;
            gameObject.transform.localScale = new Vector3(0.6f, 0.6f);
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            bombapatladi = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1")
        {
            if (bombapatladi)
            {
                if (!collision.GetComponent<yaratikmanager>().amided)
                {
                    collision.GetComponent<yaratikmanager>().getdamage(damage);
                }
                
                
            }



        }

        
    }


    public void bombpowerupgrade()
    {
        upgradetext = GameObject.Find("Goldtext333");
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney >= 8000 && DataManager.Instance.bombpowerupgradecounter == 0)
        {
            bombpowerupgradecut(200, 8000, 50000);

        }
        else if (DataManager.Instance.mymoney >= 15000 && DataManager.Instance.bombpowerupgradecounter == 1)
        {
            bombpowerupgradecut(350, 15000, 50000);

        }
        else if (DataManager.Instance.mymoney >= 50000 && DataManager.Instance.bombpowerupgradecounter == 2)
        {
            bombpowerupgradecut(500, 50000, 150000);

        }
        else if (DataManager.Instance.mymoney >= 150000 && DataManager.Instance.bombpowerupgradecounter == 3)
        {
            DataManager.Instance.mymoney -= 150000;
            damage = 600;
            DataManager.Instance.bombpower = 600f;
            upgradetext.GetComponent<Text>().text = "MAX";
            DataManager.Instance.bombpowerupgradecounter++;


        }
        
        

        DataManager.Instance.SaveData();
    }
    void bombpowerupgradecut(float shotpower, int fuzepowerprice, int newprice)
    {
        DataManager.Instance.mymoney -= fuzepowerprice;
        damage = shotpower;
        DataManager.Instance.bombpower = shotpower;
        upgradetext.GetComponent<Text>().text = newprice.ToString();
        DataManager.Instance.bombpowerupgradecounter++;


    }
}
