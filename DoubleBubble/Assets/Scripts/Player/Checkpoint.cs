using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject spawnPlace;
    [SerializeField] private GameObject spawnF;
    [SerializeField] private Bubble player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spawnPlace.transform.position = spawnF.transform.position;
        }
    }
}
