using UnityEngine;

public class Leaf : MonoBehaviour
{
    public SpriteRenderer sprite;

    public Color summerTint = Color.white;
    public Color autumnTint;

    public float autumnTime = 10f;

    private float time;

    private void Start()
    {
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        summerTint.a = sprite.color.a;
        autumnTint.a = sprite.color.a;

        sprite.color = summerTint;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time < autumnTime)
        {
            float t = time / autumnTime;
            Color tint = Color.Lerp(summerTint, autumnTint, t);
            tint.a = sprite.color.a;
            sprite.color = tint;
        }
    }
}