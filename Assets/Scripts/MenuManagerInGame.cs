using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerInGame : MonoBehaviour
{
    //public GameObject ingamescreen, pausescreen;
    public GameObject  market;
    public GameObject marketbutonu;
    public GameObject pausescreen;
    public GameObject pausebuttonn;
    public GameObject zamanarttirmetexti;
    
    public Text homehealthtext;
    public Text laserquantitytext;
    public Text homeupgradetext;
    public Text wallhealtupgradetext;
    public Text grenadetext;
    public Text rockettext;
    public Text twoguntext;
    public Text walltext;
    public Text bulletpowertext;
    public Text bulletspeedtext;
    public Text healthupgradetext;
    public Text grenadepowertext;
    public Text rocketpowertext;
    public GameObject[] bombquantityminipicture;
    public GameObject[] rocketquantityminipicture;

    public GameObject[] laserquantityminipicture;
    public GameObject[] homeupgradequantityminipicture;
    public GameObject[] wallhealthquantityminipicture;
    public GameObject[] bulletpoweryminipicture;
    public GameObject[] bulletspeedyminipicture;
    public GameObject[] healthupgrademinipicture;
    public GameObject[] granedepowerminipicture; //yazmamýþým ki aq
    public GameObject[] rocketpowerminipicture;
    public GameObject twogun;

    public Button laserbutton;
    public Button laserADbutton;
    public Button homeupgradebutton;
    public Button wallhealthbutton;
    public Button bombbutton;
    public Button bombADbutton;
    public Button rocketbutton;
    public Button rocketADbutton;
    public Button Twogunbutton;
    public Button wallbutton;
    public Button wallADbutton;
    public Button bulletpowerbutton;
    public Button bulletspeedbutton;
    public Button healthupgradebutton;
    public Button bombupgradebutton;
    public Button rocketupgradebutton;

    public Text goldtext;

    // bunlar bomba füze lazer fýrlatma butonlarý. pause a basýnca visible kapansýn diye
    public GameObject gameinbomb;
    public GameObject gameinrocket;
    public GameObject gameinlaser;
    public GameObject timebutton;

    public AudioSource upgradesound;


    void Start()
    {
        datacontrol();
        startcut();
        updategoldtext();
    }

    
  
    void datacontrol()
    {
        DataManager.Instance.LoadData();
        canbasmabegin(); 
        bulletspeedbegin(); 
        homeupgradebegin(); 
        healthupgradebegin();
        bombquantitybegin();
        rocketquantitybegin();
        laserquantitybegin();
        bulletpowerbegin();
        walllevelcontrol();
        wallhealthbegin();
        twogunbegin();
        wallcut();
        bombpowerupgrade();
        rocketpowerupgrade();
        //quantitylerin ilk baþladýðýnda fiyatlarý yok
        ////bombanýn füzenin lazerin gameobjelerini de al yeþilleri  yani 4 te yanmýyordu kullanýnca yanýyo evmanagerda kullan ? 
    } //two gun wall health bullet power 

    public void bombpowerupgrade() //butona koy
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.bombpowerupgradecounter == 0)
        {
            for (int i = 0; i <= 3; i++)
            {
                granedepowerminipicture[i].SetActive(true);
            }
            grenadepowertext.GetComponent<Text>().text = "8000";
        }
        else if (DataManager.Instance.bombpowerupgradecounter == 1)
        {
            quantitycut(granedepowerminipicture, DataManager.Instance.bombpowerupgradecounter - 1);
            grenadepowertext.GetComponent<Text>().text = "15000";
        }
        else if (DataManager.Instance.bombpowerupgradecounter == 2)
        {
            quantitycut(granedepowerminipicture, DataManager.Instance.bombpowerupgradecounter - 1);
            grenadepowertext.GetComponent<Text>().text = "50000";
        }
        else if (DataManager.Instance.bombpowerupgradecounter == 3)
        {
            quantitycut(granedepowerminipicture, DataManager.Instance.bombpowerupgradecounter - 1);
            grenadepowertext.GetComponent<Text>().text = "150000";
        }
        else if (DataManager.Instance.bombpowerupgradecounter == 4)
        {
            quantitycut(granedepowerminipicture, DataManager.Instance.bombpowerupgradecounter - 1);
            bombupgradebutton.interactable = false;
            grenadepowertext.GetComponent<Text>().text = "MAX";
        }
    }
    public void rocketpowerupgrade()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.rocketpowerupgradecounter == 0)
        {
            for (int i = 0; i <= 4; i++)
            {
                rocketpowerminipicture[i].SetActive(true);
            }
            rocketpowertext.GetComponent<Text>().text = "40000";
        }
        else if (DataManager.Instance.rocketpowerupgradecounter == 1)
        {
            quantitycut(rocketpowerminipicture, DataManager.Instance.rocketpowerupgradecounter - 1);
            rocketpowertext.GetComponent<Text>().text = "50000";
        }
        else if (DataManager.Instance.rocketpowerupgradecounter == 2)
        {
            quantitycut(rocketpowerminipicture, DataManager.Instance.rocketpowerupgradecounter - 1);
            rocketpowertext.GetComponent<Text>().text = "60000";
        }
        else if (DataManager.Instance.rocketpowerupgradecounter == 3)
        {
            quantitycut(rocketpowerminipicture, DataManager.Instance.rocketpowerupgradecounter - 1);
            rocketpowertext.GetComponent<Text>().text = "70000";
        }
        else if (DataManager.Instance.rocketpowerupgradecounter == 4)
        {
            quantitycut(rocketpowerminipicture, DataManager.Instance.rocketpowerupgradecounter - 1);
            bombupgradebutton.interactable = false;
            rocketpowertext.GetComponent<Text>().text = "90000";
        }
        else if (DataManager.Instance.rocketpowerupgradecounter == 4)
        {
            quantitycut(rocketpowerminipicture, DataManager.Instance.rocketpowerupgradecounter - 1);
            bombupgradebutton.interactable = false;
            rocketpowertext.GetComponent<Text>().text = "100000";
        }
        else if (DataManager.Instance.rocketpowerupgradecounter == 5)
        {
            quantitycut(rocketpowerminipicture, DataManager.Instance.rocketpowerupgradecounter - 1);
            rocketupgradebutton.interactable = false;
            rocketpowertext.GetComponent<Text>().text = "MAX";
        }
    }
    void walllevelcontrol()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.whichlevel < 10)
        {
            wallbutton.interactable = false;
            wallADbutton.interactable = false;
            wallhealthbutton.interactable = false;
        }
    } 
    
    public void wallkoyma()
    {
        if (DataManager.Instance.whichlevel >= 10 && DataManager.Instance.whichlevel < 12 && DataManager.Instance.mymoney >=15000) 
        {
            DataManager.Instance.mymoney -= 15000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.whichlevel >= 12 && DataManager.Instance.whichlevel < 16 && DataManager.Instance.mymoney >= 40000)
        {
            DataManager.Instance.mymoney -= 40000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.whichlevel >= 16 && DataManager.Instance.whichlevel <= 19 && DataManager.Instance.mymoney >= 70000)
        {
            DataManager.Instance.mymoney -= 70000;
            upgradesound.Play();
        }
        DataManager.Instance.SaveData();
    }
    void wallcut()
    {
        if (DataManager.Instance.whichlevel >= 10 && DataManager.Instance.whichlevel < 12 )
        {
            walltext.GetComponent<Text>().text = "15000";
            if (DataManager.Instance.mymoney >= 15000)
            {
                wallbutton.interactable = true;
            }
            else
            {
                wallbutton.interactable = false;
            }
            
        }
        else if (DataManager.Instance.whichlevel >= 12 && DataManager.Instance.whichlevel < 16 )
        {
            walltext.GetComponent<Text>().text = "40000";
            if (DataManager.Instance.mymoney >= 40000)
            {
                wallbutton.interactable = true;
            }
            else
            {
                wallbutton.interactable = false;
            }
        }
        else if (DataManager.Instance.whichlevel >= 16 && DataManager.Instance.whichlevel <= 19 )
        {
            walltext.GetComponent<Text>().text = "70000";
            if (DataManager.Instance.mymoney >= 70000)
            {
                wallbutton.interactable = true;
            }
            else
            {
                wallbutton.interactable = false;
            }
        }
        else
        {
            wallbutton.interactable = false;
        }
    }
    public void wallhealthupgradebuton() 
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.wallhealthupgradecounter == 0 && DataManager.Instance.mymoney >=20000)
        {
            DataManager.Instance.mymoney -= 20000;
            DataManager.Instance.wallhealthupgradecounter++;
            DataManager.Instance.wallmaxheal = 12000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 1 && DataManager.Instance.mymoney >= 30000)
        {
            DataManager.Instance.mymoney -= 30000;
            DataManager.Instance.wallhealthupgradecounter++;
            DataManager.Instance.wallmaxheal = 20000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 2 && DataManager.Instance.mymoney >= 40000)
        {
            DataManager.Instance.mymoney -= 40000;
            DataManager.Instance.wallhealthupgradecounter++;
            DataManager.Instance.wallmaxheal = 30000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 3 && DataManager.Instance.mymoney >= 50000)
        {
            DataManager.Instance.mymoney -= 50000;
            DataManager.Instance.wallhealthupgradecounter++;
            DataManager.Instance.wallmaxheal = 40000;
            upgradesound.Play();
        }
        DataManager.Instance.SaveData();
        wallhealthbegin();
        
    } 
    void wallhealthbegin()
    {
        
        if (DataManager.Instance.wallhealthupgradecounter == 0)
        {
            wallhealtupgradetext.GetComponent<Text>().text = "20000";
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 1)
        {
            wallhealtupgradetext.GetComponent<Text>().text = "30000";
            quantitycut(wallhealthquantityminipicture, DataManager.Instance.wallhealthupgradecounter - 1);
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 2)
        {
            wallhealtupgradetext.GetComponent<Text>().text = "40000";
            quantitycut(wallhealthquantityminipicture, DataManager.Instance.wallhealthupgradecounter - 1);
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 3)
        {
            wallhealtupgradetext.GetComponent<Text>().text = "50000";
            quantitycut(wallhealthquantityminipicture, DataManager.Instance.wallhealthupgradecounter - 1);
        }
        else if (DataManager.Instance.wallhealthupgradecounter == 4)
        {
            wallhealtupgradetext.GetComponent<Text>().text = "MAX";
            quantitycut(wallhealthquantityminipicture, DataManager.Instance.wallhealthupgradecounter - 1);
            wallhealthbutton.interactable = false;
        }
    }
    void twogunbegin()
    {
        
        if (DataManager.Instance.whichlevel < 11 && DataManager.Instance.mymoney < 1000000)
        {
            Twogunbutton.interactable = false;

        }
        if (DataManager.Instance.doublegun)
        {
            Twogunbutton.interactable = false;
            twogun.SetActive(false); 

        }
        
    }
    public void bulletpowerbegin() //butona ekle bulleet poweraff
    {
        
        if (DataManager.Instance.bulletpowerupgradecounter == 0)
        {
            bulletpowertext.GetComponent<Text>().text = "450";
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 1)
        {
            bulletpowertext.GetComponent<Text>().text = "1500";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 2)
        {
            bulletpowertext.GetComponent<Text>().text = "15000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 3)
        {
            bulletpowertext.GetComponent<Text>().text = "50000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 4)
        {
            bulletpowertext.GetComponent<Text>().text = "80000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 5)
        {
            bulletpowertext.GetComponent<Text>().text = "100000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 6)
        {
            bulletpowertext.GetComponent<Text>().text = "150000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 7)
        {
            bulletpowertext.GetComponent<Text>().text = "200000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 8)
        {
            bulletpowertext.GetComponent<Text>().text = "300000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 9)
        {
            bulletpowertext.GetComponent<Text>().text = "350000";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletpowerupgradecounter == 10)
        {
            bulletpowertext.GetComponent<Text>().text = "MAX";
            quantitycut(bulletpoweryminipicture, DataManager.Instance.bulletpowerupgradecounter - 1);
            bulletpowerbutton.interactable = false;
        }
    }
    public void healthupgradebegin()
    {
        
        if (DataManager.Instance.homehealupgradecounter==0)
        {
            healthupgradetext.GetComponent<Text>().text = "1000";
        }
        else if (DataManager.Instance.homehealupgradecounter == 1)
        {
            healthupgradetext.GetComponent<Text>().text = "3000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 2)
        {
            healthupgradetext.GetComponent<Text>().text = "10000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 3)
        {
            healthupgradetext.GetComponent<Text>().text = "15000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 4)
        {
            healthupgradetext.GetComponent<Text>().text = "20000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 5)
        {
            healthupgradetext.GetComponent<Text>().text = "50000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 6)
        {
            healthupgradetext.GetComponent<Text>().text = "80000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 7)
        {
            healthupgradetext.GetComponent<Text>().text = "100000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 8)
        {
            healthupgradetext.GetComponent<Text>().text = "200000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 9)
        {
            healthupgradetext.GetComponent<Text>().text = "240000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 10)
        {
            healthupgradetext.GetComponent<Text>().text = "270000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 11)
        {
            healthupgradetext.GetComponent<Text>().text = "300000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 12)
        {
            healthupgradetext.GetComponent<Text>().text = "400000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 13)
        {
            healthupgradetext.GetComponent<Text>().text = "500000";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
        }
        else if (DataManager.Instance.homehealupgradecounter == 14)
        {
            healthupgradetext.GetComponent<Text>().text = "MAX";
            quantitycut(healthupgrademinipicture, DataManager.Instance.homehealupgradecounter - 1);
            healthupgradebutton.interactable = false;
        }

    }     //health upgradeff
    void canbasmabegin()
    {
        
        if (DataManager.Instance.whichlevel >= 0 && DataManager.Instance.whichlevel <= 2)
        {
            homehealthtext.GetComponent<Text>().text = "30";
        }
        else if (DataManager.Instance.whichlevel >= 3 && DataManager.Instance.whichlevel <= 4)
        {
            homehealthtext.GetComponent<Text>().text = "170";
        }
        else if (DataManager.Instance.whichlevel >= 5 && DataManager.Instance.whichlevel <= 7)
        {
            homehealthtext.GetComponent<Text>().text = "1000";
        }
        else if (DataManager.Instance.whichlevel >= 8 && DataManager.Instance.whichlevel <= 10)
        {
            homehealthtext.GetComponent<Text>().text = "2000";
        }
        else if (DataManager.Instance.whichlevel >= 11 && DataManager.Instance.whichlevel <= 14)
        {
            homehealthtext.GetComponent<Text>().text = "4000";
        }
        else if (DataManager.Instance.whichlevel >= 15 && DataManager.Instance.whichlevel <= 19)
        {
            homehealthtext.GetComponent<Text>().text = "9000";
        }

    } //home health
    public void bulletspeedbegin()
    {
        
        if (DataManager.Instance.bulletspeedupgradecounter == 0)
        {
            bulletspeedtext.GetComponent<Text>().text = "2000";
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 1)
        {
            bulletspeedtext.GetComponent<Text>().text = "4000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter-1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 2)
        {
            bulletspeedtext.GetComponent<Text>().text = "8000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 3)
        {
            bulletspeedtext.GetComponent<Text>().text = "15000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 4)
        {
            bulletspeedtext.GetComponent<Text>().text = "50000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 5)
        {
            bulletspeedtext.GetComponent<Text>().text = "80000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 6)
        {
            bulletspeedtext.GetComponent<Text>().text = "100000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 7)
        {
            bulletspeedtext.GetComponent<Text>().text = "140000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 8)
        {
            bulletspeedtext.GetComponent<Text>().text = "160000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 9)
        {
            bulletspeedtext.GetComponent<Text>().text = "180000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 10)
        {
            bulletspeedtext.GetComponent<Text>().text = "200000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 11)
        {
            bulletspeedtext.GetComponent<Text>().text = "250000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 12)
        {
            bulletspeedtext.GetComponent<Text>().text = "300000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);
        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 13)
        {
            bulletspeedtext.GetComponent<Text>().text = "400000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);

        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 14)
        {
            bulletspeedtext.GetComponent<Text>().text = "500000";
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter - 1);

        }
        else if (DataManager.Instance.bulletspeedupgradecounter == 15)
        {
            bulletspeedtext.GetComponent<Text>().text = "MAX";
            bulletspeedbutton.interactable = false;
            quantitycut(bulletspeedyminipicture, DataManager.Instance.bulletspeedupgradecounter-1);

        }
    } //bullet speedff
    public void homeupgradebegin()
    {
        
        if (DataManager.Instance.buildinglevel == 0)
        {
            homeupgradetext.GetComponent<Text>().text = "3000";
        }
        else if (DataManager.Instance.buildinglevel == 1)
        {
            homeupgradetext.GetComponent<Text>().text = "3000";
            quantitycut(homeupgradequantityminipicture, DataManager.Instance.buildinglevel-1);
        }
        else if (DataManager.Instance.buildinglevel == 2)
        {
            homeupgradetext.GetComponent<Text>().text = "12500";
            quantitycut(homeupgradequantityminipicture, DataManager.Instance.buildinglevel - 1);
        }
        else if (DataManager.Instance.buildinglevel == 3)
        {
            homeupgradetext.GetComponent<Text>().text = "12500";
            quantitycut(homeupgradequantityminipicture, DataManager.Instance.buildinglevel - 1);
        }
        else if (DataManager.Instance.buildinglevel == 4)
        {
            homeupgradetext.GetComponent<Text>().text = "MAX";
            quantitycut(homeupgradequantityminipicture, DataManager.Instance.buildinglevel - 1);
            homeupgradebutton.interactable = false;
        }
    } //home upgradeff
    public void bombquantitybuton()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney >= 700 && DataManager.Instance.whichlevel >=3 && DataManager.Instance.whichlevel <= 4 )
        {
            DataManager.Instance.mymoney -= 1000;
            DataManager.Instance.bombquantity++;
            upgradesound.Play();

        }
        else if ( DataManager.Instance.mymoney >= 2000 && DataManager.Instance.whichlevel >= 5 && DataManager.Instance.whichlevel <= 6)
        {
            DataManager.Instance.mymoney -= 3000;
            DataManager.Instance.bombquantity++;
            upgradesound.Play();
        }
        else if ( DataManager.Instance.mymoney >= 4000 && DataManager.Instance.whichlevel >= 7 && DataManager.Instance.whichlevel <= 9)
        {
            DataManager.Instance.mymoney -= 4000;
            DataManager.Instance.bombquantity++;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 15000 && DataManager.Instance.whichlevel >= 10 && DataManager.Instance.whichlevel <= 11)
        {
            DataManager.Instance.mymoney -= 8000;
            DataManager.Instance.bombquantity++;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 25000 && DataManager.Instance.whichlevel >= 12)
        {
            DataManager.Instance.mymoney -= 25000;
            DataManager.Instance.bombquantity++;
            upgradesound.Play();
        }
        DataManager.Instance.SaveData();
        bombquantitycounter();
    }
    public void rocketquantitybuton()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney >= 7000 && DataManager.Instance.whichlevel >= 6 && DataManager.Instance.whichlevel <= 9)
        {
            DataManager.Instance.mymoney -= 7000;
            DataManager.Instance.rocketquantity++;
            upgradesound.Play();

        }
        else if (DataManager.Instance.mymoney >= 15000 && DataManager.Instance.whichlevel >= 10 && DataManager.Instance.whichlevel <= 12)
        {
            DataManager.Instance.mymoney -= 15000;
            DataManager.Instance.rocketquantity++;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 30000 && DataManager.Instance.whichlevel >= 13)
        {
            DataManager.Instance.mymoney -= 30000;
            DataManager.Instance.rocketquantity++;
            upgradesound.Play();
        }

        DataManager.Instance.SaveData();
        rocketquantitycounter();
    }
    public void laserquantitybuton()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney >= 70000 && DataManager.Instance.whichlevel >= 15)
        {
            DataManager.Instance.mymoney -= 70000;
            DataManager.Instance.laserquantity++;
            upgradesound.Play();

        }
        DataManager.Instance.SaveData();
        laserquantitycounter();
    }
     void bombquantitycounter()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.bombquantity == 0)
        {
            for (int i = 0; i <= 3; i++)
            {
                bombquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.bombquantity ==1)
        {
            quantitycut(bombquantityminipicture, DataManager.Instance.bombquantity-1);
            for (int i = 1; i <= 3; i++)
            {
                bombquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.bombquantity == 2)
        {
            quantitycut(bombquantityminipicture, DataManager.Instance.bombquantity - 1);
            for (int i = 2; i <= 3; i++)
            {
                bombquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.bombquantity == 3)
        {
            quantitycut(bombquantityminipicture, DataManager.Instance.bombquantity - 1);
            bombquantityminipicture[3].SetActive(true);
        }
        else if (DataManager.Instance.bombquantity == 4)
        {
            quantitycut(bombquantityminipicture, DataManager.Instance.bombquantity - 1);
            bombbutton.interactable = false;
            bombADbutton.interactable = false;
        }
    }
     void rocketquantitycounter()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.rocketquantity == 0)
        {
            for (int i = 0; i <= 3; i++)
            {
                rocketquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.rocketquantity == 1)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            for (int i = 1; i <= 3; i++)
            {
                rocketquantityminipicture[i].SetActive(true);
            }

        }
        else if (DataManager.Instance.rocketquantity == 2)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            for (int i = 2; i <= 3; i++)
            {
                rocketquantityminipicture[i].SetActive(true);
            }

        }
        else if (DataManager.Instance.rocketquantity == 3)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            rocketquantityminipicture[3].SetActive(true);

        }
        else if (DataManager.Instance.rocketquantity == 4)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            rocketbutton.interactable = false;
            rocketADbutton.interactable = false;
        }
    }
    public void laserquantitycounter()  
    {
        if (DataManager.Instance.laserquantity == 0)
        {
            for (int i = 0; i <= 3; i++)
            {
                laserquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.laserquantity == 1)
        {
            quantitycut(laserquantityminipicture, DataManager.Instance.laserquantity - 1);
            for (int i = 1; i <= 3; i++)
            {
                laserquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.laserquantity == 2)
        {
            quantitycut(laserquantityminipicture, DataManager.Instance.laserquantity - 1);
            for (int i = 2; i <= 3; i++)
            {
                laserquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.laserquantity == 3)
        {
            quantitycut(laserquantityminipicture, DataManager.Instance.laserquantity - 1);
            laserquantityminipicture[3].SetActive(true);
        }
        else if (DataManager.Instance.laserquantity == 4)
        {
            quantitycut(laserquantityminipicture, DataManager.Instance.laserquantity - 1);
            laserADbutton.interactable = false;
            laserbutton.interactable = false;
        }
    }
    public void bombquantitybegin()
    {
        
        if (DataManager.Instance.whichlevel < 3)
        {
            bombbutton.interactable = false;
            bombADbutton.interactable = false;
            bombupgradebutton.interactable = false;
        }
        else if (DataManager.Instance.whichlevel >= 3 && DataManager.Instance.whichlevel <= 4)
        {
            grenadetext.GetComponent<Text>().text = "700";

        }
        else if (DataManager.Instance.whichlevel >= 5 && DataManager.Instance.whichlevel <= 6)
        {
            grenadetext.GetComponent<Text>().text = "2000";

        }
        else if (DataManager.Instance.whichlevel >= 7 && DataManager.Instance.whichlevel <= 9)
        {
            grenadetext.GetComponent<Text>().text = "4000";

        }
        else if (DataManager.Instance.whichlevel >= 10 && DataManager.Instance.whichlevel <= 11)
        {
            grenadetext.GetComponent<Text>().text = "15000";

        }
        else if (DataManager.Instance.whichlevel >= 12)
        {
            grenadetext.GetComponent<Text>().text = "25000";

        }
        bombquantitycounter();
    } //grenade
    public void rocketquantitybegin()
    {
        
        if (DataManager.Instance.whichlevel < 6 )
        {
            rocketbutton.interactable = false;
            rocketADbutton.interactable = false;
            rocketupgradebutton.interactable = false;

        }
        else if (DataManager.Instance.whichlevel >= 6 && DataManager.Instance.whichlevel <= 9)
        {
            rockettext.GetComponent<Text>().text = "7000";

        }
        else if (DataManager.Instance.whichlevel >= 10 && DataManager.Instance.whichlevel <= 12)
        {
            rockettext.GetComponent<Text>().text = "15000";

        }
        else if (DataManager.Instance.whichlevel >= 13)
        {
            rockettext.GetComponent<Text>().text = "30000";

        }
        rocketquantitycounter();

    } //rocket
     void laserquantitybegin()
    {
                           
        if (DataManager.Instance.whichlevel < 15)            
        {
            laserbutton.interactable = false;
            laserADbutton.interactable = false;

        }
        else
        {
            laserquantitycounter();
        }
    } //lazer
    void quantitycut(GameObject []obje, int howmany)
    {
        for (int i = 0; i <= howmany; i++)
        {
            obje[i].SetActive(false);
        }
    }
    
    void startcut()
    {
        textcolorcontrol(homehealthtext);
        textcolorcontrol(laserquantitytext);
        textcolorcontrol(homeupgradetext);
        textcolorcontrol(wallhealtupgradetext);
        textcolorcontrol(grenadetext);
        textcolorcontrol(rockettext);
        textcolorcontrol(twoguntext);
        textcolorcontrol(walltext);
        textcolorcontrol(bulletpowertext);
        textcolorcontrol(bulletspeedtext);
        textcolorcontrol(healthupgradetext);
        textcolorcontrol(grenadepowertext);
        textcolorcontrol(rocketpowertext);

    }
    void textcolorcontrol( Text givemetext)
    {
        string gecici2 = givemetext.GetComponent<Text>().text;
        int gecici=0;
        if (gecici2 !="MAX")
        {
             gecici = Convert.ToInt32(gecici2);
        }
        
        if ( gecici2 =="MAX" || DataManager.Instance.mymoney >= gecici  )
        {
            givemetext.GetComponent<Text>().color = Color.black;
        }
        else
        {
            givemetext.GetComponent<Text>().color = Color.red;
        }
    }
    public void marketpausebutton()
    {
        DataManager.Instance.SaveData();
        
       
        rocketquantitycounter();
        bombquantitycounter();
        laserquantitybegin();
        Time.timeScale = 0;
        
        
        zamanarttirmetexti.GetComponent<Text>().text = "1x";
        market.SetActive(true);
        marketbutonu.SetActive(false);
        
        pausebuttonn.SetActive(false);

        DataManager.Instance.LoadData();
        wallcut();
        startcut();
        
    }
    public void marketplaybutton()
    {
        Time.timeScale = 1;
        market.SetActive(false);
        marketbutonu.SetActive(true);
        
        pausebuttonn.SetActive(true);


    }
    public void replaybutton()
    {
        if (DataManager.Instance.homeheal <= 10)
        {
            DataManager.Instance.homeheal = 100;
        }
        DataManager.Instance.SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void pausebutton()
    {
        Time.timeScale = 0;
        pausescreen.SetActive(true);
        marketbutonu.SetActive(false);
        gameinbomb.SetActive(false);
        gameinrocket.SetActive(false);
        gameinlaser.SetActive(false);
        timebutton.SetActive(false);
    }
    public void playbutton()
    {
        Time.timeScale = 1;
        pausescreen.SetActive(false);
        zamanarttirmetexti.GetComponent<Text>().text = "1x";
        marketbutonu.SetActive(true);
        gameinbomb.SetActive(true);
        gameinrocket.SetActive(true);
        gameinlaser.SetActive(true);
        timebutton.SetActive(true);
    }
    public void mainmenuyedon()
    {
        if (DataManager.Instance.homeheal <= 10)
        {
            DataManager.Instance.homeheal = 100;
        }
        DataManager.Instance.SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void updategoldtext()
    {
        goldtext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
        wallcut();
        startcut();
    }

   
}
