using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathNotifier : Observable
{
    private List<IObserver> _observers = new List<IObserver>();

    private void Start()
    {
        Register(GUIController.Instance);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
            Notify();
    }
}
