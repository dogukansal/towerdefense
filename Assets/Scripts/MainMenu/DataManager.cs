using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    EasyFileSave myFile;
    //veriler
    public int mymoney; //ka� alt�n�m var +

    public short bombquantity;//bomban�n envanterde ka� tane var +
    public float bombpower; //bomban�n g�c� +
    public short bombpowerupgradecounter; //bomban�n upgrade mini picture + bunlar� yeni scripte yerde starta yaz
    

    public short rocketquantity;//roketin envanterde ka� tane var
    public float rocketpower; //roketin g�c� +
    public short rocketpowerupgradecounter;  //roketin upgrade mini picture+

    public short laserquantity; //lazer envanterde ka� tane var  +
    

    public short whichlevel; // hangi leveli a�t�? 
    public short levelnow; //�uan hangi leveli oynuyor?

    public short buildinglevel; //evin kat leveli
    public int buildupgradeprice;

    public float homeheal; //evin can�
    public short homehealupgradecounter; // evin can�n� artt�rma seviyesi **
    
    

    public float maxhomeheal; //evin maksimum can seviyesi **
    public bool doublegun; //�ift silaha ge�ti mi

    public float bulletspeed; //mermi ka� h�zla at�� yapacak
    public short bulletspeedupgradecounter; // mermi h�z� artt�rmma seviyesi  ** a�a��ya yazmad�m

    public float bulletpower; // merminin g�c�
    public short bulletpowerupgradecounter; // mermi g��lendirme seviyesi  ** a�a��ya yazmad�m

    public float wallhealright; //sa� duvar�n can�
    public float wallhealleft; // sol duvar�n can�
    public float wallmaxheal; 
    public short wallhealthupgradecounter;


    public bool firstbegin=false;
    public bool muzik;

    //bu veriler scoreboard i�indir.

    public float allmoney;
    public int usedbomb;
    public int usedrocket;
    public int usedlaser;
    public float usedhomeheal;
    public float shotbullet;
    public int deadcounter;
    public float getdamage;
    public float setdamage;
    public int playedlevel;
    public float killmonster;
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            StartProcces();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void StartProcces()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
   
    public void LoadData() 
    {
        if (myFile.Load())
        {
            mymoney = myFile.GetInt("mymoney");
            bombquantity = myFile.GetShort("bombquantity");
            rocketquantity = myFile.GetShort("rocketquantity");
            laserquantity = myFile.GetShort("laserquantity");
            bombpower = myFile.GetFloat("bombpower");
            rocketpower = myFile.GetFloat("rocketpower");
            whichlevel = myFile.GetShort("whichlevel");
            buildinglevel = myFile.GetShort("buildinglevel");
            homeheal = myFile.GetFloat("homeheal");
            doublegun = myFile.GetBool("doublegun");
            bulletspeed = myFile.GetFloat("bulletspeed");
            bulletpower = myFile.GetFloat("bulletpower");
            wallhealright = myFile.GetFloat("wallhealright");
            wallhealleft = myFile.GetFloat("wallhealleft");
            homehealupgradecounter = myFile.GetShort("homehealupgradecounter");

            bombpowerupgradecounter = myFile.GetShort("bombpowerupgradecounter");
            rocketpowerupgradecounter = myFile.GetShort("rocketpowerupgradecounter");
            buildupgradeprice = myFile.GetInt("buildupgradeprice");
            maxhomeheal = myFile.GetFloat("maxhomeheal");
            bulletspeedupgradecounter = myFile.GetShort("bulletspeedupgradecounter");
            bulletpowerupgradecounter = myFile.GetShort("bulletpowerupgradecounter");
            wallmaxheal = myFile.GetFloat("wallmaxheal");
            wallhealthupgradecounter = myFile.GetShort("wallhealthupgradecounter");
            firstbegin = myFile.GetBool("firstbegin");
            muzik = myFile.GetBool("muzik");
            //
            allmoney = myFile.GetFloat("allmoney");
            usedbomb = myFile.GetInt("usedbomb");
            usedrocket = myFile.GetInt("usedrocket");
            usedlaser = myFile.GetInt("usedlaser");
            usedhomeheal = myFile.GetFloat("usedhomeheal");
            shotbullet = myFile.GetFloat("shotbullet");
            deadcounter = myFile.GetInt("deadcounter");
            getdamage = myFile.GetFloat("getdamage");
            playedlevel = myFile.GetInt("playedlevel");
            killmonster = myFile.GetFloat("killmonster");
            setdamage = myFile.GetFloat("setdamage");

        }
        firstbegining();
    }
    
    public void moneydatasave()
    {
        myFile.Add("mymoney", mymoney);
        myFile.Add("allmoney", allmoney);
        myFile.Add("killmonster", killmonster);
    }
    public void moneyloaddata()
    {
        mymoney = myFile.GetInt("mymoney");
    }
    public void homehealthdatasave()
    {
        myFile.Add("homeheal", homeheal);
    }
    public void wallhealthdatasave()
    {
        myFile.Add("wallhealleft", wallhealleft);
        myFile.Add("wallhealright", wallhealright);
    }

    public void SaveData()
    {
        
        myFile.Add("mymoney", mymoney);
        myFile.Add("bombquantity", bombquantity);
        myFile.Add("rocketquantity", rocketquantity);
        myFile.Add("laserquantity", laserquantity);
        myFile.Add("bombpower", bombpower);
        myFile.Add("rocketpower", rocketpower);
        myFile.Add("whichlevel", whichlevel);
        myFile.Add("buildinglevel", buildinglevel);
        myFile.Add("homeheal", homeheal);
        myFile.Add("doublegun", doublegun);
        myFile.Add("bulletspeed", bulletspeed);
        myFile.Add("bulletpower", bulletpower);
        myFile.Add("wallhealright", wallhealright);
        myFile.Add("wallhealleft", wallhealleft);
        myFile.Add("homehealupgradecounter", homehealupgradecounter);
        myFile.Add("muzik", muzik);
        myFile.Add("bombpowerupgradecounter", bombpowerupgradecounter);
        myFile.Add("rocketpowerupgradecounter", rocketpowerupgradecounter);
        myFile.Add("buildupgradeprice", buildupgradeprice);
        myFile.Add("maxhomeheal", maxhomeheal);
        myFile.Add("bulletspeedupgradecounter", bulletspeedupgradecounter);
        myFile.Add("bulletpowerupgradecounter", bulletpowerupgradecounter);
        myFile.Add("wallmaxheal", wallmaxheal);
        myFile.Add("wallhealthupgradecounter", wallhealthupgradecounter);
        myFile.Add("firstbegin", firstbegin);
        //
        myFile.Add("allmoney", allmoney);
        myFile.Add("usedbomb", usedbomb);
        myFile.Add("usedrocket", usedrocket);
        myFile.Add("usedlaser", usedlaser);
        myFile.Add("usedhomeheal", usedhomeheal);
        myFile.Add("shotbullet", shotbullet);
        myFile.Add("deadcounter", deadcounter);
        myFile.Add("getdamage", getdamage);
        myFile.Add("setdamage", setdamage);
        myFile.Add("playedlevel", playedlevel);
        myFile.Add("killmonster", killmonster);



        myFile.Save();
    }


    
    void firstbegining()
    {
        if (!firstbegin)
        {
            firstbegin = true;

            // wall health
            homeheal = 1500f;
            maxhomeheal = 1500f;
            bulletspeed = 1.9f;
            bulletpower = 10f;
            rocketpower = 400f;
            bombpower = 50f;
            muzik = true;
            SaveData();
        }
    }
    
    public short returnlevel()
    {
        return levelnow;
    }
    

}
