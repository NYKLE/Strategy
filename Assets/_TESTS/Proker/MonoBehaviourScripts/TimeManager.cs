using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _quaterDurationInSeconds;
    public int Days { get; private set; }
    public bool IsPaused { get; set; }

    private int _quaterCount;
    private float _timePassed;

    private void Update()
    {
        if (IsPaused == false)
        {
            _timePassed += Time.deltaTime;

            if (_timePassed > _quaterDurationInSeconds)
            {
                _quaterCount++;

                switch (_quaterCount)
                {
                    case 1:
                        Events.Time.onMorning?.Invoke();
                        Debug.Log("Morning");
                        break;
                    case 2:
                        Events.Time.onMidday?.Invoke();
                        Debug.Log("Midday");
                        break;
                    case 3:
                        Events.Time.onEvening?.Invoke();
                        Debug.Log("Evening");
                        break;
                    case 4:
                        Days++;
                        _quaterCount = 0;
                        Events.Time.onNight?.Invoke();
                        Debug.Log("Night");
                        break;
                    default:
                        throw new Exception($"No such time of day", null);
                }

                _timePassed = 0;
            }
        }
    }
}
