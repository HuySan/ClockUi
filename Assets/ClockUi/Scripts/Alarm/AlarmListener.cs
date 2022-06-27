using UnityEngine;
using UnityEngine.UI;
class AlarmListener : MonoBehaviour
{
    [SerializeField]
    private Button _buttonSetAlarm;
    [SerializeField]
    private Button _buttonDone;


    private void OnEnable()
    {
        _buttonSetAlarm.onClick.AddListener(OnButtonSetAlarmClick);
        _buttonDone.onClick.AddListener(OnButtonSetAlarmDone);
    }

    private void OnDisable()
    {
        _buttonSetAlarm.onClick.RemoveListener(OnButtonSetAlarmClick);
        _buttonDone.onClick.RemoveListener(OnButtonSetAlarmDone);
    }

    private void OnButtonSetAlarmClick()
    {
        //остановка движения стрелок
        EventBus.OnInactiveClock?.Invoke(false);
    }

    private void OnButtonSetAlarmDone()
    {
        EventBus.OnInactiveClock?.Invoke(true);
    }

}
