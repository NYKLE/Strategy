using GameInit.Component;
using GameInit.TimeCycle;
using UnityEngine;

namespace GameInit.Farm
{
    public class FarmDayCycle : IUpdate
    {
        private DayCycle _dayCycle;
        private FarmComponent _farmComponent;

        private bool _isDoneDailyThing;

        public FarmDayCycle(DayCycle dayCycle, FarmComponent component)
        {
            _dayCycle = dayCycle;
        }

        public void OnUpdate()
        {
            if (_farmComponent.gameObject.activeSelf)
            {
                if (_dayCycle.DayTimeType == DayTimeType.Midday)
                {
                    if (_isDoneDailyThing == false)
                    {
                        Debug.Log("Daily Thing by Farm!!!");
                        _isDoneDailyThing = true;
                    }
                }
                else
                {
                    _isDoneDailyThing = false;
                }
            }
        }
    }
}
