using UnityEngine;

public class BillboardedEntity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var activeCamera = Camera.current;
        if (!activeCamera) return;
        
        var cameraPosition = activeCamera.transform.position;
        var vecToThis = transform.position - cameraPosition;
        vecToThis.y = 0;
        vecToThis.Normalize();
        transform.rotation = Quaternion.LookRotation(vecToThis);
    }
}
