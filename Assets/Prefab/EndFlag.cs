using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFlag : Observable
{
    // Start is called before the first frame update
    void Start()
    {
        Register(GUIController.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Notify();
    }
}
