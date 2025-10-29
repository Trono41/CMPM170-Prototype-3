using UnityEngine;

public class BillboardedEntity : MonoBehaviour
{
    private Camera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_camera.transform.forward);
    }
}
