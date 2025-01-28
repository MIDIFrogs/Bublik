using UnityEngine;
using UnityEngine.SceneManagement;

// TODO
namespace MIDIFrogs.Bubble.Navigation
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private AudioSource au;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                winScreen.SetActive(true);
                au.Play();
                Time.timeScale = 0f;
            }
        }

        public void ToNewLvl()
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }
    }
}