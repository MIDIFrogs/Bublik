using Unity.VisualScripting;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnPlace;
    [SerializeField] private GameObject spawnF;
    [SerializeField] private Ball player;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //spawnF.SetActive(false);
            //spawnPlace.SetActive(true);
            spawnPlace.transform.position = spawnF.transform.position;
        }
    }
}
