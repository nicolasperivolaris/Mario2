using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frozen : State
{
    public Frozen(Character c):base(c)
    {
        c.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        c.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        c.GetComponent <Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        foreach (var item in c.GetComponentsInChildren<Collider2D>())
        {
            item.enabled = false;
        }
    }
    public override string GetName()
    {
        return "Frozen";
    }

    public override void Update()
    {
    }

}
