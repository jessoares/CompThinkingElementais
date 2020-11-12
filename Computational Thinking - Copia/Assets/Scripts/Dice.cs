using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Image image;
    public Sprite[] diceSides;
    public float rollRate;
    float nextRollTime;


    public void  Roll()
    {
        nextRollTime = Time.time + 1f / rollRate;
        if (Time.time <=  nextRollTime)
        {
            StartCoroutine(RollTheDice());
        }

    }
    public IEnumerator RollTheDice()
    { 

        int randomDiceSide = 0;
        int finalSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            image.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        finalSide = randomDiceSide;
   }
}
