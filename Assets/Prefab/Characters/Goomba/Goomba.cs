using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba: Character
{
    private bool _inCollision;
    protected override void Start()
    {
        base.Start();
        Register(GUIController.Instance);
    }

    protected void Awake()
    {
        HorSpeed = 3;
        State = new Running(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_inCollision)
            direction = direction * -1;
        _inCollision = true;
        if (collision.gameObject.tag.Equals("Player") && gameObject.active)
        {
            gameObject.SetActive(false);
            Notify();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _inCollision = false;
    }
}
