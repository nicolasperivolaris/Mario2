using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Observer
{
    public interface IObservable
    {
        public void Register(IObserver observer);
        public void Unregister(IObserver observer);
        public void notify();
    }
}