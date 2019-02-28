using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functions : MonoBehaviour {

    public double a; //ускорение
    public double workP; //работающие люди
    public double delWaterCol; //расход воды на охлаждение в секунду

    public double stock; //товар
    public double waterStock; //вода
    public double allPeople; //количество людей

    public double v; //скорость корабля
    public const double vMax = 20.0; //максимальная скорость
    public const double timeProd = 72.0; //время производства 1 единицы товара человеком в секунду
    public const double kProd = 4.0; //коэффициент производства
    public double totalTimeProd; //время производства одного товара
    public double delWaterA; //потребление воды на ускорение в секунду
    public const double delWaterProd = 2; //расход воды на 1 товар
    public double delStockProd;
    public const double manWater = 0.0125; //расход на 1 человека за секунду
    public double allPeopleWater; //расход на население в секунду
    public double tempMax = 500; //максимальная температура
    public double tempDel; //динамика температуры
    public double tempDelSec; //Изменение температуры в секунду
    public const double kTemp = 0.5; //температурный коэффициент
    public const double kTempS = 25; //температурный коэффициент сопротивления
    public double tempA; //прирост температуры от ускорения
    public double tempV; //прирост температуры от скорости 
    public double tempProd; //прирост температуры от производства
    public const double kTempProd = 5000; //производственный температурный коэффициент
    public const double kTempV = 0.5; //скоростной температурный коэффициент
    public double kTempA; //коэффициент температуры от ускорения
    public double pMax = 60000; //максимальное давление
    public double pDel; //динамика давления
    public const double kP = 1; //коэффициент давления
    public const double kPS = 20; //коэффициент сопротивления
    public double pA; //прирост давления от ускорения
    public double pT; //прирост давления от температуры
    public double pProd; //прирост давления от производства
    public const double kPProd = 3000; //коэффициент давления производства
    public double kPA; //коэффициент давления ускорения
    public double kPT = 100; //коэффициент давления от температуры
    public const double valueWater = 2; //цена воды
    public const double valueStock = 3; //цена товара
    public double totalWaterFlow; //суммарный расход воды
    public const double secInDay = 240; //секунд в дне
    public double newStock = 0;
    public double gold = 0;
    public double waterMax = 10000;
    public double addedP = 0;
    public double addedT = 0;

    float seconds = 1.0f;
    private IEnumerator coroutine;

    public Slider sliderSpeed;
    public Slider sliderPressure;
    public Slider sliderTemperature;
    public Slider sliderAcceleration;
    public Slider sliderCreating;
    public Button waterCounterPlus;
    public Button waterCounterMinus;
    public Text waterCounterText;

    public Slider sliderGoods;
    public Text countGoodsText;
    public Text countWorkerText;
    public Slider sliderWater;
    public Text goldCounterText;
    public Text goldCounterTextTrade;
    public Text peopleCounterText;
    public Text allPeopleCounterText;
    public Button workPeoplePlus;
    public Button workPeopleMinus;
    int k;
    public Player player;
    private bool sirenP = true;
    private bool sirenTemp = true;
    private bool sirenWater = true;

    // Use this for initialization
    void Start () {
        a = 0;
        v = 0;
        workP = 5;
        delWaterCol = 5;
        stock = 0;
        waterStock = 5000;
        allPeople = 20;
        coroutine = WaitAndPrint(seconds);
        StartCoroutine(coroutine);

        sliderCreating.maxValue = (float)timeProd;
        waterCounterText.text = delWaterCol.ToString();

        waterCounterMinus.onClick.AddListener(minusWater);
        waterCounterPlus.onClick.AddListener(plusWater);
        workPeopleMinus.onClick.AddListener(minusWorkers);
        workPeoplePlus.onClick.AddListener(plusWorkers);
    }
	
    void plusWater() {
        Debug.Log("PLUSPLUS");
        if (delWaterCol < waterStock) {
            delWaterCol++;
            waterCounterText.text = ((float)delWaterCol).ToString();
        }
    }

    void minusWater() {
        if (delWaterCol > 0) {
            delWaterCol--;
            waterCounterText.text = ((float)delWaterCol).ToString();
        }
    }

    void plusWorkers() {
        if (workP < allPeople) {
            workP++;
            countWorkerText.text = workP.ToString();
        }
    }

    void minusWorkers() {
        if (workP > 0) {
            workP--;
            countWorkerText.text = workP.ToString();
        }
    }



    // Update is called once per frame
    void Update () {
        sliderSpeed.value = (float)v;
        sliderPressure.value = (float)pDel;
        sliderTemperature.value = (float)tempDel;
        a = sliderAcceleration.value;
        sliderGoods.value = (float)stock;
        sliderWater.value = (float)waterStock;
        countGoodsText.text = "Товар: " + stock;
        goldCounterText.text = "" + gold;
        goldCounterTextTrade.text = "" + gold;
        countWorkerText.text = "" + workP;
        allPeopleCounterText.text = "Незанятые " + (allPeople - workP);
        newStock = Mathf.MoveTowards((float)newStock, (float)timeProd, Time.deltaTime * ( (float)kProd * (float)workP));
        sliderCreating.value = (float)newStock;

        if (System.Math.Abs(pDel) > pMax * 0.8f) {
            if (sirenP) {
                player.sirena();
            }
            sirenP = false;
        } else {
            sirenP = true;
        }

        if (System.Math.Abs(tempDel) > tempMax * 0.8f) {
            if (sirenTemp) {
                player.sirena();
            }
            sirenTemp = false;
        } else {
            sirenTemp = true;
        }

        if (System.Math.Abs(waterStock) < 0.2f * waterMax) {
            if (sirenWater) {
                player.sirena();
            }
            sirenWater = false;
        } else {
            sirenWater = true;
        }

    }

    private IEnumerator WaitAndPrint(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Action! " + Time.time);
            if(v >= 0 && v <= vMax) {
                v += a;
            }
            if (v <= 0)
                v = 0;

            if (v >= vMax) {
                v = vMax;
            }

            if (a >= 0) {
                kTempA = 1;
            }
            if (a >= 3) {
                kTempA = 2;
            }
            if (a >= 5) {
                kTempA = 5;
            }

            totalTimeProd = timeProd / (kProd * workP);
            delWaterA = a;
            delStockProd = delWaterProd / totalTimeProd;
            allPeopleWater = allPeople * manWater;
            tempDel = -kTempS * delWaterCol * kTemp + tempA + tempV + tempProd + addedT;
            tempA = a * kTempA * kTemp;
            tempV = v * kTempV * kTemp;
            tempProd = ((kProd * workP) / secInDay) * kTempProd * kTemp;


            tempDelSec = -kTempS * delWaterCol * kTemp + tempA + tempV + tempProd;
            if (tempDel >= 0 && tempDelSec >= 0) {
                tempDel = tempDel + tempDelSec;
            }
            else {
                tempDel = 0;
            }
            pDel = -kPS + pA + pT + pProd + addedP;
            pA = kP * kPA * a;
            pT = tempDel * kPT * kP;
            pProd = (totalTimeProd / secInDay) * kPProd * kP;

            if (a >= 0) {
                kPA = 1;
            }
            if (a >= 3) {
                kPA = 2;
            }
            if (a >= 5) {
                kPA = 5;
            }

            if(pDel < 0) {
                pDel = 0;
            }

            totalWaterFlow = delWaterA + delWaterCol + delWaterProd + allPeopleWater;

            //newStock += kProd * workP;
            if (newStock >= timeProd - 0.001 && stock < sliderGoods.maxValue) {
                stock++;
                newStock = 0;
            }
            waterStock -= totalWaterFlow;
        }
    }
}
