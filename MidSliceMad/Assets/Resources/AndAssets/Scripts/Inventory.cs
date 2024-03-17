using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Transform mainCameraTransform;
    private Vector3 offset;

    void Start()
    {
        // Find and store a reference to the Main Camera's transform
        mainCameraTransform = Camera.main.transform;

        // Calculate the initial offset between Inventory and Main Camera
        if (mainCameraTransform != null)
        {
            offset = transform.position - mainCameraTransform.position;
        }
    }

    void LateUpdate()
    {
        // Check if the Main Camera's transform is valid
        if (mainCameraTransform != null)
        {
            // Move the Inventory with an offset relative to the Main Camera's position
            transform.position = mainCameraTransform.position + offset;
        }
    }
}
