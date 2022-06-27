using System;
using UnityEngine;

class ArrowMove
{
    private Transform _hourArrow, _minuteArrow, _secondArrow;

    private const float _degreesPerHour = 30f, _degreesPerMinute = 6f, _degreesPerSecond = 6f;

    public ArrowMove() { }

    public ArrowMove(Transform hourArrow, Transform minuteArrow, Transform secondArrow)
    {
        _hourArrow = hourArrow;
        _minuteArrow = minuteArrow;
        _secondArrow = secondArrow;
    }

    public void Moving(TimeSpan time)
    {
        _hourArrow.localRotation = Quaternion.Euler(0f, 0f, -(float)time.TotalHours * _degreesPerHour);
         _minuteArrow.localRotation = Quaternion.Euler(0f, 0f, -(float)time.TotalMinutes * _degreesPerMinute);
         _secondArrow.localRotation = Quaternion.Euler(0f, 0f, -DateTime.Now.Second * _degreesPerSecond);
    }
}
