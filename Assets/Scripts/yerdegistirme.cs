using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yerdegistirme : MonoBehaviour
{
    //sað ve sola geçme butonlarý
    public GameObject sol;
    public GameObject sag;

    public GameObject solorta;
    public GameObject sagorta;

    public GameObject solust;
    public GameObject sagust;

    
    public Button upgradetusu;
    public Button ikincisilahbutonu;
    public Image ev;

    //evin upgrade fotolarý ama level 1 gibi altta
    public Sprite level1sol;
    public Sprite level2sol;
    public Sprite level3sol;
    public Sprite level4sol;
    public Sprite level5sol;

    public Sprite level1sag;
    public Sprite level2sag;
    public Sprite level3sag;
    public Sprite level4sag;
    public Sprite level5sag;

    //diðer upgrade fotolarý
    public Sprite level2solorta;

    public Sprite level3solorta;
    public Sprite level3sagorta;

    public Sprite level4solorta;
    public Sprite level4sagorta;
    public Sprite level4solust;

    public Sprite level5solorta;
    public Sprite level5sagorta;
    public Sprite level5solust;
    public Sprite level5sagust;
    //bunlarýn ikinci seviyeleri
    public Sprite level1sol2;
    public Sprite level2sol2;
    public Sprite level3sol2;
    public Sprite level4sol2;
    public Sprite level5sol2;

    public Sprite level1sag2;
    public Sprite level2sag2;
    public Sprite level3sag2;
    public Sprite level4sag2;
    public Sprite level5sag2;
    //diðerleri
    public Sprite level2solorta2;

    public Sprite level3solorta2;
    public Sprite level3sagorta2;

    public Sprite level4solorta2;
    public Sprite level4sagorta2;
    public Sprite level4solust2;

    public Sprite level5solorta2;
    public Sprite level5sagorta2;
    public Sprite level5solust2;
    public Sprite level5sagust2;

    int level = 1;
    

    //nereye geçtiðini anlamak için logicler
    public bool solda = true;
    public bool sagda = false;
    public bool solortada = false;
    public bool sagortada = false;
    public bool solustte = false;
    public bool sagustte = false;

    //ikinci seviye silaha geçti mi
    public bool ikincisilah = false;

    //upgrade marketindeki geliþtirme seviyelerinin backgroundlarýný aktifleþtiriyorum burda ev
    public GameObject ilkseviye; 
    public GameObject ikinciseviye;
    public GameObject ucuncuseviye;
    public GameObject dorduncuseviye;

    //upgrade marketindeki silahýn upgrade aktifleþtirmesi
    public GameObject mermiupgradeaktif; // double mermideki güçlendirmeye basýnca yeþil yanma zýmbýrtýsý
    public GameObject fuzelevelkontrol; //füze fýrlatma butonu aslýnda
    public Text buildupgradetextupdate;
     void Start()
    {
        level = DataManager.Instance.buildinglevel;
        level++;
        ikincisilah = DataManager.Instance.doublegun;
        if (ikincisilah)
        {
            mermiupgradeaktif.SetActive(false);
        }
        sagatýkla();
    }
   /* void fuzeicinlevelkontrol()
    {
        if (level >= 2 && DataManager.Instance.rocketquantity >=1)
        {
            fuzelevelkontrol.SetActive(true) ;
        }
    }*/
    public void sagatýkla() {
        
        
        if (level==1)
        {
             solda = false;
             sagda = true;
             solortada = false;
             sagortada = false;
             solustte = false;
             sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level1sag2;
            }
            else
            {
                ev.sprite = level1sag;
            }

            
            sol.SetActive(true);
            sag.SetActive(false);
        }
        else if (level == 2) {
            solda = false;
            sagda = true;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level2sag2;
            }
            else
            {
                ev.sprite = level2sag;
            }
            
            
            sol.SetActive(true);
            sag.SetActive(false);
            solorta.SetActive(true);
        }
        else if (level == 3)
        {
            solda = false;
            sagda = true;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level3sag2;
            }
            else
            {
                ev.sprite = level3sag;
            }
            
           
            sol.SetActive(true);
            sag.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
        }
        else if (level == 4)
        {
            solda = false;
            sagda = true;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level4sag2;
            }
            else
            {
                ev.sprite = level4sag;
            }
            
            
            sol.SetActive(true);
            sag.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            solust.SetActive(true);
        }
        else if (level == 5)
        {
            solda = false;
            sagda = true;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level5sag2;
            }
            else
            {
                ev.sprite = level5sag;
            }
            
            
            sol.SetActive(true);
            sag.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sagust.SetActive(true);
            solust.SetActive(true);
        }
        


    }
     public void solatýkla()
    {
        
        
        if (level == 1)
        {
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level1sol2;
            }
            else
            {
                ev.sprite = level1sol;
            }
            
           
            
            sag.SetActive(true);
            sol.SetActive(false);
        }
        else if (level == 2)
        {
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level2sol2;
            }
            else
            {
                ev.sprite = level2sol;
            }
            
            
            sag.SetActive(true);
            sol.SetActive(false);
            solorta.SetActive(true);
        }
        else if (level == 3)
        {
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level3sol2;
            }
            else
            {
                ev.sprite = level3sol;
            }
            
           
            sag.SetActive(true);
            sol.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
        }
        else if (level == 4)
        {
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level4sol2;
            }
            else
            {
                ev.sprite = level4sol;
            }
            
           
            
            sag.SetActive(true);
            sol.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            solust.SetActive(true);
        }
        else if (level == 5)
        {
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level5sol2;
            }
            else
            {
                ev.sprite = level5sol;
            }
            
            
            sag.SetActive(true);
            sol.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sagust.SetActive(true);
            solust.SetActive(true);
        }

    }
    public void silahiupgradele() {
        if (DataManager.Instance.mymoney >=1000000)
        {
            ikincisilah = true;
            ikincisilahbutonu.interactable = false;
            mermiupgradeaktif.SetActive(false);
            DataManager.Instance.doublegun = true;
            DataManager.Instance.mymoney -= 1000000;
            DataManager.Instance.SaveData();
            if (level == 2)
            {

                solorta.SetActive(true);
                sag.SetActive(true);
                sol.SetActive(false);
                solda = true;
                sagda = false;
                solortada = false;
                sagortada = false;
                solustte = false;
                sagustte = false;
                if (ikincisilah)
                {
                    ev.sprite = level2sol2;
                }
                else
                {
                    ev.sprite = level2sol;
                }



            }

            else if (level == 3)
            {
                sol.SetActive(false);
                sagorta.SetActive(true);
                solorta.SetActive(true);
                sag.SetActive(true);
                solda = true;
                sagda = false;
                solortada = false;
                sagortada = false;
                solustte = false;
                sagustte = false;
                if (ikincisilah)
                {
                    ev.sprite = level3sol2;
                }
                else
                {
                    ev.sprite = level3sol;
                }


            }
            else if (level == 4)
            {
                sol.SetActive(false);
                solust.SetActive(true);
                sagorta.SetActive(true);
                solorta.SetActive(true);
                sag.SetActive(true);
                solda = true;
                sagda = false;
                solortada = false;
                sagortada = false;
                solustte = false;
                sagustte = false;
                if (ikincisilah)
                {
                    ev.sprite = level4sol2;
                }
                else
                {
                    ev.sprite = level4sol;
                }



            }
            else if (level == 5)
            {
                sol.SetActive(false);
                sagust.SetActive(true);
                solust.SetActive(true);
                sagorta.SetActive(true);
                solorta.SetActive(true);
                sag.SetActive(true);
                solda = true;
                sagda = false;
                solortada = false;
                sagortada = false;
                solustte = false;
                sagustte = false;
                if (ikincisilah)
                {
                    ev.sprite = level5sol2;
                }
                else
                {
                    ev.sprite = level5sol;
                }



            }
        }
        
        
        
    }
    public void upgradele()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.mymoney>= 3000 && DataManager.Instance.buildinglevel ==0)
        {
            level++;
            DataManager.Instance.buildinglevel++;
            DataManager.Instance.mymoney -= 3000;
            buildupgradetextupdate.GetComponent<Text>().text = "3000";
            upgradelecut();

        }
        else if (DataManager.Instance.mymoney >= 3000 && DataManager.Instance.buildinglevel == 1)
        {
            level++;
            DataManager.Instance.buildinglevel++;
            DataManager.Instance.mymoney -= 3000;
            buildupgradetextupdate.GetComponent<Text>().text = "12500";
            upgradelecut();
        }
        else if (DataManager.Instance.mymoney >= 12500 && DataManager.Instance.buildinglevel == 2)
        {
            level++;
            DataManager.Instance.buildinglevel++;
            DataManager.Instance.mymoney -= 12500;
            buildupgradetextupdate.GetComponent<Text>().text = "12500";
            upgradelecut();

        }
        else if (DataManager.Instance.mymoney >= 12500 && DataManager.Instance.buildinglevel == 3)
        {
            level++;
            DataManager.Instance.buildinglevel++;
            DataManager.Instance.mymoney -= 12500;
            buildupgradetextupdate.GetComponent<Text>().text = "MAX";
            upgradelecut();
        }

        DataManager.Instance.SaveData();



    }
    void upgradelecut()
    {
        if (level == 2)
        {

            solorta.SetActive(true);
            sag.SetActive(true);
            sol.SetActive(false);
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            ilkseviye.SetActive(false);
            if (ikincisilah)
            {
                ev.sprite = level2sol2;
            }
            else
            {
                ev.sprite = level2sol;
            }


        }
        else if (level == 3)
        {
            sol.SetActive(false);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sag.SetActive(true);
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level3sol2;
            }
            else
            {
                ev.sprite = level3sol;
            }
            ikinciseviye.SetActive(false);

        }
        else if (level == 4)
        {
            sol.SetActive(false);
            solust.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sag.SetActive(true);
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level4sol2;
            }
            else
            {
                ev.sprite = level4sol;
            }
            ucuncuseviye.SetActive(false);

        }
        else if (level == 5)
        {
            sol.SetActive(false);
            sagust.SetActive(true);
            solust.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sag.SetActive(true);
            solda = true;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level5sol2;
            }
            else
            {
                ev.sprite = level5sol;
            }
            upgradetusu.interactable = false;
            dorduncuseviye.SetActive(false);
        }
    }


    public void solortatýkla() {
        
         if (level == 2)
        {
            solda = false;
            sagda = false;
            solortada = true;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level2solorta2;
            }
            else
            {
                ev.sprite = level2solorta;
            }
            
            sag.SetActive(true);
            sol.SetActive(true);
            solorta.SetActive(false);
        }
        else if (level == 3)
        {
            solda = false;
            sagda = false;
            solortada = true;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level3solorta2;
            }
            else
            {
                ev.sprite = level3solorta;
            }
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(false);
        }
        else if (level == 4)
        {
            solda = false;
            sagda = false;
            solortada = true;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level4solorta2;
            }
            else
            {
                ev.sprite = level4solorta;
            }
            
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(false);
            solust.SetActive(true);
        }
        else if (level == 5)
        {
            solda = false;
            sagda = false;
            solortada = true;
            sagortada = false;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level5solorta2;
            }
            else
            {
                ev.sprite = level5solorta;
            }
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(false);
            sagust.SetActive(true);
            solust.SetActive(true);
        }

    }
    public void sagortatýkla()
    {
        
         if (level == 3)
        {
            solda = false;
            sagda = false;
            solortada = false;
            sagortada = true;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level3sagorta2;
            }
            else
            {
                ev.sprite = level3sagorta;
            }
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(false);
            solorta.SetActive(true);
        }
        else if (level == 4)
        {
            solda = false;
            sagda = false;
            solortada = false;
            sagortada = true;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level4sagorta2;
            }
            else
            {
                ev.sprite = level4sagorta;
            }
            
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(false);
            solorta.SetActive(true);
            solust.SetActive(true);
        }
        else if (level == 5)
        {
            solda = false;
            sagda = false;
            solortada = false;
            sagortada = true;
            solustte = false;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level5sagorta2;
            }
            else
            {
                ev.sprite = level5sagorta;
            }
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(false);
            solorta.SetActive(true);
            sagust.SetActive(true);
            solust.SetActive(true);
        }

    }
    public void solusttýkla()
    {
         if (level == 4)
        {
            solda = false;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = true;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level4solust2;
            }
            else
            {
                ev.sprite = level4solust;
            }
            
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            solust.SetActive(false);
        }
        else if (level == 5)
        {
            solda = false;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = true;
            sagustte = false;
            if (ikincisilah)
            {
                ev.sprite = level5solust2;
            }
            else
            {
                ev.sprite = level5solust;
            }
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sagust.SetActive(true);
            solust.SetActive(false);
        }
    }
    public void sagusttýkla()
    {
         if (level == 5)
        {
            solda = false;
            sagda = false;
            solortada = false;
            sagortada = false;
            solustte = false;
            sagustte = true;
            if (ikincisilah)
            {
                ev.sprite = level5sagust2;
            }
            else
            {
                ev.sprite = level5sagust;
            }
            
            sag.SetActive(true);
            sol.SetActive(true);
            sagorta.SetActive(true);
            solorta.SetActive(true);
            sagust.SetActive(false);
            solust.SetActive(true);
        }
    }
    
    
}
