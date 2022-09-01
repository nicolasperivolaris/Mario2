using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIController : MonoBehaviour, IObserver
{
    public static GUIController Instance { get; private set; }
    private int coins = 0;
    GameObject ScorePanel;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) Instance = this;
        else throw new System.Exception("Can't create more than one GUIController");
    }

    void Start()
    {
        ScorePanel = GameObject.Find("ScorePanel");
        ScorePanel.SetActive(false);
    }

    private void Reset()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
    private void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (ScorePanel.activeSelf && Input.GetButtonDown("Jump"))
            Reset();

    }

    void IObserver.Update(Observable observable)
    {
         if ((observable is Box) && ((Box)observable).Type == Box.BoxType.Coin
            || observable is GoombaHeadCollider)
        {
            ++coins;
            GameObject.Find("Count").GetComponent<Text>().text = "Coins :" + coins;
        }
        else if (observable is EndFlag)
        {
            ScorePanel.SetActive(true);
            GameObject.Find("Result").GetComponent<Text>().text = "You win !";

        }
        else if (observable is Goomba)
        {
            ScorePanel.SetActive(true);
            GameObject.Find("Result").GetComponent<Text>().text = "Game Over !";
        }
    }

}
