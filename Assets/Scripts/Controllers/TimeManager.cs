using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance = null;
    public static TimeManager Instance
    {
        get { return instance; }
    }

    [SerializeField]
    [Range(0f, 1f)]
    private float slowdownShotFactor = 0f;
    [SerializeField]
    [Range(0f, 1f)]
    private float slowdownHitFactor = 0f;
    [SerializeField]
    [Tooltip("Duration of slowmotion in seconds")]
    private float slowdownHitLength = 0f;

    private bool isHit = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DoSlwomotionWhileShot()
    {
        Time.timeScale = slowdownShotFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void DoSlwomotionWhileHit()
    {
        if (!isHit)
        {
            Time.timeScale = slowdownHitFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

            StartCoroutine(SlowmotionHitRoutine());
            isHit = true;
        }
    }

    IEnumerator SlowmotionHitRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);

        while(Time.timeScale < 1f)
        {
            Time.timeScale += (1f / slowdownHitLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            yield return null;
        }
    }
}
