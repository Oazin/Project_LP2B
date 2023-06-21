using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFader : MonoBehaviour
{
    protected SpriteRenderer rend;
    protected const float FADE_DURATION = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        float alpha = rend.color.a;
        while (alpha > 0)
        {
            alpha = rend.color.a - Time.unscaledDeltaTime/FADE_DURATION;
            rend.color = new Color(1,1,1,alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float alpha = rend.color.a;
        while (alpha < 1 )
        {
            alpha = rend.color.a + Time.unscaledDeltaTime / FADE_DURATION;
            rend.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    public float LoadFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
        return FADE_DURATION;
    }
}
