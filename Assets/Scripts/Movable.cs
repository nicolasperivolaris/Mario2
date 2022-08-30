using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public int UpSpeed = 16;
    public int HorSpeed = 7;
    public Animator animator;
    private State _state;
    public State state {
        get {
            return _state;
        }
        set{
            try
            {
                animator.SetBool(_state.GetName(), false);
                animator.SetBool(value.GetName(), true);
            }
            catch{ }
            _state = value;
        }
    }

    private void Start()
    {
        state = new Idling(this);
    }

    private void Update()
    {
        state.Update();
    }

    public void Jump()
    {
        state.Jump();
    }

    private void ChangeFacing(int dir)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(dir);
        transform.localScale = scale;
    }

    public void Left()
    {
        HorizontalMove(-1);
        ChangeFacing(-1);
    }

    public void Right()
    {
        HorizontalMove(1);
        ChangeFacing(1);
    }

    private void HorizontalMove(int dir)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir * HorSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(state is Jumping) state = new Idling(this);
    }
}
