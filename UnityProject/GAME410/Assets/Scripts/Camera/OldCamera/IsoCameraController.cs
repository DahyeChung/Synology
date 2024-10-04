using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCameraController : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        Debug.Log(currentCameraIndex);
        Debug.Log(cameras.Length);
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Tab))
      {
        if (currentCameraIndex < cameras.Length - 1) { currentCameraIndex++; cameras[currentCameraIndex - 1].enabled = false; }
        else { cameras[currentCameraIndex].enabled = false; currentCameraIndex = 0;  }
        cameras[currentCameraIndex].enabled = true;
        Debug.Log(currentCameraIndex);
      }
    }
}
