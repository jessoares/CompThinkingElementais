using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float position;
    private float Speed;
    private float Width;
    private float Height;
    private float timeCounter;
    public float x;
    public float y;
    public float z;
    public Transform center;
    public ParticleSystem fire;
    public Transform particlePosition;
    public enum State
    {
        Idle,
        Move
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


   public IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(2.7F);
        Instantiate(fire,particlePosition.position,Quaternion.identity);
        state = State.Idle;
    }

}
