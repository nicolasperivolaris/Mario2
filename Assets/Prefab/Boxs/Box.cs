using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Observable
{
    public enum BoxType { Coin, Flower, Mushroom, None}
    public BoxType Type;
    public bool IsOpen { get; private set; }
    private void Start()
    {
        Register(GUIController.Instance);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsOpen) return;
        Notify(); 
        transform.parent.GetComponentInChildren<Animator>().SetTrigger("Bounce");
        IsOpen = true;
    }
}
