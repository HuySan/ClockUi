using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
 //---------------
 //Точка входа
 //---------------
    [SerializeField]
    private Transform _hourArrow, _minuteArrow, _secondArrow;

    [SerializeField]
    private Text _timeText;

    [SerializeField]
    private Text _alarmText;

    [SerializeField]
    private InputField _inputSetAlarm;
    [SerializeField]
    private Button _doneAlarm;

    private Html_Parser _time;
    private ArrowMove _arrowMove;
    private Alarm _alarm;

    private bool _active;

    private TimeSpan _alarmValue;

    void Awake()
    {
        _active = true;

        _time = new Html_Parser();
        _arrowMove = new ArrowMove(_hourArrow, _minuteArrow, _secondArrow);
        _alarm = new Alarm(_timeText, _inputSetAlarm, _doneAlarm, _hourArrow, _minuteArrow);      
    }

    void Update()
    {
        if (!_active)
            return;
        _arrowMove.Moving(_time.GetTime());

        _timeText.text = NiceStringFormat(_time.GetTime());

        CallingAlarm();
    }

    private void OnEnable()
    {
        EventBus.OnInactiveClock += InactiveClock;
        EventBus.OnGetAlarmValue += AlarmValue;
    }

    private void OnDisable()
    {
        EventBus.OnInactiveClock -= InactiveClock;
        EventBus.OnGetAlarmValue -= AlarmValue;
    }

    private void InactiveClock(bool active)
    {
        _active = active;
        if (!_active)
            _alarm.Set();

        if (_active)
            _alarm.Done();
    }

    private void AlarmValue(string value)
    {
        _alarmText.text = $"Ваш будильник прозвенит в  {value}";

        bool isAlarm = TimeSpan.TryParse(value, out TimeSpan result);

        if (!isAlarm)
        {
            Debug.Log("Неверно введены параметры для будильника, используйие следующий синтаксис: 00:00");
        }
        _alarmValue = result;
    }

    private void CallingAlarm()
    {
        if (_alarmValue.TotalSeconds == 0)
            return;

        if (Mathf.Floor((float)_time.GetTime().TotalSeconds) == _alarmValue.TotalSeconds)
            _alarm.DinDon();
    }

    private string NiceStringFormat(TimeSpan timeSpan)
    {
        return string.Format("{0}:{1}:{2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
}
