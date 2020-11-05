using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAmeraControl : MonoBehaviour
{
    private CinemachineVirtualCamera virtCam;

    [SerializeField] GameObject playerNoSw;
    [SerializeField] GameObject playerSw;

    void Start()
    {
        virtCam = GetComponent<CinemachineVirtualCamera>();   
    }

    void Update()
    {
        if (playerNoSw.activeInHierarchy)
            virtCam.Follow = playerNoSw.transform;
        else if (playerSw.activeInHierarchy)
            virtCam.Follow = playerSw.transform;
    }
}
