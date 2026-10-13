using UnityEngine;

/// <summary>
/// Subclass: plays a sound when the object is selected.
/// Attach this script to the grabbable object (e.g. the sphere).
/// </summary>
public class PlayAudioAction : InteractableAction
{
    // The "speaker": drag the AudioSource (e.g. on AudioManager) here.
    [SerializeField] private AudioSource source;

    // The "recording": drag the audio file here.
    [SerializeField] private AudioClip clip;

    protected override void Execute()
    {
        // PlayOneShot does not cut off other sounds on the same source.
        source.PlayOneShot(clip);
    }
}
