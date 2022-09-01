using UnityEngine;

public class Jumping : State
{
    public Jumping(Character character) : base(character)
    {
        character.GetComponent<Rigidbody2D>().velocity = new Vector2(character.GetComponent<Rigidbody2D>().velocity.x, character.UpSpeed);
    }
    public override string GetName()
    {
        return "Jump";
    }
    public override void Jump()
    {}

}
