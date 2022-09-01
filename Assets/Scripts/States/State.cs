using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public State(Character character)
    {
        this.character = character;
    }
    public Character character { get; set; }
    public abstract string GetName();
    public virtual void Jump()
    {
        character.State = new Jumping(character);
    }

    public virtual void Update() 
    {
        if (character.GetComponent<Rigidbody2D>().velocity.y < -1)
        {
            character.State = new Falling(character);
            return;
        }
        else if (character.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            character.State = new Running(character);
            return;
        }
    }
}
public class Idling : State
{
    public Idling(Character character):base(character)
    {}

    public override void Update()
    {
        base.Update();
        if (Mathf.Abs(character.transform.GetComponent<Rigidbody2D>().velocity.x)>1) character.State = new Running(character);
    }

    public override string GetName()
    {
        return "Idle";
    }
}

public class Falling : State
{
    public Falling(Character character) : base(character)
    { }

    public override string GetName()
    {
        return "Fall";
    }

    public override void Jump()
    {
    }

    public override void Update()
    {

        if ((character.transform.GetComponent<Rigidbody2D>().velocity.y) > -1) character.State = new Idling(character);
    }
}

public class Death : State
{
    public Death(Character character) : base(character)
    {
        character.gameObject.SetActive(false);
    }

    public override string GetName()
    {
        return "Dead";
    }

    public override void Update()
    {    }
    public override void Jump()
    {    }
}