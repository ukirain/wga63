using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class RandomEvents : MonoBehaviour {


    float seconds = 2.0f;
    private IEnumerator coroutine;
    public Pause pausedControl;
    public GameObject messageCanvas;
    public Text messageText;
    public Text descriptionText;
    public GameObject town;
    public Functions f;
    public Player p;
    public EventControl ev = null;
    EventTree eTree;
    bool firstDead = true;
    // Use this for initialization
    void Start () {
        eTree = new EventTree(null, "Story just begining");
        ev = new EventControl(eTree, messageCanvas, pausedControl, messageText, descriptionText, f, p);
        for (int i = 0; i < 5; i++) {
            coroutine = Gen(seconds, i);
            StartCoroutine(coroutine);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (f.waterStock < 0) {
            GG();
            firstDead = false;
        }

        if (f.tempDel > f.tempMax) {
            firstDead = false;
            GG();
        }

        if (f.pDel > f.pMax) {
            firstDead = false;
            GG();
        }

    }

    private void GG() {
        if (firstDead) {
            ev.StartEvent(0);
        } else {
            p.gg();
            Debug.Log("Game Over");
            ev.StartEvent(13);
            System.Threading.Thread.Sleep(1000);
            Application.Quit();
        }
    }

    private IEnumerator Gen(float waitTime, int i) { //запуск генератора событий
        while (true) {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Boop! " + Time.time); //объявляем о начале
            ev.StartGenerate(i);
        }
    }

}

public class EventControl : MonoBehaviour {

    private const string PATH = "conditions.txt";
    private const int POSITION_BOOL = 0;
    private const int POSITION_PROPERTY = 1;
    private const int POSITION_NAME = 2;
    private const int POSITION_DESC = 3;
    private List<Eve> arrayEve;
    private List<String> strList;
    private FileStream fs;
    private System.Random rnd = new System.Random();
    private EventTree eRoot;
    private GameObject messageCanvas;
    private Text messageText;
    private Text descriptionText;
    private Pause pausedControl;
    public Functions f;
    public Player p;

    public EventControl(EventTree pETree, GameObject pMessageCanvas, Pause pPausedControl, Text pMessageText, Text pDescriptionText, Functions pF, Player pP) {
        arrayEve = new List<Eve>();
        eRoot = pETree;
        messageCanvas = pMessageCanvas;
        pausedControl = pPausedControl;
        messageText = pMessageText;
        descriptionText = pDescriptionText;
        f = pF;
        p = pP;
        FileOpen(PATH, arrayEve);
        Debug.Log("Test randomize");
        /*for (int j = 0; j < 10; j++) {
            Debug.Log("Iteration:" + j);
            double r = rnd.NextDouble();
            for (int i = 0; i < arrayEve.Count; i++) {
                Eve tempEv = arrayEve[i];
                if (tempEv.getCondition().getCond()) {
                    if (tempEv.getCondition().getProperty() > r) {
                        Debug.Log("Random:" + r + " Name: " + tempEv.getSheath().getName() + " Property: " + tempEv.getCondition().getProperty());
                    }
                }
            }
        }*/
    }

    private void FileOpen(string pPath, List<Eve> pArrayEve) {
        string[] arrStr = System.IO.File.ReadAllLines(@PATH);
        string[] strArray;
        Eve tempEvent;
        Condition tempCond;
        Action tempAct;
        Sheath tempSth;
        Boolean tempBool;
        String line;
        Debug.Log("Contents of WriteLines2.txt = ");
        for(int i = 0; i < arrStr.Length; i+=2) {
            line = arrStr[i];
            // Use a tab to indent each line of the file.
            Debug.Log("\t" + line);
            strArray = line.Split(' ');
            if(strArray[0] == "true") {
                tempBool = true;
            } else {
                tempBool = false;
            }

            tempCond = new Condition(tempBool, float.Parse(strArray[POSITION_PROPERTY]));
            tempSth = new Sheath(strArray[POSITION_NAME], arrStr[i + 1]);
            tempEvent = new Eve(tempCond, null, tempSth);
            arrayEve.Add(tempEvent);
        }
    }

    public void StartGenerate(int i) {
        double r = rnd.NextDouble();
                Eve tempEv = arrayEve[i];
                if (tempEv.getCondition().getCond()) {
                    if (tempEv.getCondition().getProperty() > r) {
                        Debug.Log("Random:" + r + " Name: " + tempEv.getSheath().getName() + " Property: " + tempEv.getCondition().getProperty());
                        //GameObject newMC = (GameObject)GameObject.Instantiate(messageCanvas);
                        messageCanvas.SetActive(true);
                        messageCanvas.transform.Find("MessageEvent").GetComponent<Text>().text = tempEv.getSheath().getName();
                        messageCanvas.transform.Find("DescriptionEvent").GetComponent<Text>().text = tempEv.getSheath().getDescriprion();
                        pausedControl.paused = true;
                        p.evente();
                        Debug.Log("WEOWEOWEOWEOWEOWEOWEOWOEOWE");
                        run(i);
                        EventTree et = new EventTree(eRoot, tempEv.getSheath().getName());
                        eRoot.addChild(et);
                    }
                }
    }

    public void StartEvent(int i) {
        Eve tempEv = arrayEve[i];
        messageCanvas.SetActive(true);
        messageCanvas.transform.Find("MessageEvent").GetComponent<Text>().text = tempEv.getSheath().getName();
        messageCanvas.transform.Find("DescriptionEvent").GetComponent<Text>().text = tempEv.getSheath().getDescriprion();
        pausedControl.paused = true;
        p.evente();
        Debug.Log("WEOWEOWEOWEOWEOWEOWEOWOEOWE");
        run(i);
        EventTree et = new EventTree(eRoot, tempEv.getSheath().getName());
        eRoot.addChild(et);
    }


    IEnumerator Wait() {
        print(Time.time);
        yield return new WaitForSeconds(0.2f);
        print(Time.time);
    }

    public void run(int i) {
        switch (i) {
            case 0:
                f.waterStock += 5000;
                break;
            case 1:
                f.gold += 100;
                break;
            case 2:
                f.gold += 100;
                f.allPeople--;
                break;
            case 3:
                f.addedT += 100;
                break;
            case 4:
                f.addedT -= 100;
                break;
            case 5:
                f.addedT += 100;
                break;
            case 6:
                f.addedP += 1000;
                break;
            case 7:
                if (f.allPeople > 10)
                    f.allPeople -= 10;
                else
                    f.allPeople = 0;
                break;
            case 8:
                f.gold += 300;
                break;
            case 9:
                if (f.allPeople > 10)
                    f.allPeople -= 10;
                else
                    f.allPeople = 0;
                break;
            case 10:
                if (f.allPeople > 10)
                    f.allPeople -= 10;
                else
                    f.allPeople = 0;
                break;
            case 11:
                f.addedP += 1000;
                break;
            case 12:
                System.Threading.Thread.Sleep(1000);
                break;
            case 13:
                System.Threading.Thread.Sleep(1000);
                break;
            default:
                break;
        }
    }
}

public class Eve : MonoBehaviour {

    private Condition cond;
    private Action act;
    private Sheath sth;

    public Eve(Condition pCond, Action pAct, Sheath pSth) {
        cond = pCond;
        act = pAct;
        sth = pSth;
    }

    public Condition getCondition() {
        return cond;
    }

    public Action getAction() {
        return act;
    }

    public Sheath getSheath() {
        return sth;
    }
}

public class Condition : MonoBehaviour {

    private bool cond;
    private float property;

    public Condition(bool pCond, float pProperty) {
        cond = pCond;
        property = pProperty;
    }

    public bool getCond() {
        return cond;
    }

    public float getProperty() {
        return property;
    }
    
}

public class Action : MonoBehaviour {
  /*здесь будет привязка к действиям, может сделать шаблоны действий*/
    
}

public class Sheath : MonoBehaviour {

    private string name;
    private string description;

    public Sheath(string pName, string pDescription) {
        name = pName;
        description = pDescription;
    }

    public string getName() {
        return name;
    }

    public string getDescriprion() {
        return description;
    }
  /*здесь будут картинка, текст и прочие косметические вещи*/
}

public class EventTree{

    List<EventTree> childs = new List<EventTree>();
    EventTree parent;
    String nameEvent;

    public EventTree(EventTree pParent, String pNameEvent) {
        parent = pParent;
        nameEvent = pNameEvent;
    }

    public void addChild(EventTree child) {
        childs.Add(child);
    }

    public EventTree getParent() {
        if(parent != null) {
            return parent;
        } else {
            Debug.Log("It's rool");
            return null;
        }
    }
}

