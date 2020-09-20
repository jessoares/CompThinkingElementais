using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject winner;
    public GameObject loser;
    private bool moving;

    private float startPosX;
    private float startPosY;

    public bool vencedor;
    public int corretos;
    public bool finish;



    private Vector3 resetPosition;

    void Start()
    {
        resetPosition = this.transform.position;
        corretos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX,mousePos.y - startPosY, this.gameObject.transform.localPosition.z);

            }
        }
    }


    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }
    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - winner.transform.localPosition.x)<= 2f && Mathf.Abs(this.transform.localPosition.y - winner.transform.localPosition.y) <= 2f)
        {
            if(vencedor == true)
            {
                corretos++;
            }
            this.transform.position = new Vector3(winner.transform.position.x, winner.transform.position.y, winner.transform.position.z);
            finish = true;
        }
        else if (Mathf.Abs(this.transform.localPosition.x - loser.transform.localPosition.x) <= 2f && Mathf.Abs(this.transform.localPosition.y - loser.transform.localPosition.y) <= 2f)
        {
            if (vencedor != true)
            {
                corretos++;
            }
            this.transform.position = new Vector3(loser.transform.position.x, loser.transform.position.y, loser.transform.position.z);
            finish = true;
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }

    }
}
