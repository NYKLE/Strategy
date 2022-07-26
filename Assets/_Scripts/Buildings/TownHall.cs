using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TownHall : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public Vector3 GetSpawnPoint()
    {
        return _spawnPoint.position;
    }
}
