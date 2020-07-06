using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float Speed;
    private float Width;
    private float Height;
    private float timeCounter = 0;
    public float x;
    public float y;
    public float z;
    public Transform center;
    void Start()
    {
        Speed = 2f;
        Width = 2;
        Height = 2;
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
        timeCounter = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * Speed;
        x = Mathf.Cos(timeCounter) * Width;
        y = -0.5f;
        z = Mathf.Sin(timeCounter) * Height;
        transform.position = new Vector3(x, y, z) + center.position;

        
    }
}
