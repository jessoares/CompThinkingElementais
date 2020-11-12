
using UnityEngine;

public class CanvasEffects : MonoBehaviour
{
    public Animator flashAnimator;
    public Animator fadeAnimator;
    public void Fade()
    {
        fadeAnimator.SetTrigger("Fade");
    }
    public void Flash()
    {
        flashAnimator.SetTrigger("Flash");
    }
}
