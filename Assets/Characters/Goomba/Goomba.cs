using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba: Character, IObserver
{
    private int direction = 1;
    public int HorSpeed = 3;
    private bool _triggerLock;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsFrozen)
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * HorSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_triggerLock)
            direction = direction * -1;
        _triggerLock = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _triggerLock = false;
    }
}
