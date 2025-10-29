using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EjectScript : MonoBehaviour
{
    public string menuScene;
    public InputAction action;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (action.triggered)
        {
            SceneManager.LoadScene(menuScene);
        }
    }
}
