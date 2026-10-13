using Oculus.Interaction;
using UnityEngine;

/// <summary>
/// Abstract base class: detects when the player selects (e.g. ray grabs) an object
/// and calls Execute(). Subclasses decide WHAT happens.
/// Do not attach this script to an object; attach a subclass instead.
/// </summary>
public abstract class InteractableAction : MonoBehaviour
{
    // Drag the child object that has the "Ray Interactable" component here.
    [SerializeField] private RayInteractable rayInteractable;

    // Start listening when the object becomes active.
    protected virtual void OnEnable()
    {
        rayInteractable.WhenStateChanged += OnStateChanged;
    }

    // Stop listening when the object is disabled or destroyed.
    protected virtual void OnDisable()
    {
        rayInteractable.WhenStateChanged -= OnStateChanged;
    }

    // Runs every time the interactable's state changes.
    private void OnStateChanged(InteractableStateChangeArgs args)
    {
        // Trigger only at the moment the object becomes selected.
        if (args.NewState == InteractableState.Select &&
            args.PreviousState != InteractableState.Select)
        {
            Execute();
        }
    }

    // Each subclass defines its own reaction.
    protected abstract void Execute();
}
