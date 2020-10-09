using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float position;
    private float Speed;
    private float Width;
    private float Height;
    public float timeCounter;
    public float x;
    public float y;
    public float z;
    public Transform center;
    public Transform attackPoint;
    public float paraboleCounter;
  
    public enum State
    {
        Idle,
        Move,
        Attack,
        Death
    }
    public State state;
    void Start()
    {
        Speed = 1.5f;
        Width = 1.7f;
        Height = 1.3f;
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
        state = State.Idle;
        timeCounter = position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Move:
                Circle();
                break;
            case State.Idle:
                break;
            case State.Attack:
                Attack();
                break;
          

        }
    }

    void Moving()
    {
        state = State.Move;
    }

    void Still()
    {
        state = State.Idle;
    }

    void Circle()
    {
        timeCounter += Time.deltaTime * Speed;
        x = Mathf.Cos(timeCounter) * Width;
        y = 0.1f;
        z = Mathf.Sin(timeCounter) * Height;
        transform.position = new Vector3(x, y, z) + center.position;
    }

    void Attack()
    {
        float slideSpeed = 1f;
        transform.position += (attackPoint.position - this.transform.position) * slideSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position,attackPoint.position) < 0.4f)
        {
            state = State.Idle;
        }
    }

  
 

}
