using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera CVCamera = null;

    public void TargetUpdate(Transform target)
    {
        CVCamera.Follow = target;
        CVCamera.m_Lens.OrthographicSize = 5f;
    }

}
