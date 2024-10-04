using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Programmed for GAME410 at George Mason University
// Educational and research use only

public class CameraController : MonoBehaviour
{
    #region Variables

    [Header("-=- Camera Controller -=-")]
    [Space]
    [Tooltip("The main game camera")]
    public Camera MainCam; // Ideally only one camera should be used
    [Space]

    [Tooltip("Should the Camera follow and adjust the players?")]
    [SerializeField] private bool AdjustCam; // Simple on/off switch

    [Tooltip("The player gameobjects.")]
    [SerializeField] private Transform[] Players; // To replace with Playercontroller to vary speed

    [SerializeField] private float MinFOV = 20f; // Adjust settings as needed
    [SerializeField] private float MaxFOV = 60f;
    //[SerializeField] private float TrackDistance = 150f;
    #endregion

    #region CameraLoop
    private void LateUpdate() // Switched to lateupdate to calculate after physics
    {
        if (AdjustCam)
        {
            Bounds bounds = CalculateBounds(Players);
            AdjustCameraPosition(bounds);
            AdjustCameraFOV(bounds);
        }
    }
    #endregion

    #region Helper Scripts

    // Draw a fake "capsule" around the player
    // We dont want to use collision as its expensive in update loops and the script
    // fires after physics calculations.

    private Bounds CalculateBounds(Transform[] transforms) 
    {
        if (transforms.Length == 0)
        {
            return new Bounds();
        }

        var bounds = new Bounds(transforms[0].position, Vector3.zero);

        foreach (var t in transforms)
        {
            bounds.Encapsulate(t.position);
        }

        return bounds;
    }

    private void AdjustCameraPosition(Bounds bounds) // Move the camera to the center of the players
    {
        Vector3 center = bounds.center;
        MainCam.transform.LookAt(center);
    }

    private float CalculateFOV(Bounds bounds, float distancetofar) // Calculate the FOV needed to adjust
    {
        float boundsize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
        float fov = Mathf.Atan2(boundsize / 2, distancetofar) * Mathf.Rad2Deg * 2;
        return fov;
    }

    private void AdjustCameraFOV(Bounds bounds) // Adjust the camera's FOV based on the distance from furthest players
    {
        float distancetofar = Vector3.Distance(MainCam.transform.position, bounds.ClosestPoint(MainCam.transform.position));
        float fov = CalculateFOV(bounds, distancetofar);
        MainCam.fieldOfView = Mathf.Clamp(fov, MinFOV, MaxFOV);
    }


    #endregion
}
