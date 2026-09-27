using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float fadeMult = 0;

    public ParticleSystem wind;
    public float startEmission;
    public float endEmission;
    public float timeToLerp;

    public string nextScene;

    float time = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        time += Time.deltaTime;
        fadeMult += Time.deltaTime / 10;

        float percentage = Mathf.Clamp01(time / timeToLerp);

        float windPercentage = Mathf.Lerp(startEmission, endEmission, percentage);

        var emission = wind.emission;
        emission.rateOverTime = windPercentage;

        if (time >= 23f)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}