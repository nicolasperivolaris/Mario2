using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Movable Player;
    private GameObject Enemies;
    private static Command<Movable> Jump = new JumpCommand<Movable>();
    private static Command<Movable> Left = new LeftCommand<Movable>();
    private static Command<Movable> Right = new RightCommand<Movable>();
    private bool _jumpLock = false;
    void Start()
    {
        Player = GameObject.Find("Player").gameObject.GetComponent<Movable>();
        Enemies = GameObject.Find("Enemies").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Command<Movable> command = HandleInput();
        command?.Execute(Player);
    }

    private Command<Movable> HandleInput()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        
        if (!_jumpLock && (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") == 1))
            return Jump;
        if (direction != 0)
            if(direction == 1) return Right;
            else return Left;
        else return null;
    }
}
