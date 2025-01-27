using Cinemachine;
using UnityEngine;

public class WhenPlayerDied : MonoBehaviour
{
    [SerializeField] private Ball prefab;
    [SerializeField] private GameObject spawn;
    [SerializeField] private bool isSpawnNew = false;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if(!isSpawnNew) SpawnPrefab(spawn);

    }
    public void SpawnPrefab(GameObject spawn)
    {
        Ball player = Instantiate(prefab, spawn.transform.position, spawn.transform.rotation);
        player.WhenPlayerDied = this;
        virtualCamera.Follow = player.transform;

    }
    public void SpawnPrefab()
    {
        Ball player = Instantiate(prefab, spawn.transform.position, spawn.transform.rotation);
        player.WhenPlayerDied = this;
        virtualCamera.Follow = player.transform;

    }
}
