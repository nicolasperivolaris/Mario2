using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public State(Movable move)
    {
        this.move = move;
    }
    public Movable move { get; set; }
    public abstract string GetName();
    public virtual void Jump()
    {
        move.state = new Jumping(move);
    }

    public virtual void Update() { }
}

public class Running : State
{
    public Running(Movable move):base(move)
    {}

    public override string GetName()
    {
        return "Run";
    }

    public override void Update()
    {
        if (Mathf.Abs(move.transform.GetComponent<Rigidbody2D>().velocity.x) < 1) move.state = new Idling(move);
    }
}
public class Idling : State
{
    public Idling(Movable move):base(move)
    {}

    public override void Update()
    {
        if(Mathf.Abs(move.transform.GetComponent<Rigidbody2D>().velocity.x)>1) move.state = new Running(move);
    }

    public override string GetName()
    {
        return "Idle";
    }
}
public class Falling : State
{
    public Falling(Movable move):base(move)
    {}

    public override string GetName()
    {
        return "Fall";
    }
}
