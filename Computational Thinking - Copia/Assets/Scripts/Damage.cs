﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Color flashColor;
    public Color regularColor;
    public Color normalColor;
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
        mySprite.color = normalColor;
    }
    public IEnumerator DeathCoroutine(float timer)
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlashCoroutine());
    }
}

