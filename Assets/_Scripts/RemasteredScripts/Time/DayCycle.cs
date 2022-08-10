using System;
using GameInit.Component;
using UnityEngine;

namespace GameInit.TimeCycle
{
    public class DayCycle : ILateUpdate
    {
        public int Days { get; private set; }
        public DayTimeType DayTimeType { get; private set; }

        private float _quater;
        private float _timePassed;
        private int _quaterCount;

        public DayCycle(DayCycleComponent dayCycleComponent)
        {
            _quater = dayCycleComponent.DayLength * 0.25f;
        }

        public void OnLateUpdate()
        {
            _timePassed += Time.deltaTime;

            if (_timePassed > _quater)
            {
                _quaterCount++;

                switch (_quaterCount)
                {
                    case 1:
                        DayTimeType = DayTimeType.Morning;
                        break;
                    case 2:
                        DayTimeType = DayTimeType.Midday;
                        break;
                    case 3:
                        DayTimeType = DayTimeType.Evening;
                        break;
                    case 4:
                        Days++;
                        _quaterCount = 0;
                        DayTimeType = DayTimeType.Night;
                        break;
                    default:
                        throw new Exception($"No such time of day", null);
                }

                _timePassed = 0;
            }
        }


    }
}
