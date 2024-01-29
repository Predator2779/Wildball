using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private bool _isQuitTrigger;
    [SerializeField] private string _loadedScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) LoadSceneOrExit();
    }

    private void LoadSceneOrExit()
    {
        if (_isQuitTrigger) Application.Quit();

        SceneManager.LoadScene(_loadedScene);
    }
}