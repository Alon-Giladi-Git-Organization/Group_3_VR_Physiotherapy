using UnityEngine;

public class VRButton : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneToLoad = "GameRoom";
    private bool pressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed)
        {
            pressed = true;
            if (sceneLoader != null)
            {
                sceneLoader.LoadScene(sceneToLoad);
            }
        }
    }
}