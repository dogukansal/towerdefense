using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvManager : MonoBehaviour
{
    //spawn noktalarý
    public GameObject sol;
    public GameObject sag;

    public GameObject solorta;
    public GameObject sagorta;

    public GameObject solust;
    public GameObject sagust;

    //karakter ne tarafa geçtiyse orasý true olsun. baþlangýç saðda
    bool soldami=false;
    bool sagdami = true;
    bool solortadami = false;
    bool sagortadami = false;
    bool solustdami = false;
    bool sagustdami = false;

    public float health,mermihizi=2000;
    bool dead = false;

    //namlular
    Transform namlusag;
    Transform namlusol;

    Transform namluortasag;
    Transform namluortasol;

    Transform namluustsag;
    Transform namluustsol;
    //2.cileri
    Transform namlusag2;
    Transform namlusol2;

    Transform namluortasag2;
    Transform namluortasol2;

    Transform namluustsag2;
    Transform namluustsol2;

    public bool ikincisilahagectimi = false;
    public GameObject zamanhizlandir;
    public Transform mermi,floatingtext;
    public Slider slider;
    float atismenzili;
    float sonrakiatis;

    //bomba ve fuze
    public Button bombafirlatmabutonu;
    public Button fuzefirlatmabutonu;
    //bomba ve fuzenýn kendileri,animasyonlarý,zamanlarý
    public Transform bomb;
    public Transform rocket;
    float zamanial;
    float bombapatlamasuresi;
    bool bombayiatti=false;
    public Animator bombanimation;
    public Animator rocketanimation;
    
    
    //lazerin spawn noktalarý
    public Transform lasersol;
    public Transform lasersolorta;
    public Transform lasersolust;
    public Button laserbutonu;
    public Transform laser;

    public GameObject cointextt; // saldýrý hýzýnýn para textini güncelliyorum
    public GameObject canupgradetext; // can arttýrmanýn para textini güncelliyom

    //upgrade ekranýndaki kýrmýzý noktalarý yeþil yapma mevzusu
    public GameObject[] healupgrademinipicture;
    public GameObject[] bulletspeedminipicture;

    //markette bomba veya rocket aldýðýnda fulleniyor ve butonu kapanýyor. eðer burda harcadýysan interactablelerini açmýþýmdýr.
    public Button rocketbuybutton;
    public Button bombbuybutton; 
    public Button laserbuybutton;

    public Text healthbartext;

    public AudioSource upgradesound;
    void Start()
    {
        namlusag = transform.GetChild(0);
        namlusol = transform.GetChild(1);
        namluortasol = transform.GetChild(2);
        namluortasag = transform.GetChild(3);
        namluustsol = transform.GetChild(4);
        namluustsag = transform.GetChild(5);
        namlusag2 = transform.GetChild(6);
        namlusol2 = transform.GetChild(7);
        namluortasol2 = transform.GetChild(8);
        namluortasag2 = transform.GetChild(9);
        namluustsol2 = transform.GetChild(10);
        namluustsag2 = transform.GetChild(11);
        atismenzili = DataManager.Instance.bulletspeed;// ilk çalýþtýrýldýðýnda 1.9 olarak yazdýr.
        sonrakiatis = Time.time;
        slider.maxValue = DataManager.Instance.maxhomeheal; // ilk çalýþtýrýldýðýnda 1500 olarak yazdýr.datamanagerda ayarla onu
        slider.value = DataManager.Instance.homeheal ; // ilk çalýþtýrýldýðýnda 1500 olarak yazdýr.
        bombapatlamasuresi = 1f;
        ikincisilahagectimi = DataManager.Instance.doublegun;
        if (DataManager.Instance.bombquantity>=1)
        {
            bombafirlatmabutonu.interactable =true;
        }
        else
        {
            bombafirlatmabutonu.interactable = false;
        }
        fuzefirlatmabutonu.interactable = false;

        if (DataManager.Instance.laserquantity >= 1)
        {
            laserbutonu.interactable = true;
        }
        else
        {
            laserbutonu.interactable = false;
        }
        healthbartext.GetComponent<Text>().text = DataManager.Instance.homeheal + " / " + DataManager.Instance.maxhomeheal;
        DataManager.Instance.playedlevel++;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        bombanincapibuyutme();
        
    }
    public void getdamage(float damage) {

        Instantiate(floatingtext, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        
        if ((DataManager.Instance.homeheal - damage)>=0) {
            //health -= damage;
            DataManager.Instance.homeheal -= damage;
            DataManager.Instance.getdamage += damage;
            
        }
        else
        {
            health = 0;
            DataManager.Instance.homeheal = 0;
            DataManager.Instance.deadcounter++;

        }
        DataManager.Instance.homehealthdatasave();
        slider.value = DataManager.Instance.homeheal; // 
        healthbartext.GetComponent<Text>().text = DataManager.Instance.homeheal + " / " + DataManager.Instance.maxhomeheal;
        amidead();
    }

    void amidead() {

        if (DataManager.Instance.homeheal <= 0)
        {
            dead = true;
        }
    }
    public void ikincisilahagecti()
    {
        if (DataManager.Instance.doublegun)
        {
            ikincisilahagectimi = true;
        }
        else
        {
            ikincisilahagectimi = false;
        }
        
    }
    void shoot() {
        Transform mermicik;
        Transform mermicik2;
        Transform mermicik3;
        Transform mermicik4;
        Transform mermicik5;
        Transform mermicik6;

        Transform mermicik1;
        Transform mermicik22;
        Transform mermicik33;
        Transform mermicik44;
        Transform mermicik55;
        Transform mermicik66;
        if (Time.time>sonrakiatis) {
            if (sagdami)
            {
                mermicik = Instantiate(mermi, namlusag.position, Quaternion.identity);
                mermicik.GetComponent<Rigidbody2D>().AddForce(namlusag.forward * mermihizi);
                sonrakiatis = Time.time + atismenzili;
                if (ikincisilahagectimi)
                {
                    mermicik1 = Instantiate(mermi, namlusag2.position, Quaternion.identity);
                    mermicik1.GetComponent<Rigidbody2D>().AddForce(namlusag2.forward * mermihizi);
                    sonrakiatis = Time.time + atismenzili;
                }
            }
            else if (soldami)
            {
                mermicik2 = Instantiate(mermi, namlusol.position, Quaternion.identity);
                mermicik2.GetComponent<Rigidbody2D>().AddForce(namlusol.forward * mermihizi);
                sonrakiatis = Time.time + atismenzili;
                if (ikincisilahagectimi)
                {
                    mermicik22 = Instantiate(mermi, namlusol2.position, Quaternion.identity);
                    mermicik22.GetComponent<Rigidbody2D>().AddForce(namlusol2.forward * mermihizi);
                    sonrakiatis = Time.time + atismenzili;
                }
            }
            else if (solortadami)
            {
                mermicik3 = Instantiate(mermi, namluortasol.position, Quaternion.identity);
                mermicik3.GetComponent<Rigidbody2D>().AddForce(namluortasol.forward * mermihizi);
                sonrakiatis = Time.time + atismenzili;
                if (ikincisilahagectimi)
                {
                    mermicik33 = Instantiate(mermi, namluortasol2.position, Quaternion.identity);
                    mermicik33.GetComponent<Rigidbody2D>().AddForce(namluortasol2.forward * mermihizi);
                    sonrakiatis = Time.time + atismenzili;
                }
            }
            else if (sagortadami)
            {
                mermicik4 = Instantiate(mermi, namluortasag.position, Quaternion.identity);
                mermicik4.GetComponent<Rigidbody2D>().AddForce(namluortasag.forward * mermihizi);
                sonrakiatis = Time.time + atismenzili;
                if (ikincisilahagectimi)
                {
                    mermicik44 = Instantiate(mermi, namluortasag2.position, Quaternion.identity);
                    mermicik44.GetComponent<Rigidbody2D>().AddForce(namluortasag2.forward * mermihizi);
                    sonrakiatis = Time.time + atismenzili;
                }
            }
            else if (solustdami)
            {
                mermicik5 = Instantiate(mermi, namluustsol.position, Quaternion.identity);
                mermicik5.GetComponent<Rigidbody2D>().AddForce(namluustsol.forward * mermihizi);
                sonrakiatis = Time.time + atismenzili;
                if (ikincisilahagectimi)
                {
                    mermicik55 = Instantiate(mermi, namluustsol2.position, Quaternion.identity);
                    mermicik55.GetComponent<Rigidbody2D>().AddForce(namluustsol2.forward * mermihizi);
                    sonrakiatis = Time.time + atismenzili;
                }
            }
            else if (sagustdami)
            {
                mermicik6 = Instantiate(mermi, namluustsag.position, Quaternion.identity);
                mermicik6.GetComponent<Rigidbody2D>().AddForce(namluustsag.forward * mermihizi);
                sonrakiatis = Time.time + atismenzili;
                if (ikincisilahagectimi)
                {
                    mermicik66 = Instantiate(mermi, namluustsag2.position, Quaternion.identity);
                    mermicik66.GetComponent<Rigidbody2D>().AddForce(namluustsag2.forward * mermihizi);
                    sonrakiatis = Time.time + atismenzili;
                }
            }
            DataManager.Instance.shotbullet++;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1" )
        {

            collision.GetComponent<yaratikmanager>().stopanimation();
           
        }
        if (collision.tag == "yaratikmermisi1"  )
        {

            getdamage(collision.GetComponent<MermiManager>().damage);
            Destroy(collision.gameObject);


        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "yaratik1" || collision.tag == "yaratik2" || collision.tag == "yaratik3" || collision.tag == "yaratik4")
        {

            collision.GetComponent<yaratikmanager>().stopanimation2();

        }
    }*/
    

    public void solatiklandi() {
         soldami = true;
         sagdami = false;
         solortadami = false;
         sagortadami = false;
         solustdami = false;
         sagustdami = false;
        if (DataManager.Instance.bombquantity >= 1)
        {
            bombafirlatmabutonu.interactable = true;
        }
        fuzefirlatmabutonu.interactable = false;
    }
    public void sagaatiklandi()
    {
        soldami = false;
        sagdami = true;
        solortadami = false;
        sagortadami = false;
        solustdami = false;
        sagustdami = false;
        if (DataManager.Instance.bombquantity >= 1)
        {
            bombafirlatmabutonu.interactable = true;
        }
        if (DataManager.Instance.laserquantity >= 1)
        {
            laserbutonu.interactable = true;
        }
        fuzefirlatmabutonu.interactable = false;
    }
    public void solortayatiklandi()
    {
        soldami = false;
        sagdami = false;
        solortadami = true;
        sagortadami = false;
        solustdami = false;
        sagustdami = false;
        bombafirlatmabutonu.interactable = false;
        if (DataManager.Instance.rocketquantity >= 1)
        {
            fuzefirlatmabutonu.interactable = true;
        }
    }
    public void sagortayatiklandi()
    {
        soldami = false;
        sagdami = false;
        solortadami = false;
        sagortadami = true;
        solustdami = false;
        sagustdami = false;
        bombafirlatmabutonu.interactable = false;
        if (DataManager.Instance.rocketquantity >= 1)
        {
            fuzefirlatmabutonu.interactable = true;
        }
    }
    public void solustetiklandi()
    {
        soldami = false;
        sagdami = false;
        solortadami = false;
        sagortadami = false;
        solustdami = true;
        sagustdami = false;
        bombafirlatmabutonu.interactable = false;
        if (DataManager.Instance.rocketquantity >= 1)
        {
            fuzefirlatmabutonu.interactable = true;
        }
    }
    public void sagustetiklandi()
    {
        soldami = false;
        sagdami = false;
        solortadami = false;
        sagortadami = false;
        solustdami = false;
        sagustdami = true;
        bombafirlatmabutonu.interactable = false;
        if (DataManager.Instance.rocketquantity >= 1)
        {
            fuzefirlatmabutonu.interactable = true;
        }
    }
    Transform gecicibomba;

    public void bombayifirlat()
    {
        
        bombafirlatmabutonu.interactable = false;
        bombayiatti = true;
        DataManager.Instance.bombquantity--;
        DataManager.Instance.usedbomb++;
        if (soldami)
        {
            
            gecicibomba = Instantiate(bomb, namlusol.position, Quaternion.identity);
            gecicibomba.GetComponent<Rigidbody2D>().AddForce(namlusol.forward * 150);
            zamanial = Time.time + bombapatlamasuresi;
            bombanincapibuyutme();
            
        }
        else if (sagdami)
        {
            
            gecicibomba = Instantiate(bomb, namlusag.position, Quaternion.identity);
            gecicibomba.GetComponent<Rigidbody2D>().AddForce(namlusag.forward * 150);
            zamanial = Time.time + bombapatlamasuresi;
            bombanincapibuyutme();
            

        }
        DataManager.Instance.SaveData();
    }
    
    void bombanincapibuyutme()
    {
        if (bombayiatti)
        {
            
            if (Time.time>zamanial)
            {
                
                gecicibomba.GetComponent<CircleCollider2D>().radius = 4;
                bombayiatti = false;
                if (DataManager.Instance.bombquantity >= 1)
                {
                    bombafirlatmabutonu.interactable = true;
                }
                gecicibomba.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                gecicibomba.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            
        }
        if (DataManager.Instance.bombquantity >= 1 && DataManager.Instance.bombquantity <= 3)
        {
            bombbuybutton.interactable = true;
        }
    }
    public void fuzeyifirlat()
    {
        
        Transform gecicifuze;
        DataManager.Instance.rocketquantity--;
        DataManager.Instance.usedrocket++;
        if (DataManager.Instance.rocketquantity >= 1)
        {
            fuzefirlatmabutonu.interactable = true;
        }
        else
        {
            fuzefirlatmabutonu.interactable = false;
        }
        if (DataManager.Instance.rocketquantity >= 1 && DataManager.Instance.rocketquantity <= 3)
        {
            rocketbuybutton.interactable = true;
        }
        if (solortadami)
        {
            gecicifuze = Instantiate(rocket, namluortasol.position, Quaternion.identity);
            gecicifuze.transform.eulerAngles = new Vector3(gecicifuze.transform.eulerAngles.x, gecicifuze.transform.eulerAngles.y + 180, gecicifuze.transform.eulerAngles.z);
            gecicifuze.GetComponent<Rigidbody2D>().AddForce(namluortasol.forward * 500);

        }
        else if (sagortadami)
        {
            gecicifuze = Instantiate(rocket, namluortasag.position, Quaternion.identity);
            gecicifuze.GetComponent<Rigidbody2D>().AddForce(namluortasag.forward * 500);
        }
        else if (sagustdami)
        {
            gecicifuze = Instantiate(rocket, namluustsag.position, Quaternion.identity);
            gecicifuze.GetComponent<Rigidbody2D>().AddForce(namluustsag.forward * 500);
        }
        else if (solustdami)
        {
            gecicifuze = Instantiate(rocket, namluustsol.position, Quaternion.identity);
            gecicifuze.transform.eulerAngles = new Vector3(gecicifuze.transform.eulerAngles.x, gecicifuze.transform.eulerAngles.y + 180, gecicifuze.transform.eulerAngles.z);
            gecicifuze.GetComponent<Rigidbody2D>().AddForce(namluustsol.forward * 500);
            
        }
        
        DataManager.Instance.SaveData();
    }

    public void buylaser()
    {
        if (DataManager.Instance.laserquantity >= 1)
        {
            laserbutonu.interactable = true;
        }
        
    }
    public void lasermagic()
    {
        if (DataManager.Instance.laserquantity >=1) //depoda var mý
        {
            Instantiate(laser, lasersol.position, Quaternion.identity);
            Instantiate(laser, lasersolorta.position, Quaternion.identity);
            Instantiate(laser, lasersolust.position, Quaternion.identity);
        }
        DataManager.Instance.laserquantity--;
        DataManager.Instance.usedlaser++;
        if (DataManager.Instance.laserquantity >= 1 && DataManager.Instance.laserquantity <= 3)
        {
            laserbutonu.interactable = true;
        }
        else
        {
            laserbutonu.interactable = false;
        }
        DataManager.Instance.SaveData();
    }
    
    int gecicizamansayaci = 1;
    public void zamaniarttir()
    {
        if (gecicizamansayaci==1 || Time.timeScale == 1f)
        {
            Time.timeScale = 1.5f;
            gecicizamansayaci++;
            zamanhizlandir.GetComponent<Text>().text = "1.5x";
        }
        else if (gecicizamansayaci == 2 || Time.timeScale == 1.5f)
        {
            Time.timeScale = 2f;
            gecicizamansayaci++;
            zamanhizlandir.GetComponent<Text>().text = "2x";
        }
        else if (gecicizamansayaci == 3 || Time.timeScale == 2f)
        {
            Time.timeScale = 2.5f;
            gecicizamansayaci++;
            zamanhizlandir.GetComponent<Text>().text = "2.5x";
        }
        else if (gecicizamansayaci == 4 || Time.timeScale == 2.5f)
        {
            Time.timeScale = 3f; 
            gecicizamansayaci = 0;
            zamanhizlandir.GetComponent<Text>().text = "3x";
        }
        else if (gecicizamansayaci == 0 || Time.timeScale == 3f)
        {
            Time.timeScale = 1f;
            gecicizamansayaci++;
            zamanhizlandir.GetComponent<Text>().text = "1x";
        }

    }
    public void saldirihiziupgrade()  //saldýrý hýzý okey bitti
    {
        DataManager.Instance.LoadData();

        if (DataManager.Instance.mymoney >= 2000 && DataManager.Instance.bulletspeedupgradecounter == 0)
        {
            saldirihiziupgradecut(1.8f,2000,0, 4000);
            
        }
        else if (DataManager.Instance.mymoney >= 4000 && DataManager.Instance.bulletspeedupgradecounter == 1)
        {
            saldirihiziupgradecut(1.7f, 4000, 1, 8000);
            
        }
        else if (DataManager.Instance.mymoney >= 8000 && DataManager.Instance.bulletspeedupgradecounter == 2)
        {
            saldirihiziupgradecut(1.6f, 8000, 2, 15000);
            
        }
        else if (DataManager.Instance.mymoney >= 15000 && DataManager.Instance.bulletspeedupgradecounter == 3)
        {
            saldirihiziupgradecut(1.5f, 15000, 3, 50000);
           
        }
        else if (DataManager.Instance.mymoney >= 50000 && DataManager.Instance.bulletspeedupgradecounter == 4)
        {
            saldirihiziupgradecut(1.4f, 50000, 4, 80000);
            
        }
        else if (DataManager.Instance.mymoney >= 80000 && DataManager.Instance.bulletspeedupgradecounter == 5)
        {
            saldirihiziupgradecut(1.3f, 80000, 5, 100000);
            
        }
        else if (DataManager.Instance.mymoney >= 100000 && DataManager.Instance.bulletspeedupgradecounter == 6)
        {
            saldirihiziupgradecut(1.2f, 100000, 6, 140000);
            
        }
        else if (DataManager.Instance.mymoney >= 140000 && DataManager.Instance.bulletspeedupgradecounter == 7)
        {
            saldirihiziupgradecut(1.1f, 140000, 7, 160000);
            
        }
         else if (DataManager.Instance.mymoney >= 160000 && DataManager.Instance.bulletspeedupgradecounter == 8)
         {
            saldirihiziupgradecut(1.0f, 160000, 8, 180000);
            
         }
         else if (DataManager.Instance.mymoney >= 180000 && DataManager.Instance.bulletspeedupgradecounter == 9)
         {
            saldirihiziupgradecut(0.9f, 180000, 9, 200000);
            
         }
         else if (DataManager.Instance.mymoney >= 200000 && DataManager.Instance.bulletspeedupgradecounter == 10)
         {
            saldirihiziupgradecut(0.8f, 200000, 10, 250000);
            
         }
         else if (DataManager.Instance.mymoney >= 250000 && DataManager.Instance.bulletspeedupgradecounter == 11)
         {
            saldirihiziupgradecut(0.7f, 250000, 11, 300000);
            
         }
         else if (DataManager.Instance.mymoney >= 300000 && DataManager.Instance.bulletspeedupgradecounter == 12)
         {
            saldirihiziupgradecut(0.6f, 300000, 12, 400000);
            
         }
         else if (DataManager.Instance.mymoney >= 400000 && DataManager.Instance.bulletspeedupgradecounter == 13)
         {
            saldirihiziupgradecut(0.5f, 400000, 13, 500000);
            
         }
         else if (DataManager.Instance.mymoney >= 500000 && DataManager.Instance.bulletspeedupgradecounter == 14)
         {
            atismenzili = 0.4f;
            DataManager.Instance.bulletspeed = 0.4f;
            cointextt.GetComponent<Text>().text = "MAX";
            DataManager.Instance.mymoney -= 500000;
            bulletspeedminipicture[14].SetActive(false);
            DataManager.Instance.bulletspeedupgradecounter++;

        }
        DataManager.Instance.SaveData();



    }
    void saldirihiziupgradecut(float shotspeed, int bulletspeedprice, int dizininelemani, int newprice) //saldýrý hýzý okey bitti
    {
        atismenzili = shotspeed;
        DataManager.Instance.bulletspeed = shotspeed;
        cointextt.GetComponent<Text>().text = newprice.ToString();
        DataManager.Instance.mymoney -= bulletspeedprice;
        bulletspeedminipicture[dizininelemani].SetActive(false);
        DataManager.Instance.bulletspeedupgradecounter++;
        upgradesound.Play();

    }
    public void canupgrade()
    {
        DataManager.Instance.LoadData();

        if (DataManager.Instance.mymoney >= 1000 && DataManager.Instance.homehealupgradecounter == 0) //paran var mý ve hangi seviyedesin
        {
            canupgradecut(2000, 3000,0 , 1000);
            
        }
        else if (DataManager.Instance.mymoney >= 3000 && DataManager.Instance.homehealupgradecounter == 1)
        {
            canupgradecut(2500, 10000, 1, 3000);
            
        }
        else if (DataManager.Instance.mymoney >= 10000 && DataManager.Instance.homehealupgradecounter == 2)
        {
            canupgradecut(4000, 15000, 2, 10000);
            
        }
        else if (DataManager.Instance.mymoney >= 15000 && DataManager.Instance.homehealupgradecounter == 3)
        {
            canupgradecut(8000, 20000, 3, 15000);
            

        }
        else if (DataManager.Instance.mymoney >= 20000 && DataManager.Instance.homehealupgradecounter == 4)
        {
            canupgradecut(16000, 50000, 4, 20000);
            
        }
        else if (DataManager.Instance.mymoney >= 50000 && DataManager.Instance.homehealupgradecounter == 5)
        {
            canupgradecut(25000, 80000, 5, 50000);
            
        }
        else if (DataManager.Instance.mymoney >= 80000 && DataManager.Instance.homehealupgradecounter == 6)
        {
            canupgradecut(40000, 100000, 6, 80000);
            
        }
        else if (DataManager.Instance.mymoney >= 100000 && DataManager.Instance.homehealupgradecounter == 7)
        {
            canupgradecut(55000, 200000, 7, 100000);
            
        }
        else if (DataManager.Instance.mymoney >= 200000 && DataManager.Instance.homehealupgradecounter == 8)
        {
            canupgradecut(70000, 240000, 8, 200000);
            
        }
        else if (DataManager.Instance.mymoney >= 240000 && DataManager.Instance.homehealupgradecounter == 9)
        {
            canupgradecut(85000, 270000, 9, 240000);
            
            }
        else if (DataManager.Instance.mymoney >= 270000 && DataManager.Instance.homehealupgradecounter == 10)
        {
            canupgradecut(100000, 300000, 10, 270000);
            
        }
        else if (DataManager.Instance.mymoney >= 300000 && DataManager.Instance.homehealupgradecounter == 11)
        {
            canupgradecut(115000, 400000, 11, 300000);
            
        }
        else if (DataManager.Instance.mymoney >= 400000 && DataManager.Instance.homehealupgradecounter == 12)
        {
            canupgradecut(135000, 500000, 12, 400000);
            
        }
        else if (DataManager.Instance.mymoney >= 500000 && DataManager.Instance.homehealupgradecounter == 13)
        {
            DataManager.Instance.mymoney -= 500000;
            DataManager.Instance.maxhomeheal = 150000;
            healupgrademinipicture[13].SetActive(false);
            canupgradetext.GetComponent<Text>().text = "MAX";
            DataManager.Instance.homehealupgradecounter++; //14 olduðunda max yazdýr.********
        }
        slider.maxValue = DataManager.Instance.maxhomeheal;
        healthbartext.GetComponent<Text>().text = DataManager.Instance.homeheal + " / " + DataManager.Instance.maxhomeheal;
        DataManager.Instance.SaveData(); 

    } //can upgrade okey bitti
    void canupgradecut(float maxvalue, int newprice, int dizininelemani, int healtupgradeprice) // can upgrade okey bitti
    {
        DataManager.Instance.mymoney -= healtupgradeprice;
        DataManager.Instance.maxhomeheal = maxvalue;
        canupgradetext.GetComponent<Text>().text = newprice.ToString();
        healupgrademinipicture[dizininelemani].SetActive(false);
        DataManager.Instance.homehealupgradecounter++;
        upgradesound.Play();
    }
    public void canbas() //burayý düzelt textini nasýl ayarlýcaz amk?
    {

        DataManager.Instance.LoadData();
        
        if (DataManager.Instance.mymoney >= 30 && DataManager.Instance.whichlevel >= 0 && DataManager.Instance.whichlevel <= 2) 
        {

            
            DataManager.Instance.homeheal += 400;
            DataManager.Instance.usedhomeheal += 400;
            DataManager.Instance.mymoney -= 30;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 170 && DataManager.Instance.whichlevel >= 3 && DataManager.Instance.whichlevel <= 4)
        {
            
            DataManager.Instance.homeheal += 400;
            DataManager.Instance.usedhomeheal += 400;
            DataManager.Instance.mymoney -= 170;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 1000 && DataManager.Instance.whichlevel >= 5 && DataManager.Instance.whichlevel <= 7)
        {
            
            DataManager.Instance.homeheal += 1000; //800
            DataManager.Instance.usedhomeheal += 1000;
            DataManager.Instance.mymoney -= 1000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 2000 && DataManager.Instance.whichlevel >= 8 && DataManager.Instance.whichlevel <= 10)
        {
            
            DataManager.Instance.homeheal += 1800; //3k
            DataManager.Instance.usedhomeheal += 1800;
            DataManager.Instance.mymoney -= 2000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 4000 && DataManager.Instance.whichlevel >=11 && DataManager.Instance.whichlevel <= 14)
        {
            
            DataManager.Instance.homeheal += 6000;
            DataManager.Instance.usedhomeheal += 6000;
            DataManager.Instance.mymoney -= 4000;
            upgradesound.Play();
        }
        else if (DataManager.Instance.mymoney >= 9000 && DataManager.Instance.whichlevel >= 15 && DataManager.Instance.whichlevel <= 19)
        {
            
            DataManager.Instance.homeheal += 10000;
            DataManager.Instance.usedhomeheal += 10000;
            DataManager.Instance.mymoney -= 9000;
            upgradesound.Play();
        }

        if (DataManager.Instance.homeheal > DataManager.Instance.maxhomeheal)
        {
            DataManager.Instance.homeheal = DataManager.Instance.maxhomeheal;
        }
        healthcontrolforAD();
        DataManager.Instance.SaveData();

    }
    public void healthcontrolforAD()
    {
        slider.value = DataManager.Instance.homeheal;
        healthbartext.GetComponent<Text>().text = DataManager.Instance.homeheal + " / " + DataManager.Instance.maxhomeheal;
    }
}
