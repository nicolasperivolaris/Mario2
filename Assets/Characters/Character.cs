using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IObserver
{
    public bool IsFrozen { get; set; }
    protected Vector2 _lastVelocity;

    private void Update()
    {
        
    }

    void IObserver.Update(IObservable observable)
    {
        if (IsFrozen)
            GetComponent<Rigidbody2D>().velocity = _lastVelocity;
        else
            _lastVelocity = GetComponent<Rigidbody2D>().velocity;
        IsFrozen = !IsFrozen;
    }
}
