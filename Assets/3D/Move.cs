using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 _offset;
    private float _zCoord;

    public Type moveType;
    public enum Type
    {
        normal,
        XAxis,
        YAxis, 
        ZAxis,
        XYPlane,
        YZPlane,
        ZXPlane
    }
    private void OnMouseDown()
    {
        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        _offset = transform.position - GetMouseWorldPos();
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        Vector3 newPos = new Vector3(0, 0, 0);
        switch (moveType)
        {
            case Type.normal:
                newPos = GetMouseWorldPos() + _offset;
                break;
            case Type.XAxis:
                newPos.x = GetMouseWorldPos().x + _offset.x;
                newPos.y = transform.position.y;
                newPos.z = transform.position.z;
                break;
            case Type.YAxis:
                newPos.x = transform.position.x;
                newPos.y = GetMouseWorldPos().y + _offset.y;
                newPos.z = transform.position.z;
                break;
            case Type.ZAxis:
                newPos.x = transform.position.x;
                newPos.y = transform.position.y;
                newPos.z = GetMouseWorldPos().z + _offset.z;
                break;
            case Type.XYPlane:
                newPos.x = GetMouseWorldPos().x + _offset.x;
                newPos.y = GetMouseWorldPos().y + _offset.y;
                newPos.z = transform.position.z;
                break;
            case Type.YZPlane:
                newPos.x = transform.position.x;
                newPos.y = GetMouseWorldPos().y + _offset.y;
                newPos.z = GetMouseWorldPos().z + _offset.z;
                break;
            case Type.ZXPlane:
                newPos.x = GetMouseWorldPos().x + _offset.x;
                newPos.y = transform.position.y;
                newPos.z = GetMouseWorldPos().z + _offset.z;
                break;
        }
        transform.position = newPos;
    }
}
