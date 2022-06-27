using UnityEngine;

class DragLogic
{
    public void GetMousePosition(Transform transform)
    {
        Vector3 mousePosition = Camera.main.WorldToScreenPoint(Input.mousePosition); ;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
