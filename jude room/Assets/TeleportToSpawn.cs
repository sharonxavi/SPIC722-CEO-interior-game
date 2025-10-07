using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    // The GameObject that represents your player/XR Rig.
    public GameObject xrRig;

    // A private variable to store the initial position.
    private Vector3 initialPosition;

    void Start()
    {
        // 1. Check if the XR Rig reference is set
        if (xrRig == null)
        {
            Debug.LogError("XR Rig GameObject is not assigned to the TeleportToSpawn script!", this);
            return;
        }

        // 2. Read and store the XR Rig's starting position
        initialPosition = xrRig.transform.position;
        Debug.Log($"Initial spawn position saved: {initialPosition}");
    }

    // This public function will be called by the button's event
    public void GoToSpawnPoint()
    {
        // 3. Teleport the XR Rig to the stored initial position
        xrRig.transform.position = initialPosition;
        Debug.Log("Teleported player back to spawn point.");
    }
}