using UnityEngine;
using UnityEngine.InputSystem;


public class GazeRayRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public InputActionProperty eyeGazeAction; // Bind to Eye Gaze Pose in Input System
    public Transform rayOrigin;
    public float maxDistance = 10f;

    void Update()
    {
        if (eyeGazeAction.action != null)
        {
            Vector3 gazeDirection = eyeGazeAction.action.ReadValue<Vector3>();
            if (gazeDirection != Vector3.zero)
            {
                Ray gazeRay = new Ray(rayOrigin.position, gazeDirection);
                lineRenderer.SetPosition(0, gazeRay.origin);

                if (Physics.Raycast(gazeRay, out RaycastHit hit, maxDistance))
                {
                    lineRenderer.SetPosition(1, hit.point);
                }
                else
                {
                    lineRenderer.SetPosition(1, gazeRay.origin + gazeRay.direction * maxDistance);
                }
            }
        }
    }
}
