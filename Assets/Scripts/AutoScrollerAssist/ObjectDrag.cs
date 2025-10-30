using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;



    void OnMouseDown()
    {
        mZCoord = Vector3.Distance(Camera.main.transform.position, transform.position);

        mOffset = transform.position - GetMouseWorldPos();
    }



    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()
    {
        Vector3 targetPos = GetMouseWorldPos() + mOffset;

        transform.position = new Vector3(transform.position.x, targetPos.y, transform.position.z);
    }
}
