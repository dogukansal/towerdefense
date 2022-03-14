using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour //gerekli yerlere savedata ekle
{
    public Slider slider;
    public Text olenyaratiksayaci;
    public Text oldurecekyaratiksayaci;

    public Text victorymonstertext;
    public Text victoryleveltext;
    public Text victoryadtext;
    public GameObject victoryscreen;
    public GameObject losescreen;
    public Text losemonstertext;

    public Button upgradebutonu;
    public Button bombabutonu;
    public Button fuzebutonu;
    public Button lazerbutonu;
    public Button oyunhizlandirmabutonu;
    public Button pausebutonu;
    int kaczombioldurulcek=0;


    public Transform sol;
    public Transform solorta;
    public Transform solust;
    public Transform sag;
    public Transform sagorta;
    public Transform sagust;
    //level logicleri
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public bool level5 = false;
    public bool level6 = false;
    public bool level7 = false;
    public bool level8 = false;
    public bool level9 = false;
    public bool level10 = false;
    public bool level11 = false;
    public bool level12 = false;
    public bool level13 = false;
    public bool level14 = false;
    public bool level15 = false;
    public bool level16 = false;
    public bool level17 = false;
    public bool level18 = false;
    public bool level19 = false;
    public bool level20 = false;
    //level1 yaratiklari
    public Transform monsterlevel1left;
    public Transform monsterlevel1right;
    //level 2 ama level1 yaratiklarý, sadece hareket hýzlarý hýzlý
    public Transform monsterlevel1leftfast;
    public Transform monsterlevel1rightfast;
    //level 3 yaratiklar
    public Transform monsterlevel2left;
    public Transform monsterlevel2right;
    //level 4 75x2 normal 25x1 fast
    public Transform monsterlevel2leftfast;
    public Transform monsterlevel2rightfast;
    //level 5 25x2 fast and boss
    public Transform bosslevel5;
    //level 6
    public Transform monsterlevel3left;
    public Transform monsterlevel3right;
    //level 7
    public Transform dragonlevel1leftslow;
    public Transform dragonlevel1rightslow;

    //level 8
    public Transform monsterlevel4leftslow;
    public Transform monsterlevel4rightslow;

    //level 9
    public Transform dragonlevel2leftslow;
    public Transform dragonlevel2rightslow;

    public Transform dragonlevel2left;
    public Transform dragonlevel2right;

    //level 10
    public Transform dragonlevel1left;
    public Transform dragonlevel1right;

    public Transform monsterlevel4left;
    public Transform monsterlevel4right;
    public Transform bosslevel10;

    //level 11
    public Transform monsterlevel3leftfast;
    public Transform monsterlevel3rightfast;
    //level 12
    public Transform dragonlevel3left;
    public Transform dragonlevel3right;

    public Transform monsterlevel5left;
    public Transform monsterlevel5right;

    //level 13
    public Transform monsterlevel4leftfast;
    public Transform monsterlevel4rightfast;

    public Transform monsterlevel5leftfast;
    public Transform monsterlevel5rightfast;

    public Transform dragonlevel1leftfast;
    public Transform dragonlevel1rightfast;

    public Transform dragonlevel2leftfast;
    public Transform dragonlevel2rightfast;

    public Transform dragonlevel3leftfast;
    public Transform dragonlevel3rightfast;

    //level 14 250x e3 fast
    // level 15 boss and 100x6 slow
    public Transform monsterlevel6leftslow;
    public Transform monsterlevel6rightslow;

    public Transform bosslevel15;
    //level 16
    public Transform monsterlevel6leftfast;
    public Transform monsterlevel6rightfast;

    public Transform dragonlevel4leftslow;
    public Transform dragonlevel4rightslow;
    //level 17
    public Transform dragonlevel5leftfast;
    public Transform dragonlevel5rightfast;

    public Transform monsterlevel7leftfast;
    public Transform monsterlevel7rightfast;

    public Transform dragonlevel4leftfast;
    public Transform dragonlevel4rightfast;
    //level 18
    public Transform dragonlevel6leftfast;
    public Transform dragonlevel6rightfast;
    //level 19

    public Transform bosslevel15fastleft;
    public Transform bosslevel5fastleft;
    public Transform bosslevel10fastleft;
    //muzikler
    public AudioSource level1music;
    public AudioSource level2music;
    public AudioSource level3music;
    public AudioSource level4music;
    public AudioSource level5music;
    public AudioSource level6music;
    public AudioSource level7music;
    public AudioSource level8music;
    public AudioSource level9music;
    public AudioSource level10music;
    public AudioSource bossmusic;
    public AudioSource winmusic;
    public AudioSource losemusic;
    public Slider evcanbari;
    public Text gameinmoneytext;
    

    int sayac = 0;

    public float dogmasuresi;
    float zaman;
    void Start()
    {
        Time.timeScale = 1;
        anamenudenlevelbilgisicek();
        
        levelspawnsayac();
        slider.maxValue = kaczombioldurulcek;
        oldurecekyaratiksayaci.GetComponent<Text>().text = kaczombioldurulcek.ToString();
        zaman = Time.time;
        firstbegingold = DataManager.Instance.mymoney;
        gameinmoneytext.GetComponent<Text>().text = firstbegingold.ToString();
        if (!DataManager.Instance.muzik)
        {
            stopallmusic();
        }
    }
    
    void Update()
    {
        levelspawner();
        losecheck();
    }
    void anamenudenlevelbilgisicek()
    {
        if (DataManager.Instance.returnlevel()==0)
        {
            level1 = true;
        }
        else if (DataManager.Instance.returnlevel() == 1)
        {
            level2 = true;
        }
        else if (DataManager.Instance.returnlevel() == 2)
        {
            level3 = true;
        }
        else if (DataManager.Instance.returnlevel() == 3)
        {
            level4 = true;
        }
        else if (DataManager.Instance.returnlevel() == 4)
        {
            level5 = true;
        }
        else if (DataManager.Instance.returnlevel() == 5)
        {
            level6 = true;
        }
        else if (DataManager.Instance.returnlevel() == 6)
        {
            level7 = true;
        }
        else if (DataManager.Instance.returnlevel() == 7)
        {
            level8 = true;
        }
        else if (DataManager.Instance.returnlevel() == 8)
        {
            level9 = true;
        }
        else if (DataManager.Instance.returnlevel() == 9)
        {
            level10 = true;
        }
        else if (DataManager.Instance.returnlevel() == 10)
        {
            level11 = true;
        }
        else if (DataManager.Instance.returnlevel() == 11)
        {
            level12 = true;
        }
        else if (DataManager.Instance.returnlevel() == 12)
        {
            level13 = true;
        }
        else if (DataManager.Instance.returnlevel() == 13)
        {
            level14 = true;
        }
        else if (DataManager.Instance.returnlevel() == 14)
        {
            level15 = true;
        }
        else if (DataManager.Instance.returnlevel() == 15)
        {
            level16 = true;
        }
        else if (DataManager.Instance.returnlevel() == 16)
        {
            level17 = true;
        }
        else if (DataManager.Instance.returnlevel() == 17)
        {
            level18 = true;
        }
        else if (DataManager.Instance.returnlevel() == 18)
        {
            level19 = true;
        }
        else if (DataManager.Instance.returnlevel() == 19)
        {
            level20 = true;
        }
        

    }
    
    void levelspawnsayac()
    {
        if (level1)
        {
            kaczombioldurulcek = 50;
            level1music.Play();
        }
        else if (level2)
        {
            kaczombioldurulcek = 100;
            level2music.Play();
        }
        else if (level3)
        {
            kaczombioldurulcek = 50;
            level3music.Play();
        }
        else if (level4)
        {
            kaczombioldurulcek = 100;
            level4music.Play();
        }
        else if (level5)
        {
            kaczombioldurulcek = 25;
            bossmusic.Play();
        }
        else if (level6)
        {
            kaczombioldurulcek = 50;
            level6music.Play();
        }
        else if (level7)
        {
            kaczombioldurulcek = 75;
            level7music.Play();
        }
        else if (level8)
        {
            kaczombioldurulcek = 50;
            level8music.Play();
        }
        else if (level9)
        {
            kaczombioldurulcek = 150;
            level9music.Play();
        }
        else if (level10)
        {
            kaczombioldurulcek = 75;
            bossmusic.Play();
        }
        else if (level11)
        {
            kaczombioldurulcek = 200;
            level10music.Play();
        }
        else if (level12)
        {
            kaczombioldurulcek = 100;
            level1music.Play();
        }
        else if (level13)
        {
            kaczombioldurulcek = 250;
            level2music.Play();
        }
        else if (level14)
        {
            kaczombioldurulcek = 150;
            level3music.Play();
        }
        else if (level15)
        {
            kaczombioldurulcek = 50;
            bossmusic.Play();
        }
        else if (level16)
        {
            kaczombioldurulcek = 150;
            level4music.Play();
        }
        else if (level17)
        {
            kaczombioldurulcek = 300;
            level5music.Play();
        }
        else if (level18)
        {
            kaczombioldurulcek = 200;
            level6music.Play();
        }
        else if (level19)
        {
            kaczombioldurulcek = 210;
            level7music.Play();
        }
        else if (level20)
        {
            kaczombioldurulcek = 50;
            bossmusic.Play();
        }
        

    }
    void stopallmusic()
    {
        level1music.Stop();
        level2music.Stop();
        level3music.Stop();
        level4music.Stop();
        level5music.Stop();
        level6music.Stop();
        level7music.Stop();
        level8music.Stop();
        level9music.Stop();
        level10music.Stop();
        bossmusic.Stop();
    }
     void geciktir()
    {
        Time.timeScale = 0;
    }
    bool gecicimoneylogic = true;
    void levelspawner()
    {
        kontrol();
        if (level1)
        {
            spawnerlevel1();
            if (gecici == gecici2)
            {
               
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text = 50.ToString();
                victoryleveltext.GetComponent<Text>().text =50.ToString();
                victoryadtext.GetComponent<Text>().text =100.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 50;
                    DataManager.Instance.moneydatasave();
                }
                
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);
            }
        }
        else if (level2)
        {
            spawnerlevel2();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =200.ToString();
                victoryleveltext.GetComponent<Text>().text =200.ToString();
                victoryadtext.GetComponent<Text>().text =400.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 200;
                    DataManager.Instance.moneydatasave();
                }
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level3)
        {
            spawnerlevel3();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =150.ToString();
                victoryleveltext.GetComponent<Text>().text =350.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 350;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =500.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);


            }
        }
        else if (level4)
        {
            spawnerlevel4();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =350.ToString();
                victoryleveltext.GetComponent<Text>().text =650.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 650;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =1000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);


            }
        }
        else if (level5)
        {
            spawnerlevel5();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =196.ToString();
                victoryleveltext.GetComponent<Text>().text =1804.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 1804;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =1000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);


            }
        }
        else if (level6)
        {
            spawnerlevel6();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =500.ToString();
                victoryleveltext.GetComponent<Text>().text =3500.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 3500;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =4000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level7)
        {
            spawnerlevel7();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =975.ToString();
                victoryleveltext.GetComponent<Text>().text =5025.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 5025;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =6000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level8)
        {
            spawnerlevel8();
            if (gecici == gecici2)
            {
                
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =1250.ToString();
                victoryleveltext.GetComponent<Text>().text =6750.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 6750;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =8000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level9)
        {
            spawnerlevel9();
            if (gecici == gecici2)
            {
             
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =2875.ToString();
                victoryleveltext.GetComponent<Text>().text =7125.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 7125;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =10000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level10)
        {
            spawnerlevel10();
            if (gecici == gecici2)
            {

                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =2050.ToString();
                victoryleveltext.GetComponent<Text>().text =10200.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 10200;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =12500.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level11)
        {
            spawnerlevel11();
            if (gecici == gecici2)
            {
    
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =5500.ToString();
                victoryleveltext.GetComponent<Text>().text =14500.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 14500;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =15000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level12)
        {
            spawnerlevel12();
            if (gecici == gecici2)
            {
    
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =8750.ToString();
                victoryleveltext.GetComponent<Text>().text =16250.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 16250;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =25000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level13)
        {
            spawnerlevel13();
            if (gecici == gecici2)
            {
    
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text = 14625.ToString(); //14625 9875
                victoryleveltext.GetComponent<Text>().text =20375.ToString(); 
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 20375;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =40000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level14)
        {
            spawnerlevel14();
            if (gecici == gecici2)
            {
       
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =15000.ToString();
                victoryleveltext.GetComponent<Text>().text =35000.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 35000;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =45000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level15)
        {
            spawnerlevel15();
            if (gecici == gecici2)
            {
              
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =8500.ToString();
                victoryleveltext.GetComponent<Text>().text =41500.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 41500;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =50000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level16)
        {
            spawnerlevel16();
            if (gecici == gecici2)
            {
           
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =17500.ToString();
                victoryleveltext.GetComponent<Text>().text =47500.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 47500;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =60000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level17)
        {
            spawnerlevel17();
            if (gecici == gecici2)
            {
             
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =55000.ToString();
                victoryleveltext.GetComponent<Text>().text =55000.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 55000;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =50000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level18)
        {
            spawnerlevel18();
            if (gecici == gecici2)
            {
              
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =30000.ToString();
                victoryleveltext.GetComponent<Text>().text =70000.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 70000;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =70000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level19)
        {
            spawnerlevel19();
            if (gecici == gecici2)
            {
        
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =60000.ToString();
                victoryleveltext.GetComponent<Text>().text =70000.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 70000;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =70000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
        else if (level20)
        {
            spawnerlevel20();
            if (gecici == gecici2)
            {
      
                victoryscreen.SetActive(true);
                victorymonstertext.GetComponent<Text>().text =50000.ToString();
                victoryleveltext.GetComponent<Text>().text =100000.ToString();
                if (gecicimoneylogic)
                {
                    gecicimoneylogic = false;
                    DataManager.Instance.mymoney += 100000;
                    DataManager.Instance.moneydatasave();
                }
                victoryadtext.GetComponent<Text>().text =100000.ToString();
                gameinmoneytext.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
                Invoke("geciktir", 3f);

            }
        }
    }
    string gecici, gecici2;
    bool dahaoncecaldimi = false;
    void kontrol()
    {
        
        gecici = olenyaratiksayaci.GetComponent<Text>().text;
        gecici2 = oldurecekyaratiksayaci.GetComponent<Text>().text;
        slider.value = Convert.ToInt32(gecici);
        if (gecici == gecici2)
        {
            
            endgamebutonlar();
            stopallmusic();
            if (!winmusic.isPlaying && !dahaoncecaldimi)
            {
                winmusic.Play();
                dahaoncecaldimi = true;
            }
            
        }


       
}
    int firstbegingold;
    void losecheck() 
    {
        if (evcanbari.value<=0)
        {

            endgamebutonlar();
            stopallmusic();
            losescreen.SetActive(true);
            losemonstertext.GetComponent<Text>().text = (DataManager.Instance.mymoney - firstbegingold ). ToString();
            if (!losemusic.isPlaying && !dahaoncecaldimi)
            {
                losemusic.Play();
                dahaoncecaldimi = true;
            }
            Time.timeScale = 0;
        }
        
    }
    void endgamebutonlar()
    {
        upgradebutonu.interactable = false;
        bombabutonu.interactable = false;
        fuzebutonu.interactable = false;
        lazerbutonu.interactable = false;
        oyunhizlandirmabutonu.interactable = false;
        pausebutonu.interactable = false;
    }
    int rastgelesagsol;
    int hangiyaratik;
    int rastgelesagvesol()
    {
        rastgelesagsol = UnityEngine.Random.Range(0, 1 + 1);
        return rastgelesagsol;
    }
    int rastgelesagvesolejderha()
    {
        rastgelesagsol = UnityEngine.Random.Range(0, 1 + 1);
        return rastgelesagsol;
    }
    int yaratikcesidi()
    {
        hangiyaratik = UnityEngine.Random.Range(0, 1 + 1);
        if (tutamac1logic)
        {
            hangiyaratik = 1;
        }
        else if (tutamac2logic)
        {
            hangiyaratik = 0;
        }
        
        return hangiyaratik;
    }
    
    

    bool ucluyaratik = false;
    bool dortluyaratik = false;
    bool altiliyaratik = false;
    ArrayList yaratiktut = new ArrayList() { 0, 1, 2 };
    ArrayList yaratiktut2 = new ArrayList() { 0, 1, 2, 3 };
    ArrayList yaratiktut3 = new ArrayList() { 0, 1, 2, 3, 4, 5 };
    int diziningecicisi;
    int yaratiktuctenfazla()
    {

        if (ucluyaratik)
        {

            if (tutamac1logic)
            {

                if (yaratiktut.Contains(0))
                {
                    yaratiktut.Remove(0);
                }

            }
            else if (tutamac2logic)
            {
                if (yaratiktut.Contains(1) )
                {
                    yaratiktut.Remove(1);
                }
            }
            else if (tutamac3logic)
            {
                if (yaratiktut.Contains(2) )
                {
                    yaratiktut.Remove(2);
                }
            }
            hangiyaratik = UnityEngine.Random.Range(0, yaratiktut.Count );
            diziningecicisi =(int) yaratiktut[hangiyaratik];

            
        }
        else if (dortluyaratik)
        {
            
            if (tutamac1logic)
            {
                if (yaratiktut2.Contains(0))
                {
                    yaratiktut2.Remove(0);
                }
            }
            else if (tutamac2logic)
            {
                if (yaratiktut2.Contains(1) )
                {
                    yaratiktut2.Remove(1);
                }
            }
            else if (tutamac3logic)
            {
                if (yaratiktut2.Contains(2))
                {
                    yaratiktut2.Remove(2);
                }
            }
            else if (tutamac4logic)
            {
                if (yaratiktut2.Contains(3))
                {
                    yaratiktut2.Remove(3);
                }
            }
            hangiyaratik = UnityEngine.Random.Range(0, yaratiktut2.Count );
            diziningecicisi = (int)yaratiktut2[hangiyaratik];

            

        }

        else if (altiliyaratik)
        {

            if (tutamac1logic)
            {
                if (yaratiktut3.Contains(0))
                {
                    yaratiktut3.Remove(0);
                }
            }
            else if (tutamac2logic)
            {
                if (yaratiktut3.Contains(1) )
                {
                    yaratiktut3.Remove(1);
                }
            }
            else if (tutamac3logic)
            {
                if (yaratiktut3.Contains(2) )
                {
                    yaratiktut3.Remove(2);
                }
            }
            else if (tutamac4logic)
            {
                if (yaratiktut3.Contains(3))
                {
                    yaratiktut3.Remove(3);
                }
            }
            else if (tutamac5logic)
            {
                if (yaratiktut3.Contains(4) )
                {
                    yaratiktut3.Remove(4);
                }
            }
            else if (tutamac6logic)
            {
                if (yaratiktut3.Contains(5) )
                {
                    yaratiktut3.Remove(5);
                }
            }
            hangiyaratik = UnityEngine.Random.Range(0, yaratiktut3.Count );
            diziningecicisi = (int)yaratiktut3[hangiyaratik];



        }
        return diziningecicisi;

    }
    
    void spawnlevel(Transform yaratik, Transform yonu)
    {
        sayac++;
        Instantiate(yaratik, yonu.position, Quaternion.identity);
        zaman = Time.time + dogmasuresi;
        
    }

    int tutamac1 = 0;
    bool tutamac1logic = false;
    int tutamac2 = 0;
    bool tutamac2logic = false;
    int tutamac3 = 0;
    bool tutamac3logic = false;
    int tutamac4 = 0;
    bool tutamac4logic = false;
    int tutamac5 = 0;
    bool tutamac5logic = false;
    int tutamac6 = 0;
    bool tutamac6logic = false;
    bool bossdurum = false;
    bool durum1 = false;
    
    
    //level1 13 1 8 2
    void spawnerlevel1()
    {
        if (Time.time > zaman)
        {
            if (sayac!=50 && !durum1)
            {
                if (rastgelesagvesol()==0)
                {
                    spawnlevel(monsterlevel1left, sol);
                }
                else if (rastgelesagvesol() == 1)
                {
                    spawnlevel(monsterlevel1right, sag);
                }

            }
            if (sayac==50)
            {
                durum1 = true;
            }
        }
    }
    void spawnerlevel2()
    {
        if (Time.time > zaman)
        {
            if (sayac != 100)
            {
                if (rastgelesagvesol() == 0)
                {
                    spawnlevel(monsterlevel1leftfast, sol);
                }
                else if (rastgelesagvesol() == 1)
                {
                    spawnlevel(monsterlevel1rightfast, sag);
                }

            }
            if (sayac == 100)
            {
                durum1 = true;
            }
        }
    }
    void spawnerlevel3()
    {
        if (Time.time > zaman)
        {
            if (sayac != 50 && !durum1)
            {
                
                if (rastgelesagvesol() == 0)
                {
                    
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel1leftfast, sol);
                        tutamac1++;
                        if (tutamac1==25)
                        {
                            tutamac1logic = true;
                        }
                        
                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel2left, sol);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel1rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel2right, sag);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                }

            }
            if (sayac == 50)
            {
                durum1 = true;
            }
        }
    }
    void spawnerlevel4()
    {
        if (Time.time > zaman)
        {
            if (sayac != 100 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel1leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel2leftfast, sol);
                        tutamac2++;
                        if (tutamac2 == 75)
                        {
                            tutamac2logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel1rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel2rightfast, sag);
                        tutamac2++;
                        if (tutamac2 == 75)
                        {
                            tutamac2logic = true;
                        }
                    }
                }
                if (sayac == 100)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel5()
    {
        if (Time.time > zaman)
        {

            if (sayac != 25 && !durum1)
            {
                spawnlevel(monsterlevel2leftfast, sol);
               
            }
            if (!bossdurum)
            {
                spawnlevel(bosslevel5, sag);
                bossdurum = true;
            }
            if (sayac == 25)
            {
                durum1 = true;
            }
        }


    }

    void spawnerlevel6()
    {
        if (Time.time > zaman)
        {
            if (sayac != 50 && !durum1)
            {

                if (rastgelesagvesol() == 0)
                {
                    spawnlevel(monsterlevel3left, sol);
                }
                else if (rastgelesagvesol() == 1)
                {
                    spawnlevel(monsterlevel3right, sag);
                }

            }

            if (sayac == 50)
            {
                durum1 = true;
            }
        }

    
    }
    
    void spawnerlevel7()
    {
        ucluyaratik = true;
        if (Time.time > zaman)
        {
            if (sayac != 75 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel2leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(dragonlevel1leftslow, solorta);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(monsterlevel3left, sol);
                        tutamac3++;
                        if (tutamac3 == 25)
                        {
                            tutamac3logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel2rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(dragonlevel1rightslow, sagorta);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(monsterlevel3right, sag);
                        tutamac3++;
                        if (tutamac3 == 25)
                        {
                            tutamac3logic = true;
                        }
                    }
                }
                if (sayac == 75)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel8()
    {
        if (Time.time > zaman)
        {
            if (sayac != 50 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel4leftslow, sol);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(dragonlevel1leftslow, solorta);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel4rightslow, sag);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(dragonlevel1rightslow, sagorta);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                }
                if (sayac == 50)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel9()
    {
        altiliyaratik = true;
        if (Time.time > zaman)
        {
            if (sayac != 150 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel1leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel2leftfast, sol);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(monsterlevel3leftfast, sol);
                        tutamac3++;
                        if (tutamac3 == 25)
                        {
                            tutamac3logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 3 && !tutamac4logic)
                    {
                        spawnlevel(monsterlevel4leftslow, sol);
                        tutamac4++;
                        if (tutamac4 == 25)
                        {
                            tutamac4logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 4 && !tutamac5logic)
                    {
                        spawnlevel(dragonlevel1left, solorta);
                        tutamac5++;
                        if (tutamac5 == 25)
                        {
                            tutamac5logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 5 && !tutamac6logic)
                    {
                        spawnlevel(dragonlevel2leftslow, solorta);
                        tutamac6++;
                        if (tutamac6 == 25)
                        {
                            tutamac6logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel1rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel2rightfast, sag);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(monsterlevel3rightfast, sag);
                        tutamac3++;
                        if (tutamac3 == 25)
                        {
                            tutamac3logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 3 && !tutamac4logic)
                    {
                        spawnlevel(monsterlevel4rightslow, sag);
                        tutamac4++;
                        if (tutamac4 == 25)
                        {
                            tutamac4logic = true;
                        }
                    }

                    else if (yaratiktuctenfazla() == 4 && !tutamac5logic)
                    {
                        spawnlevel(dragonlevel1right, sagorta);
                        tutamac5++;
                        if (tutamac5 == 25)
                        {
                            tutamac5logic = true;
                        }
                    }

                    else if (yaratiktuctenfazla() == 5 && !tutamac6logic)
                    {
                        spawnlevel(dragonlevel2rightslow, sagorta);
                        tutamac6++;
                        if (tutamac6 == 25)
                        {
                            tutamac6logic = true;
                        }
                    }
                }

                if (sayac == 200)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel10()
    {
        
        if (Time.time > zaman)
        {
            if (sayac != 75 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {

                
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel4leftslow, sol);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(dragonlevel1leftslow, solorta);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel4rightslow, sag);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        spawnlevel(dragonlevel1leftslow, solorta);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                }

            }
            if (!bossdurum)
            {
                spawnlevel(bosslevel10, sagorta);
                bossdurum = true;
            }
            if (sayac == 75)
            {
                durum1 = true;
            }
        }
    }
    void spawnerlevel11()
    {
        dortluyaratik = true;
        if (Time.time > zaman )
        {
            if (sayac != 200 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel3leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel4left, sol);
                        tutamac2++;
                        if (tutamac2 == 50)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(dragonlevel1left, solorta);
                        tutamac3++;
                        if (tutamac3 == 50)
                        {
                            tutamac3logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 3 && !tutamac4logic)
                    {
                        spawnlevel(dragonlevel2left, solorta);
                        tutamac4++;
                        if (tutamac4 == 50)
                        {
                            tutamac4logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel3rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel4right, sag);
                        tutamac2++;
                        if (tutamac2 == 50)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(dragonlevel1right, sagorta);
                        tutamac3++;
                        if (tutamac3 == 50)
                        {
                            tutamac3logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 3 && !tutamac4logic)
                    {
                        spawnlevel(dragonlevel2right, sagorta);
                        tutamac4++;
                        if (tutamac4 == 50)
                        {
                            tutamac4logic = true;
                        }
                    }
                }

                if (sayac == 200)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel12()
    {
        if (Time.time > zaman)
        {
            if (sayac != 100 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel5left, sol);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha()==0)
                        {
                            spawnlevel(dragonlevel3left, solorta);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel3left, solust);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel5right, sag);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel3right, sagorta);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel3right, sagust);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }
                }
                if (sayac == 100)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel13()
    {
        altiliyaratik = true;
        if (Time.time > zaman )
        {
            if (sayac != 250 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel3leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel4leftfast, sol);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(monsterlevel5leftfast, sol);
                        tutamac3++;
                        if (tutamac3 == 75)
                        {
                            tutamac3logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 3 && !tutamac4logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel1leftfast, solorta);
                            tutamac4++;
                            if (tutamac4 == 25)
                            {
                                tutamac4logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel1leftfast, solust);
                            tutamac4++;
                            if (tutamac4 == 25)
                            {
                                tutamac4logic = true;
                            }
                        }
                        
                        
                    }
                    else if (yaratiktuctenfazla() == 4 && !tutamac5logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel2leftfast, solorta);
                            tutamac5++;
                            if (tutamac5 == 50)
                            {
                                tutamac5logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel2leftfast, solust);
                            tutamac5++;
                            if (tutamac5 == 50)
                            {
                                tutamac5logic = true;
                            }
                        }
                        
                        
                    }
                    else if (yaratiktuctenfazla() == 5 && !tutamac6logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel3leftfast, solorta);
                            tutamac6++;
                            if (tutamac6 == 50)
                            {
                                tutamac6logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel3leftfast, solust);
                            tutamac6++;
                            if (tutamac6 == 50)
                            {
                                tutamac6logic = true;
                            }
                        }
                        
                        
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel3rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        spawnlevel(monsterlevel4rightfast, sag);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(monsterlevel5rightfast, sag);
                        tutamac3++;
                        if (tutamac3 == 75)
                        {
                            tutamac3logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 3 && !tutamac4logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel1rightfast, sagorta);
                            tutamac4++;
                            if (tutamac4 == 25)
                            {
                                tutamac4logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel1rightfast, sagust);
                            tutamac4++;
                            if (tutamac4 == 25)
                            {
                                tutamac4logic = true;
                            }
                        }
                        
                        
                    }

                    else if (yaratiktuctenfazla() == 4 && !tutamac5logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel2rightfast, sagorta);
                            tutamac5++;
                            if (tutamac5 == 50)
                            {
                                tutamac5logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel2rightfast, sagust);
                            tutamac5++;
                            if (tutamac5 == 50)
                            {
                                tutamac5logic = true;
                            }
                        }
                        
                        
                    }

                    else if (yaratiktuctenfazla() == 5 && !tutamac6logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel3rightfast, sagorta);
                            tutamac6++;
                            if (tutamac6 == 50)
                            {
                                tutamac6logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel3rightfast, sagust);
                            tutamac6++;
                            if (tutamac6 == 50)
                            {
                                tutamac6logic = true;
                            }
                        }
                        
                        
                    }
                }

                if (sayac == 250)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel14()
    {
        if (Time.time > zaman)
        {
            if (sayac != 150 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (rastgelesagvesolejderha() == 0)
                    {
                        spawnlevel(dragonlevel3leftfast, solorta);
                    }
                    else if (rastgelesagvesolejderha() == 1)
                    {
                        spawnlevel(dragonlevel3leftfast, solust);
                    }
                    
                }
                else if (rastgelesagvesol() == 1)
                {
                    if (rastgelesagvesolejderha() == 0)
                    {
                        spawnlevel(dragonlevel3rightfast, sagorta);
                    }
                    else if (rastgelesagvesolejderha() == 1)
                    {
                        spawnlevel(dragonlevel3rightfast, sagust);
                    }
                    
                }

            }
            if (sayac == 150)
            {
                durum1 = true;
            }
        }


    }
    void spawnerlevel15() 
    {
        if (Time.time > zaman)
        {
            if (sayac != 50 && !durum1)
            {
                if (rastgelesagvesol()==0)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(dragonlevel2leftslow, solorta);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        
                        spawnlevel(monsterlevel6leftslow, sol);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                } 
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(dragonlevel2rightslow, sagorta);
                        tutamac1++;
                        if (tutamac1 == 25)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {

                        spawnlevel(monsterlevel6rightslow, sag);
                        tutamac2++;
                        if (tutamac2 == 25)
                        {
                            tutamac2logic = true;
                        }
                    }
                }

            }

            
            if (!bossdurum)
            {
                spawnlevel(bosslevel15, sag);
                bossdurum = true;
            }
            if (sayac == 50)
            {
                durum1 = true;
            }
        }


    }
    void spawnerlevel16()
    {
        ucluyaratik = true;
        if (Time.time > zaman)
        {
            if (sayac != 150 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel6leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel4leftslow, solorta);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel4leftslow, solust);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel3leftfast, solorta);
                            tutamac3++;
                            if (tutamac3 == 50)
                            {
                                tutamac3logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel3leftfast, solust);
                            tutamac3++;
                            if (tutamac3 == 50)
                            {
                                tutamac3logic = true;
                            }
                        }
                        
                        
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel6rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 50)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel4rightslow, sagorta);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel4rightslow, sagust);
                            tutamac2++;
                            if (tutamac2 == 50)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel3rightfast, sagorta);
                            tutamac3++;
                            if (tutamac3 == 50)
                            {
                                tutamac3logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel3rightfast, sagust);
                            tutamac3++;
                            if (tutamac3 == 50)
                            {
                                tutamac3logic = true;
                            }
                        }
                        
                        
                    }
                }
                if (sayac == 150)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel17()
    {
        ucluyaratik = true;
        if (Time.time > zaman)
        {
            if (sayac != 300 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel7leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 100)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel4leftfast, solorta);
                            tutamac2++;
                            if (tutamac2 == 100)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel4leftfast, solust);
                            tutamac2++;
                            if (tutamac2 == 100)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel5leftfast, solorta);
                            tutamac3++;
                            if (tutamac3 == 100)
                            {
                                tutamac3logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel5leftfast, solust);
                            tutamac3++;
                            if (tutamac3 == 100)
                            {
                                tutamac3logic = true;
                            }
                        }
                        
                        
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel7rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 100)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel4rightfast, sagorta);
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel4rightfast, sagust);
                        }
                        
                        tutamac2++;
                        if (tutamac2 == 100)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel5rightfast, sagorta);
                            tutamac3++;
                            if (tutamac3 == 100)
                            {
                                tutamac3logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel5rightfast, sagust);
                            tutamac3++;
                            if (tutamac3 == 100)
                            {
                                tutamac3logic = true;
                            }
                        }
                        
                        
                    }
                }
                if (sayac == 300)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel18()
    {
        if (Time.time > zaman)
        {
            if (sayac != 200 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(bosslevel5fastleft, sol);
                        tutamac1++;
                        if (tutamac1 == 100)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(bosslevel10fastleft, solorta);
                            tutamac2++;
                            if (tutamac2 == 100)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(bosslevel10fastleft, solust);
                            tutamac2++;
                            if (tutamac2 == 100)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratikcesidi() == 0 && !tutamac1logic)
                    {
                        spawnlevel(bosslevel5, sag);
                        tutamac1++;
                        if (tutamac1 == 100)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratikcesidi() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(bosslevel10, sagorta);
                            tutamac2++;
                            if (tutamac2 == 100)
                            {
                                tutamac2logic = true;
                            }
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(bosslevel10, sagust);
                            tutamac2++;
                            if (tutamac2 == 100)
                            {
                                tutamac2logic = true;
                            }
                        }
                        
                        
                    }
                }
                if (sayac == 200)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel19()
    {
        ucluyaratik = true;
        if (Time.time > zaman)
        {
            if (sayac != 210 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel7leftfast, sol);
                        tutamac1++;
                        if (tutamac1 == 100)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel6leftfast, solorta);
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel6leftfast, solust);
                        }
                        
                        tutamac2++;
                        if (tutamac2 == 100)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(bosslevel15fastleft, sol);
                        tutamac3++;
                        if (tutamac3 == 10)
                        {
                            tutamac3logic = true;
                        }
                    }


                }
                else if (rastgelesagvesol() == 1)
                {
                    if (yaratiktuctenfazla() == 0 && !tutamac1logic)
                    {
                        spawnlevel(monsterlevel7rightfast, sag);
                        tutamac1++;
                        if (tutamac1 == 100)
                        {
                            tutamac1logic = true;
                        }

                    }
                    else if (yaratiktuctenfazla() == 1 && !tutamac2logic)
                    {
                        if (rastgelesagvesolejderha() == 0)
                        {
                            spawnlevel(dragonlevel6rightfast, sagorta);
                        }
                        else if (rastgelesagvesolejderha() == 1)
                        {
                            spawnlevel(dragonlevel6rightfast, sagust);
                        }
                        
                        tutamac2++;
                        if (tutamac2 == 100)
                        {
                            tutamac2logic = true;
                        }
                    }
                    else if (yaratiktuctenfazla() == 2 && !tutamac3logic)
                    {
                        spawnlevel(bosslevel15, sag);
                        tutamac3++;
                        if (tutamac3 == 10)
                        {
                            tutamac3logic = true;
                        }
                    }
                }
                if (sayac == 210)
                {
                    durum1 = true;
                }
            }

        }
    }
    void spawnerlevel20()
    {
        if (Time.time > zaman)
        {
            if (sayac != 50 && !durum1)
            {
                if (rastgelesagvesol() == 0)
                {
                    spawnlevel(bosslevel15fastleft, sol);
                }
                else if (rastgelesagvesol() == 1)
                {
                    spawnlevel(bosslevel15, sag);
                }

            }
            if (sayac == 50)
            {
                durum1 = true;
            }
        }
    }
}
