using UnityEngine;

namespace MIDIFrogs.Bubble.UI
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private bool stopOnAwake = false;
        [SerializeField] private bool acceptsEscape = true;
        [SerializeField] private GameObject pauseMenu;

        private bool isGamePaused;

        public bool IsPaused
        {
            get => isGamePaused;
            set
            {
                isGamePaused = value;
                Time.timeScale = value ? 0 : 1;
            }
        }


        private void Awake()
        {
            if (stopOnAwake) Pause();
        }

        private void Update()
        {
            if (acceptsEscape && Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        public void Pause()
        {
            if (pauseMenu != null)
                pauseMenu.SetActive(true);
            IsPaused = true;
        }

        public void Resume()
        {
            if (pauseMenu != null)
                pauseMenu.SetActive(true);
            IsPaused = false;
        }
    }
}