using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Observable
{
    public enum BoxType { Coin, Flower, Mushroom, None}
    public BoxType Type;
    private void Start()
    {
        Register(GUIController.Instance);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Notify(); 
        transform.parent.GetComponentInChildren<Animator>().SetTrigger("Bounce");
    }
}
