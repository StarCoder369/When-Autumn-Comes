using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class FadeProgressStart
{
    public float progressMark;
    public GameObject objectToEnable;
}

public class ForestSpirit : MonoBehaviour
{
    public bool fade;
    public float fadeProgress;
    public float fadeStartProgress;

    public List<FadeProgressStart> objectsToStartOnProgress;

    void Start()
    {
        fade = false;
        fadeProgress = 0;
    }

    void Update()
    {
        fadeProgress += Time.deltaTime;

        if (!fade && fadeProgress >= fadeStartProgress)
        {
            fade = true;
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Interact();
        }
    }

    public void StartIndicatorObjects()
    {
        foreach (FadeProgressStart item in objectsToStartOnProgress)
        {
            if (fadeProgress >= item.progressMark)
            {
                item.objectToEnable.SetActive(true);
            }
        }
    }

    public void Interact()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(worldPosition);

        if (hit == null)
        {
            return;
        }

        FadeObject forestObject = hit.GetComponent<FadeObject>();

        forestObject.Revive();
    }
}
