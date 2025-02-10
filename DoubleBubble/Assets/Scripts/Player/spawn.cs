using Cinemachine;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Bubble prefab;
    [SerializeField] private GameObject spawn;
    [SerializeField] private bool spawnOnAwake = false;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if (spawnOnAwake) SpawnPrefab();
    }

    public void SpawnPrefab()
    {
        Bubble player = Instantiate(prefab, spawn.transform.position, spawn.transform.rotation);
        if (virtualCamera != null)
            virtualCamera.Follow = player.transform;
    }
}
