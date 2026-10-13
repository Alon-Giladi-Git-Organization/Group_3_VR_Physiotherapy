using UnityEngine;

// Attach to your "UI Manager" empty object.
// Both objects must already be set up for grabbing (Rigidbody, collider,
// Grabbable, Hand Grab / Ray Grab Interactable, Physics Grabbable).
public class ObjectSwapper : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject alternateObject;

    [Header("Options")]
    [Tooltip("Place the new object where the current one is, instead of its own start position.")]
    [SerializeField] private bool appearAtCurrentPosition = true;

    private Vector3 ballStartPosition;
    private Quaternion ballStartRotation;
    private Vector3 alternateStartPosition;
    private Quaternion alternateStartRotation;

    private void Awake()
    {
        if (ball != null)
        {
            ballStartPosition = ball.transform.position;
            ballStartRotation = ball.transform.rotation;
        }
        if (alternateObject != null)
        {
            alternateStartPosition = alternateObject.transform.position;
            alternateStartRotation = alternateObject.transform.rotation;
        }
    }

    private void Start()
    {
        // Experience always begins with the ball.
        ShowBall(true);
    }

    // Hook to the "Swap" button's On Click ()
    public void SwapToAlternate()
    {
        if (ball == null || alternateObject == null) return;

        Vector3 pos = appearAtCurrentPosition ? ball.transform.position : alternateStartPosition;
        Quaternion rot = appearAtCurrentPosition ? ball.transform.rotation : alternateStartRotation;

        Deactivate(ball);
        Activate(alternateObject, pos, rot);
    }

    // Hook to the "Reset" button's On Click ()
    public void ResetToBall()
    {
        ShowBall(true);
    }

    private void ShowBall(bool atStart)
    {
        if (ball == null) return;

        if (alternateObject != null)
            Deactivate(alternateObject);

        Activate(ball, ballStartPosition, ballStartRotation);
    }

    private static void Activate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        obj.SetActive(true);
        StopMotion(obj);
        obj.transform.SetPositionAndRotation(position, rotation);
    }

    private static void Deactivate(GameObject obj)
    {
        StopMotion(obj);
        obj.SetActive(false);
    }

    private static void StopMotion(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
