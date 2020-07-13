using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOffFlashes;
    public SpriteRenderer mySprite;
    public IEnumerator FlashCoroutine()
    {
        int temp = 0;
        while (temp < numberOffFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        this.gameObject.SetActive(false);
    }
    public IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2.7f);
        StartCoroutine(FlashCoroutine());
    }
}

