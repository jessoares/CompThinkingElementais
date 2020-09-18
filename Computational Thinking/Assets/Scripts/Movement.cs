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
        Width = 1.1f;
        Height = 1.1f;
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
            case State.Death:
                Death();
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
        y = -0.3f;
        z = Mathf.Sin(timeCounter) * Height;
        transform.position = new Vector3(x, y, z) + center.position;
    }

    void Attack()
    {
        float slideSpeed = 1f;
        transform.position += (attackPoint.position - this.transform.position) * slideSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position,attackPoint.position) < 0.7f)
        {
            state = State.Idle;
        }
    }

    void Death()
    {
        paraboleCounter += Time.deltaTime;
        paraboleCounter = paraboleCounter % 5f;
        transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10f, 5f, paraboleCounter / 5f);



    }
 

}
