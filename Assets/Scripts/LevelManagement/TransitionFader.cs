using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFader : ScreenFader
{
    [SerializeField]
    private float lifeTime = 1f;

    [SerializeField]
    private float delay = 0.3f;
    public float Delay { get { return delay; } }

    protected void Awake()
    {
        lifeTime = Mathf.Clamp(lifeTime, FadeOnDuration + FadeOffDuration + delay, 10f);
    }

    private IEnumerator PlayRoutine()
    {
        SetAlpha(clearAlpha);
        yield return new WaitForSeconds(delay);

        FadeOn();
        float onTime = lifeTime = (FadeOffDuration + delay);

        yield return new WaitForSeconds(onTime);

        FadeOff();
        Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    public static void PlayTransition(TransitionFader transitionPrefab)
    {
        if (transitionPrefab != null)
        {
            TransitionFader instance = Instantiate(transitionPrefab, Vector3.zero, Quaternion.identity);
            instance.Play();
        }
    }
}
