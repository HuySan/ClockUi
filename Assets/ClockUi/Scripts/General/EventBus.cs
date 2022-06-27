using System;
public static class EventBus
{
   public static Action<bool> OnInactiveClock;
   public static Action<string> OnGetAlarmValue;
}
