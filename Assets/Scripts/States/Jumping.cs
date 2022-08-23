using UnityEngine;

public class Jumping : State
{
    public Jumping(Movable move) : base(move)
    {
        move.GetComponent<Rigidbody2D>().velocity = new Vector2(move.GetComponent<Rigidbody2D>().velocity.x, move.UpSpeed);
    }
    public override string GetName()
    {
        return "Jump";
    }
    public override void Jump()
    {}
}
