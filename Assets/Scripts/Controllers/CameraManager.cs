using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera CVCamera = null;

    [SerializeField]
    private float newOrthgraphicSize = default;

    private float oldOrthographicSize;

    private void Awake()
    {
        if (CVCamera)
        {
            oldOrthographicSize = CVCamera.m_Lens.OrthographicSize;
        }
    }

    public void TargetUpdate(Transform target)
    {
        CVCamera.Follow = target;
        CVCamera.m_Lens.OrthographicSize = newOrthgraphicSize;
    }

}
