using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yaratikmanager : MonoBehaviour
{
    public float health, mermihizi;
    public float damage;
    public Transform mermi;
    public Transform floatingtext;
    public Slider slider;
    public GameObject slideringameobjeti;
    float atismenzili;
    float sonrakiatis;
    Transform namlu;
    public bool yuzunudegistireyim=false;
    Vector3 localscale;
    Rigidbody2D rb;
    public float movespeed = 5f;
    bool evdedurdumu = false;
    bool yariyoldaoldumu = false;
    public int yer;
    public GameObject coin;
    GameObject cointarget;
    public float coiningitmehizi;
    public bool aptalboyutlandýrmasorunu = false;
    Animator playeranimator;
    GameObject canavarsayacitext;
    public int canavarsayaci=0;
    GameObject altintext;
    public int verdigialtin = 0;
    public bool ejderhamisin = false;
    void Start()
    {
        cointarget = GameObject.Find("coinimage");
        canavarsayacitext = GameObject.Find("olen");
        altintext = GameObject.Find("cointext");
        localscale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        slider.maxValue = health;
        slider.value = health;
        atismenzili = 2f;
        sonrakiatis = Time.time;
        namlu = transform.GetChild(1);
        playeranimator = GetComponent<Animator>();
        yuzunudondur();
    }

    // Update is called once per frame
    void Update()
    {
        movela();
        shoott();
        coinanimation();
        colideriduzelt();
    }
    
    void coinanimation()
    {
        if (amided)
        {
            float step = coiningitmehizi * Time.deltaTime;

            coin.transform.position = Vector3.MoveTowards(coin.transform.position, cointarget.transform.position, step);
        }
        
        
    }
    
    void movela()
    {
        if (!yariyoldaoldumu)
        {
            localscale.x = yer;

            rb.velocity = new Vector2(localscale.x * movespeed, rb.velocity.y);
            
        }
        
    }
    void yuzunudondur() 
    {
        if (yuzunudegistireyim) {
            rb.transform.eulerAngles = new Vector3(
            rb.transform.eulerAngles.x,
            rb.transform.eulerAngles.y + 180,
            rb.transform.eulerAngles.z
            );
        }
        else
        {
            rb.transform.eulerAngles = new Vector3(
          rb.transform.eulerAngles.x,
          rb.transform.eulerAngles.y,
          rb.transform.eulerAngles.z
          );
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag=="mermi") {
            if (!amided)
            {
                getdamage(collision.GetComponent<HomeMermiManager>().damage);
                Destroy(collision.gameObject);
           }
            
            

        }
        

    }
    // yaratik çeþidi var bi tane onun animasyonunu düzeltiyor
    void colideriduzelt() {
        if (aptalboyutlandýrmasorunu & amided)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.86f, 1.5f);
        }
    
    }
    public void getdamage(float damage)
    {
        Instantiate(floatingtext, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        if ((health - damage) >= 0)
        {
            health -= damage;
            DataManager.Instance.setdamage += damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        amidead();
    }
    public bool amided = false;
     void amidead()
    {

        if (health <= 0)
        {
            string gecici;
            gecici = canavarsayacitext.GetComponent<Text>().text;
            canavarsayaci = Convert.ToInt32(gecici); 
            canavarsayaci++;
            canavarsayacitext.GetComponent<Text>().text = canavarsayaci.ToString();

            
            altintext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
            
            amided = true;
            slideringameobjeti.SetActive(false);
            playeranimator.SetBool("oldu", true);
            yariyoldaoldumu = true;
            coin.SetActive(true);
            coinanimation();
            Destroy(gameObject,2f);
            if (ejderhamisin)
            {
                rb.gravityScale = 1;
            }
            DataManager.Instance.mymoney += verdigialtin;
            DataManager.Instance.allmoney += verdigialtin;
            DataManager.Instance.killmonster++;
            DataManager.Instance.moneydatasave();

            
        }
    }


    public void stopanimation2()
    {

        playeranimator.SetBool("evdedurdu", false);
        evdedurdumu = false;

    }
    public void stopanimation()
    {

        playeranimator.SetBool("evdedurdu",true);
        evdedurdumu = true;

    }
    
    void shoott() {
        if (evdedurdumu & !amided) { 
        Transform mermicik;
        if (Time.time > sonrakiatis)
        {
            mermicik = Instantiate(mermi, namlu.position, Quaternion.identity);
            mermicik.GetComponent<Rigidbody2D>().AddForce(namlu.forward * mermihizi);
            sonrakiatis = Time.time + atismenzili;
        }
       }
    }
}
