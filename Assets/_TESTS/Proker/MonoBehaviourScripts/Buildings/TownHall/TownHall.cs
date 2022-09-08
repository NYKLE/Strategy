using System.Collections.Generic;
using BOYAREGames.Units;
using UnityEngine;

namespace BOYAREGames.Buildings
{
    public class TownHall : MonoBehaviour
    {
        [field: SerializeField] public Transform GatheringPoint { get; private set; }

        private List<Civilian> _civilians = new List<Civilian>();

        private void OnCivilianSpawn(Civilian civilian)
        {
            _civilians.Add(civilian);

            civilian.GoToGatheringPoint(GatheringPoint.transform.position);
        }

        private void OnEnable()
        {
            Events.Events.Civilian.onSpawnAction += OnCivilianSpawn;
        }

        private void OnDisable()
        {
            Events.Events.Civilian.onSpawnAction -= OnCivilianSpawn;
        }
    }
}
