using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public GameObject ScoreBoardScreen;

    public Text MyMoney;
    public Text AllMyMoney; //toplanmýþ para
    public Text BombQuantity;
    public Text UsedBomb;
    public Text BombPower;
    public Text RocketQuantity;
    public Text UsedRocket;
    public Text RocketPower;
    public Text LaserQuantity;
    public Text UsedLaser;
    public Text LaserPower;
    public Text WhichLevel;
    public Text HomeHeal;
    public Text MaxHomeHeal;
    public Text AllHomeHeal; //basýlmýþ tüm can
    public Text BulletSpeed;
    public Text BulletPower;
    public Text AllShotBullet;
    public Text DeadCounter;
    public Text NumberOfLevelsPlayed;
    public Text KilledZombie;

    public void OpenScoreboard()
    {
        ScoreBoardScreen.SetActive(true);
        DataManager.Instance.LoadData();
        MyMoney.GetComponent<Text>().text = "Money: " + DataManager.Instance.mymoney;
        AllMyMoney.GetComponent<Text>().text = "Collected Money: " + DataManager.Instance.allmoney;
        BombQuantity.GetComponent<Text>().text = "Bomb Quantity: " + DataManager.Instance.bombquantity;
        UsedBomb.GetComponent<Text>().text = "Used Bomb: " + DataManager.Instance.usedbomb;
        BombPower.GetComponent<Text>().text = "Bomb Power: " + DataManager.Instance.bombpower;
        RocketQuantity.GetComponent<Text>().text = "Rocket Quantity: " + DataManager.Instance.rocketquantity;
        UsedRocket.GetComponent<Text>().text = "Used Rocket: " + DataManager.Instance.usedrocket;
        RocketPower.GetComponent<Text>().text = "Rocket Power: " + DataManager.Instance.rocketpower;
        UsedLaser.GetComponent<Text>().text = "Used Laser: " + DataManager.Instance.usedlaser;
        LaserQuantity.GetComponent<Text>().text = "Total Damage Given: " + DataManager.Instance.setdamage;
        LaserPower.GetComponent<Text>().text = "Total Damage Taken: " + DataManager.Instance.getdamage;
        WhichLevel.GetComponent<Text>().text = "Current Level: " + (DataManager.Instance.whichlevel + 1);
        HomeHeal.GetComponent<Text>().text = "Current Home Health: " + DataManager.Instance.homeheal;
        MaxHomeHeal.GetComponent<Text>().text = "Max Home Health: " + DataManager.Instance.maxhomeheal;
        AllHomeHeal.GetComponent<Text>().text = "Used Home Health: " + DataManager.Instance.usedhomeheal;
        BulletSpeed.GetComponent<Text>().text = "Bullet Speed: " + DataManager.Instance.bulletspeed;
        BulletPower.GetComponent<Text>().text = "Bullet Power: " + DataManager.Instance.bulletpower;
        AllShotBullet.GetComponent<Text>().text = "Shot Bullet: " + DataManager.Instance.shotbullet;
        DeadCounter.GetComponent<Text>().text = "Dead Counter: " + DataManager.Instance.deadcounter;
        NumberOfLevelsPlayed.GetComponent<Text>().text = "Number Of Levels Played: " + DataManager.Instance.playedlevel;
        KilledZombie.GetComponent<Text>().text = "Total killed Monster: " + DataManager.Instance.killmonster;
        
    }

    public void CloseScoreboard()
    {
        ScoreBoardScreen.SetActive(false);
    }

}
