using UnityEngine;

public class CheckWithinView : MonoBehaviour
{
    Camera cameraCheck; // Camera to check
    Collider colliderCheck; // Colllider to check
    Plane[] cameraFrustum; // Planes of the frustum
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraCheck = Camera.main; // Grabbing main camera
        colliderCheck = GetComponent<Collider>(); // Grabbing the collider to check on object
    }


    // Checks if object's collider is within camera frustum,
    // WARNING: this does not take into account if the object is in darkness or behind another object
    public bool IsVisibleToCamera() {
        Bounds bounds = colliderCheck.bounds; 
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cameraCheck); // Getting the frustum planes in object
        return GeometryUtility.TestPlanesAABB(cameraFrustum, bounds); // Checking bounds
    }
}


