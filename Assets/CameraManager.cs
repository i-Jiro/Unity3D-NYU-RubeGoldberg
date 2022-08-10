using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<TriggerZone> _triggerZones;
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;
    private int _index = 0;

    private void OnDisable()
    {
        foreach (var trigger in _triggerZones)
        {
            trigger.OnBallEnter -= ActivateNextCamera;
        }
    }

    private void Awake()
    {
        foreach (var trigger in _triggerZones)
        {
            trigger.OnBallEnter += ActivateNextCamera;
        }
    }
    
    private void ActivateNextCamera()
    {
        _virtualCameras[_index].gameObject.SetActive(false);
        _index++;
        if (_index > _virtualCameras.Count) return;
        _virtualCameras[_index].gameObject.SetActive(true);
    }
}
