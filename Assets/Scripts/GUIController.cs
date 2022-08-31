using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour, IObservable
{
    private List<IObserver> _observers = new List<IObserver>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void notify()
    {
        foreach (IObserver item in _observers)
        {
            item.Update(this);
        }
    }

    public void Register(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        _observers.Remove(observer);
    }

}
