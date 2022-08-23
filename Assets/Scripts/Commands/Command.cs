using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command<T>
{
    public abstract void Execute(T t);
}
public class LeftCommand<T> : Command<T> where T : Movable
{
    public override void Execute(T movable)
    {
        movable.Left();
    }
}
public class RightCommand<T> : Command<T> where T : Movable
{
    public override void Execute(T movable)
    {
        movable.Right();
    }
}

public class JumpCommand<T> : Command<T> where T : Movable
{
    public override void Execute(T movable)
    {
        movable.Jump();
    }
}
