using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Observer
{
    public abstract class Observable : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Notify()
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
}