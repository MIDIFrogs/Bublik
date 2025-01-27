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
        if(!isSpawnNew) SpawnPrefab();
    }

    public void SpawnPrefab()
    {
        Ball player = Instantiate(prefab, spawn.transform.position, spawn.transform.rotation);
        player.WhenPlayerDied = this;
        if (virtualCamera != null)
            virtualCamera.Follow = player.transform;
    }
}
