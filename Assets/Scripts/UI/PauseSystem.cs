using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
