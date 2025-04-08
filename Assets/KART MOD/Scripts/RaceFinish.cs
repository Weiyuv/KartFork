using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceFinish : MonoBehaviour
{
    public string winSceneName = "WinScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ou "Kart"
        {
            Debug.Log("Corrida vencida!");
            LoadWinScene();
        }
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene(winSceneName);
    }
}
