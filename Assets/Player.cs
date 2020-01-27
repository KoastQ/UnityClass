using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector2 velocity = Vector2.zero;
    private Vector2 clickPos;   //to store the mouse position when clicked

    // Start is called before the first frame update
    void Start()
    {
        clickPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        moveToMouse();
    }

    void move()
    {
        Vector2 dir = Vector2.zero;

        //Reads keys
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;

        }

        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;

        }

        velocity = dir.normalized * speed;
        //Apply the change
        transform.position = transform.position + (Vector3)(velocity* Time.deltaTime);
    }

    void moveToMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.MoveTowards(transform.position, clickPos,10*(speed*Time.deltaTime));

        }
    }

}
