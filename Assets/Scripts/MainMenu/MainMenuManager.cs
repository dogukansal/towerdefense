using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject levelscreen;
    public GameObject uielements;
    public Text money;
    public Button[] levelbuton;
    public GameObject[] levelprice;
    public Sprite locked;
    public Sprite[] levelpicture;
    public GameObject confirmscreen;
    public Text confirmscreenintext;
    public GameObject confirmbutton; //confirmscreendeki confirm butonu eðer para yoksa gizlensin ve paran yok desin
    //level 7 bina yükseltme infosu
    public GameObject specialinfoscreen;
    public Text specialinfotext;
    //bomba füze duvar vb spritelarý. leveli açýnca göstersin
    public Sprite wall;
    public Sprite bomb;
    public Sprite laser;
    public Sprite rocket;
    public Sprite doublegunpic;
    public Image newitemimage;
    public GameObject newitemimagegameobject;

    public GameObject loadingscrenn;
    public Slider loadingslider;
    public Text loadingtext;
    public GameObject backgroundlevel;

    //music
    public Sprite musicon;
    public Sprite musicoff;
    public GameObject musicbutton;
    public AudioSource mainmenumusic;

    public GameObject creditsscreen;
    public GameObject howtoplayscreen;

    void Start()
    {
        if (DataManager.Instance.muzik)
        {
            musicbutton.GetComponent<Image>().sprite = musicon;
            mainmenumusic.Play();
        }
        else
        {
            musicbutton.GetComponent<Image>().sprite = musicoff;
            mainmenumusic.Stop();
        }
    }
    public void openlevelscreen()
    {
        levelscreen.SetActive(true);
        uielements.SetActive(false);
        DataManager.Instance.LoadData();
        money.GetComponent<Text>().text = DataManager.Instance.mymoney.ToString();
        //levellar
        levelcontrol();
        
    }


    
    public void closelevelscreen()
    {
        levelscreen.SetActive(false);
        uielements.SetActive(true);
    }
    void levelcontrol()
    {
        if (DataManager.Instance.whichlevel==0)
        {
            levelcontrolcut(1, levelbuton);
            levelprice[0].SetActive(true); //2.levelin parasý açýk
            

        }
        else if (DataManager.Instance.whichlevel == 1)
        {
            levelcontrolcut(2, levelbuton);
            levelpicturecut(1);
            levelbuton[2].image.sprite = levelpicture[0];
            levelprice[0].SetActive(false); //2.levelin parasý kapalý
            levelprice[1].SetActive(true); //3.levelin parasý açýk


        }
        else if (DataManager.Instance.whichlevel == 2)
        {
            levelcontrolcut(3, levelbuton);
            levelpicturecut(2);
            levelbuton[2].image.sprite = levelpicture[0];
            levelbuton[3].image.sprite = levelpicture[1];
            levelpricecut(1, levelprice); //2 ve 3. levelin parasý kapalý
            levelprice[2].SetActive(true); //4.levelin parasý açýk

        }
        else if (DataManager.Instance.whichlevel == 3)
        {
            levelcontrolcut(4, levelbuton);
            levelpicturecut(3);
            levelpricecut(2,levelprice); //2 3  ve 4 levelin parasý kapalý
            levelprice[3].SetActive(true);  //5 levelin parasý açýk
        }
        else if (DataManager.Instance.whichlevel == 4)
        {
            levelcontrolcut(5, levelbuton);
            levelpicturecut(4);
            levelpricecut(3, levelprice);
            levelprice[4].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 5)
        {
            levelcontrolcut(6, levelbuton);
            levelpicturecut(5);
            levelpricecut(4, levelprice);
            levelprice[5].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 6)
        {
            levelcontrolcut(7, levelbuton);
            levelpicturecut(6);
            levelpricecut(5, levelprice);
            levelprice[6].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 7)
        {
            levelcontrolcut(8, levelbuton);
            levelpicturecut(7);
            levelpricecut(6, levelprice);
            levelprice[7].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 8)
        {
            levelcontrolcut(9, levelbuton);
            levelpicturecut(8);
            levelpricecut(7, levelprice);
            levelprice[8].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 9)
        {
            levelcontrolcut(10, levelbuton);
            levelpicturecut(9);
            levelpricecut(8, levelprice);
            levelprice[9].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 10)
        {
            levelcontrolcut(11, levelbuton);
            levelpicturecut(10);
            levelpricecut(9, levelprice);
            levelprice[10].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 11)
        {
            levelcontrolcut(12, levelbuton);
            levelpicturecut(11);
            levelpricecut(10, levelprice);
            levelprice[11].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 12)
        {
            levelcontrolcut(13, levelbuton);
            levelpicturecut(12);
            levelpricecut(11, levelprice);
            levelprice[12].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 13)
        {
            levelcontrolcut(14, levelbuton);
            levelpicturecut(13);
            levelpricecut(12, levelprice);
            levelprice[13].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 14)
        {
            levelcontrolcut(15, levelbuton);
            levelpicturecut(14);
            levelpricecut(13, levelprice);
            levelprice[14].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 15)
        {
            levelcontrolcut(16, levelbuton);
            levelpicturecut(15);
            levelpricecut(14, levelprice);
            levelprice[15].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 16)
        {
            levelcontrolcut(17, levelbuton);
            levelpicturecut(16);
            levelpricecut(15, levelprice);
            levelprice[16].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 17)
        {
            levelcontrolcut(18, levelbuton);
            levelpicturecut(17);
            levelpricecut(16, levelprice);
            levelprice[17].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 18)
        {
            levelcontrolcut(19, levelbuton);
            levelpricecut(17, levelprice);
            levelpicturecut(17);
            levelprice[18].SetActive(true);
        }
        else if (DataManager.Instance.whichlevel == 19)
        {
            levelcontrolcut(19, levelbuton);
            levelpricecut(18, levelprice);
            levelpicturecut(17);
        }
        
    }
    void levelcontrolcut(int levelbutoncount, Button [] levelbutondizi )
    {
        for (int i = 0; i <= levelbutoncount; i++)
        {
            levelbutondizi[i].interactable = true;
        }
        for (int i = levelbutoncount; i < 19; i++)
        {
            levelbutondizi[i+1].interactable = false;
        }
    }
    void levelpricecut(int levelpricetextcount, GameObject [] levelpricetext)
    {
        for (int i = 0; i <= levelpricetextcount; i++)
        {
            levelpricetext[i].SetActive(false);
        }
        
    }

    void levelpicturecut(int whichlevelbuton)
    {
        for (int i = 0; i <= whichlevelbuton; i++)
        {
            levelbuton[i+2].image.sprite = levelpicture[i];

        }
    }

    public void confirmscreenconfirm()
    {

        if (DataManager.Instance.mymoney >=gecicigold)
        {
            DataManager.Instance.mymoney -= gecicigold;
            DataManager.Instance.whichlevel++;
            DataManager.Instance.SaveData();
            confirmscreen.SetActive(false);
            openlevelscreen();
            if (DataManager.Instance.whichlevel == 3)
            {
                specialinfoscreen.SetActive(true);
                levelscreen.SetActive(false);
                specialinfotext.GetComponent<Text>().text = "New Item Unlocked!";
                newitemimage.sprite = bomb;
                newitemimagegameobject.SetActive(true);
            }
            else if (DataManager.Instance.whichlevel == 6)
            {
                specialinfoscreen.SetActive(true);
                levelscreen.SetActive(false);
                specialinfotext.GetComponent<Text>().text = "New Item Unlocked!";
                newitemimage.sprite = rocket;
                newitemimagegameobject.SetActive(true);
            }
            else if (DataManager.Instance.whichlevel == 10)
            {
                specialinfoscreen.SetActive(true);
                levelscreen.SetActive(false);
                specialinfotext.GetComponent<Text>().text = "New Item Unlocked!";
                newitemimage.sprite = wall;
                newitemimagegameobject.SetActive(true);
            }
            else if (DataManager.Instance.whichlevel == 11)
            {
                specialinfoscreen.SetActive(true);
                levelscreen.SetActive(false);
                specialinfotext.GetComponent<Text>().text = "New Item Unlocked!";
                newitemimage.sprite = doublegunpic;
                newitemimagegameobject.SetActive(true);
            }
            else if (DataManager.Instance.whichlevel == 15)
            {
                specialinfoscreen.SetActive(true);
                levelscreen.SetActive(false);
                specialinfotext.GetComponent<Text>().text = "New Item Unlocked!";
                newitemimage.sprite = laser;
                newitemimagegameobject.SetActive(true);
            }
            
            
        }
        else
        {
            confirmbutton.SetActive(false);
            confirmscreenintext.GetComponent<Text>().text = "You don't have enough gold";
        }
    }
    
    public void confirmscreenexit()
    {
        confirmbutton.SetActive(true);
        confirmscreen.SetActive(false);
        levelscreen.SetActive(true);
    }
    int gecicigold;
    
    void whichgolevel(short level,int gold)
    {
        if (DataManager.Instance.whichlevel>=level)
        {
            DataManager.Instance.levelnow = level;
            Loadlevel();
        }
        else
        {
            confirmscreen.SetActive(true);
            levelscreen.SetActive(false);
            confirmscreenintext.GetComponent<Text>().text = "Level price is "+ gold + " gold. Do you confirm?";
            gecicigold = gold;
            
        }
       
    }
     void Loadlevel()
    {
        StartCoroutine(LoadAsynchronously());
    }
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation =SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            loadingscrenn.SetActive(true);
            backgroundlevel.SetActive(false);
            
            float loadingnumber = Mathf.Clamp01(operation.progress / 0.9f);
            loadingslider.value = loadingnumber;
            loadingtext.GetComponent<Text>().text = (loadingnumber * 100f + "%").ToString();
            yield return null;
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }

    }
    public void level1()
    {
        whichgolevel(0,0);
    }
    public void level2()
    {
        whichgolevel(1,250);
    }
    public void level3()
    {
        whichgolevel(2,500);
    }
    public void level4()
    {
        whichgolevel(3,750);
    }
    public void level5()
    {
        whichgolevel(4,1500);
    }
    public void level6()
    {
        whichgolevel(5,5000);
    }
    public void level7()
    {
        if (DataManager.Instance.buildinglevel >= 2)
        {
            whichgolevel(6, 7500);
        }
        else
        {
            specialinfoscreen.SetActive(true);
            levelscreen.SetActive(false);
            newitemimagegameobject.SetActive(false);
            specialinfotext.GetComponent<Text>().text = "You must do home upgrade (2 floor)";
        }
    }
    public void level7specialinfoclick()
    {
        specialinfoscreen.SetActive(false);
        levelscreen.SetActive(true);
        newitemimagegameobject.SetActive(true);
    }
    public void level8()
    {
        whichgolevel(7,20000);
    }
    public void level9()
    {
        whichgolevel(8,25000);
    }
    public void level10()
    {
        whichgolevel(9, 50000);
    }
    public void level11()
    {
        whichgolevel(10,75000);
    }
    public void level12()
    {
        if (DataManager.Instance.buildinglevel == 4)
        {
            whichgolevel(11, 90000);
        }
        else
        {
            specialinfoscreen.SetActive(true);
            newitemimagegameobject.SetActive(false);
            levelscreen.SetActive(false);
            specialinfotext.GetComponent<Text>().text = "You must do home upgrade (3 floor)";
        }
    }
    public void level13()
    {
        whichgolevel(12,100000);
    }
    public void level14()
    {
        whichgolevel(13, 125000);
    }
    public void level15()
    {
        whichgolevel(14,140000);
    }
    public void level16()
    {
        whichgolevel(15,175000);
    }
    public void level17()
    {
        whichgolevel(16,200000);
    }
    public void level18()
    {
        whichgolevel(17,300000);
    }
    public void level19()
    {
        whichgolevel(18,350000);
    }
    public void level20()
    {
        whichgolevel(19,400000);
    }

    public void musiconoff()
    {
        if (DataManager.Instance.muzik)
        {
            musicbutton.GetComponent<Image>().sprite = musicoff;
            DataManager.Instance.muzik = false;
            mainmenumusic.Stop();
           
        }
        else
        {
            musicbutton.GetComponent<Image>().sprite = musicon;
            DataManager.Instance.muzik = true;
            mainmenumusic.Play();
           
        }
        DataManager.Instance.SaveData();
    }
    public void opencredits()
    {
        creditsscreen.SetActive(true);
    }
    public void closecredits()
    {
        creditsscreen.SetActive(false);
    }
    public void htpopen()
    {
        howtoplayscreen.SetActive(true);
    }
    public void htpclose()
    {
        howtoplayscreen.SetActive(false);
    }
}
