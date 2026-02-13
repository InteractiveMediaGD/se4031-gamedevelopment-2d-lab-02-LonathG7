using UnityEngine;

public class ObjectCleanup : MonoBehaviour
{
    public float destroyXBoundary = -10f; // Adjust based on your screen size

    void Update()
    {
        // If the object moves too far to the left, delete it
        if (transform.position.x < destroyXBoundary)
        {
            Destroy(gameObject);
        }
    }
}