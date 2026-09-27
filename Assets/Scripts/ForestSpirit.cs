using UnityEngine;

public class ForestSpirit : MonoBehaviour
{
    public float fadeProgress;

    private void Start()
    {
        fadeProgress = 0;
    }

    private void Update()
    {
        fadeProgress += Time.deltaTime;
    }
}