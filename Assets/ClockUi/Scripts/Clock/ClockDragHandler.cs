using UnityEngine;

class ClockDragHandler : MonoBehaviour
{
    private DragLogic  _dragLogic;
    private bool _clockIsActive;

    private void Awake()
    {
        _clockIsActive = true;
        _dragLogic = new DragLogic();
    }
    private void OnMouseDrag()
    {
        if (_clockIsActive)
            return;
        _dragLogic.GetMousePosition(this.transform);
    }

    private void OnEnable()
    {
        EventBus.OnInactiveClock += ClockIsActive;
    }

    private void OnDisable()
    {
        EventBus.OnInactiveClock -= ClockIsActive;
    }

    private void ClockIsActive(bool value)
    {
        _clockIsActive = value;
    }
}
