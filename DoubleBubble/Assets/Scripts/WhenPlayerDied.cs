using Cinemachine;
using UnityEngine;

public class WhenPlayerDied : MonoBehaviour
{
    [SerializeField] private Ball prefab;
    [SerializeField] private GameObject spawn; 
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        SpawnPrefab();
    }
    public void SpawnPrefab()
    {
        Ball player = Instantiate(prefab, spawn.transform);
        player.WhenPlayerDied = this;
        virtualCamera.Follow = player.transform;

    }
}
