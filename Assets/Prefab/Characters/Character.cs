using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Observable
{
    public bool IsPNJ = true;
    public int HorSpeed, UpSpeed;
    protected int direction = -1;


    private Animator animator;
    private State _state;
    public State State
    {
        get
        {
            return _state;
        }
        set
        {
            try
            {
                animator.SetBool(_state.GetName(), false);
                animator.SetBool(value.GetName(), true); 
            }
            catch { }
            _state = value;
        }
    }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }


    protected virtual void Update()
    {
        State.Update();
    }

    public void HorizontalMove()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * HorSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void ChangeFacing(int dir)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(dir);
        transform.localScale = scale;
    }

    public void Left()
    {
        direction = -1;
        HorizontalMove();
        ChangeFacing(direction);
    }

    public void Right()
    {
        direction = 1;
        HorizontalMove();
        ChangeFacing(direction);
    }
}
