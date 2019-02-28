using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour {

    private int people = 1000;
    public Functions f;
    public Button hireB;
    public Button sellStockB;
    public Button buyWaterB;
    public Slider waterSlider;
    public Text hirePeopleT;
    private System.Random rnd = new System.Random();
    private int goldForWater = 20;
    private int goldForGood = 30;

    // Use this for initialization
    void Start () {
        hirePeopleT.text = "" + people;
        waterSlider.value = (float)f.waterStock;
        waterSlider.maxValue = 50000f;

    }

    void sell() {
        f.gold += goldForGood * f.stock;
        f.stock = 0;
    }

    void buy() {
        while(f.gold > goldForWater) {
            f.gold -= goldForWater;
            f.waterStock++;
        }
        waterSlider.value = (float)f.waterStock;
    }

    void hire() {
        f.allPeople += people;
        people = 0;
        hirePeopleT.text = "" + people;
    }


    // Update is called once per frame
    void Update () {
        buyWaterB.onClick.AddListener(buy);
        sellStockB.onClick.AddListener(sell);
        hireB.onClick.AddListener(hire);
    }
}
