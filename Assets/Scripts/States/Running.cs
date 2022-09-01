using UnityEngine;

public class Running : State
{
    public Running(Character character):base(character)
    {}

    public override string GetName()
    {
        return "Run";
    }

    public override void Update()
    {
        base.Update();
        if (character.IsPNJ) character.HorizontalMove();
        if (Mathf.Abs(character.transform.GetComponent<Rigidbody2D>().velocity.x) < 1) character.State = new Idling(character);
    }
}
