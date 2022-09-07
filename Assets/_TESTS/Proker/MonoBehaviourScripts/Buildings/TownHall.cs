using BOYAREGames.Units;
using UnityEngine;

namespace BOYAREGames.Buildings
{
    public class TownHall : MonoBehaviour
    {
        [field: SerializeField] public Transform GatheringPoint { get; private set; }

        private void OnCivilianSpawn(Civilian civilian)
        {
            civilian.GoToGatheringPoint(GatheringPoint.transform.position);
        }

        private void OnEnable()
        {
            Events.Events.Civilian.Spawn += OnCivilianSpawn;
        }

        private void OnDisable()
        {
            Events.Events.Civilian.Spawn -= OnCivilianSpawn;
        }
    }
}
