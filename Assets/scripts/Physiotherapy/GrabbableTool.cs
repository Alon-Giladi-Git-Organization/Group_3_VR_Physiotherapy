using UnityEngine;

public class GrabbableTool : MonoBehaviour
{
    public static int heldToolsCount = 0;
    private bool isHeld = false;

    public void OnGrabbed()
    {
        if (!isHeld)
        {
            isHeld = true;
            heldToolsCount++;
        }
    }

    public void OnReleased()
    {
        if (isHeld)
        {
            isHeld = false;
            heldToolsCount--;
        }
    }
}