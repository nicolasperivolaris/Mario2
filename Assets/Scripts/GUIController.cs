using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour, IObserver
{
    public static GUIController Instance { get; private set; }
    private int coins = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) Instance = this;
        else throw new System.Exception("Can't create more than one GUIController");
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void IObserver.Update(Observable observable)
    {
        if ((observable is Box) && ((Box)observable).Type == Box.BoxType.Coin
            || observable is Character)
        {
            ++coins;
            GameObject.Find("Count").GetComponent<Text>().text = "Coins :" + coins;
        }
        else if (observable is EndFlag) ;
    }

}
