using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public float fadeStart;
    public float totalFadeAmount;
    public float fadeProgress;

    public SpriteRenderer sprite;

    public ForestSpirit spirit;

    float fadePercent;

    void Start()
    {
        SetAlpha(1);
        fadeProgress = totalFadeAmount;
    }

    public void SetAlpha(float alphaToSet)
    {
        Color tempColor = sprite.color;
        tempColor.a = alphaToSet;
        sprite.color = tempColor;
    }

    void Update()
    {
        if (spirit.fadeProgress >= fadeStart)
        {
            fadeProgress -= Time.deltaTime * GameManager.Instance.fadeMult;
        }
        fadePercent = fadeProgress / totalFadeAmount;
        SetAlpha(fadePercent);
    }

    public void Revive()
    {
        if (fadePercent < 1)
        {
            fadeProgress += GameManager.Instance.fadeMult * 3;
        }
    }
}
