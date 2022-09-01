using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Met en mouvement un <see cref="GameObject"/>
/// </summary>
public class Movable : Character
{

    private void Awake()
    {
        IsPNJ = false;
        HorSpeed = 9;
        UpSpeed = 16;

        State = new Idling(this);
    }

    public void Jump()
    {
        State.Jump();
    }
}
