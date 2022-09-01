using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de déplacer un <see cref="Movable"/> au clavier
/// </summary>
public class MoveController:MonoBehaviour, IObserver
{
    private Movable Player;
    private GameObject Enemies;
    private static Command<Movable> Jump = new JumpCommand<Movable>();
    private static Command<Movable> Left = new LeftCommand<Movable>();
    private static Command<Movable> Right = new RightCommand<Movable>();
    private Queue<Command<Movable>> CommandQueue = new Queue<Command<Movable>>();
    public static MoveController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else throw new System.Exception("Can't create more than one MoveController");
    }
    void Start()
    {
        Player = GameObject.Find("Player").gameObject.GetComponent<Movable>();
        Enemies = GameObject.Find("Enemies");
        foreach (Character character in Enemies.GetComponentsInChildren<Character>())
        {
            character.Register(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        while(CommandQueue.Count > 0)
        {
            CommandQueue.Dequeue().Execute(Player);
        }      
    }

    private void HandleInput()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
            CommandQueue.Enqueue(Jump);
        if (direction != 0)
            if(direction == 1) CommandQueue.Enqueue(Right);
            else CommandQueue.Enqueue(Left);
    }

    public void FreezeAll(bool state)
    {
        Player.GetComponent<Rigidbody2D>().velocity = new Vector3();
        foreach (var item in Enemies.GetComponentsInChildren<Character>())
        {
            item.State = new Frozen(item);
        } 
    }

    public void Update(Observable observable)
    {
        if (observable is Goomba)
            FreezeAll(true);
    }
}
