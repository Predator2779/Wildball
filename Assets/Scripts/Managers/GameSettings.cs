using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private GameModes _currentMode;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingsPanel;
        public GameModes CurrentMode => _currentMode;
        private void Update() => EscapeButton();
        public void LoadScene(string nameScene) => SceneManager.LoadScene(nameScene);
        private void CursorVisible(bool visible) => Cursor.visible = visible;
        public void Continue() => SetPlayMode();
        public void ExitApp() => Application.Quit();
        
        public void ToMenu()
        {
            Time.timeScale = 1;
            LoadScene("[6]_NewMenu");
        }
        private void SetPlayMode()
        {
            _currentMode = GameModes.Playing;
            _pausePanel.SetActive(false);
            _settingsPanel.SetActive(false);
            CursorVisible(false);

            Time.timeScale = 1;
        }

        private void SetPauseMode()
        {
            Time.timeScale = 0;
            
            _currentMode = GameModes.Paused;
            _pausePanel.SetActive(true);
            CursorVisible(true);
        }

        private void EscapeButton()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;

            if (_currentMode == GameModes.Paused) SetPlayMode();
            else SetPauseMode();
        }
        
        public enum GameModes
        {
            Playing,
            Paused
        }
    }
}