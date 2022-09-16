using UnityEngine;

namespace UI
{
    public class PauseSystem : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject pauseButton;

        public void Pause()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }

        public void Play()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}
