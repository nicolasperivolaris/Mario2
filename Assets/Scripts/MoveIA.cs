using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIA : MonoBehaviour
{
    private int direction = 1;
    public int HorSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction * HorSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        direction = direction * -1;
    }

}
