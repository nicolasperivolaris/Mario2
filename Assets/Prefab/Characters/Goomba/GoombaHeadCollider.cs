using Assets.Scripts.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHeadCollider : Observable
{
    private Goomba _goomba;
    // Start is called before the first frame update
    void Start()
    {
        _goomba = transform.parent.GetComponent<Goomba>();
        Register(GUIController.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag.Equals("Player") && !(_goomba.State is Frozen))
        {
            transform.parent.GetComponent<Animator>().SetBool("Dead", true);
            _goomba.State = new Frozen(transform.parent.GetComponent<Goomba>());
            Notify();
        }
    }
}
