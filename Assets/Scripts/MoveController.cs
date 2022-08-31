using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de déplacer un <see cref="Movable"/> au clavier
/// </summary>
public class MoveController
{
    private Movable Player;
    private GameObject Enemies;
    private static Command<Movable> Jump = new JumpCommand<Movable>();
    private static Command<Movable> Left = new LeftCommand<Movable>();
    private static Command<Movable> Right = new RightCommand<Movable>();
    private Queue<Command<Movable>> CommandQueue = new Queue<Command<Movable>>();
    private bool _jumpLock = false;
    void Start()
    {
        Player = GameObject.Find("Player").gameObject.GetComponent<Movable>();
        Enemies = GameObject.Find("Enemies").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        foreach (Command<Movable> command in CommandQueue)
        {
            command?.Execute(Player);
        }       
    }

    private void HandleInput()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        
        if (!_jumpLock && (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") == 1))
            CommandQueue.Enqueue(Jump);
        if (direction != 0)
            if(direction == 1) CommandQueue.Enqueue(Right);
            else CommandQueue.Enqueue(Left);
    }
}
