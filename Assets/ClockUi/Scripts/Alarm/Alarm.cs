using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
class Alarm
{
    private Text _textTime;
    private InputField _inputSetAlarm;
    private Button _doneAlarm;

    private Transform _hourArrow;
    private Transform _minuteArrow;
    
    private string _setAlarmTextValue;

    public Alarm(Text textTime, InputField inputSetAlarm, Button doneAlarm, Transform hourArrow, Transform minuteArrow)
    {
        _textTime = textTime;
        _inputSetAlarm = inputSetAlarm;
        _doneAlarm = doneAlarm;

        _hourArrow = hourArrow;
        _minuteArrow = minuteArrow;
    }

    public string ClockAlarm()
    {

        float minute = _minuteArrow.localEulerAngles.z;
        minute = (360 - minute) / 6f;

        float hour = _hourArrow.localEulerAngles.z;
        hour = (360 - hour) / 30;
        hour = DateTime.Now.AddHours(hour).Hour;

         //Debug.Log("Hour " + DateTime.Now.AddHours(hour).Hour);
         // Debug.Log("minute " + Mathf.Floor(minute));
        string result = $"{hour}:{Mathf.Floor(minute)}";
        return result;
    }
    
    public void Set()
    {
        Activate();
    }

    public void Done()
    {
        Deactivate();
        ClockAlarm();

        if (_inputSetAlarm.text == "")       
            _setAlarmTextValue = ClockAlarm();
        else
            _setAlarmTextValue = _inputSetAlarm.text;

        EventBus.OnGetAlarmValue?.Invoke((_setAlarmTextValue));
    }

    public void DinDon()
    {
        Debug.Log("Бзынь-Бзынь");
    }

    private void Deactivate()
    {
        _textTime.gameObject.SetActive(true);

        _inputSetAlarm.gameObject.SetActive(false);

        _doneAlarm.gameObject.SetActive(false);
    }

    private void Activate()
    {
        _textTime.gameObject.SetActive(false);

        _inputSetAlarm.gameObject.SetActive(true);

        _doneAlarm.gameObject.SetActive(true);
    }

}
