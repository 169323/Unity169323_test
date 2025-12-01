using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Win/Lose Panel (Optional)")]
    [SerializeField] private GameObject winLosePanel;

    // --- MAIN MENU ---
    public void SettingsPanelActivate()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        if (winLosePanel) winLosePanel.SetActive(false);
    }

    public void OpenCreditsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        if (winLosePanel) winLosePanel.SetActive(false);
    }

    public void BackToMain()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        if (winLosePanel) winLosePanel.SetActive(false);
    }

    // --- EXIT ---
    public void QuitApplication()
    {
        Application.Quit();

        // zamyka gre w edytorze (do testow bez build'a)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // --- NAVIGATION SCENE ---
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // --- LEVEL FLOW ---
    public void LoadNextLevel(string currentLevel)
    {
        switch (currentLevel)
        {
            case "Level1": SceneManager.LoadScene("Level2"); break;
            case "Level2": SceneManager.LoadScene("Level3"); break;
            case "Level3": SceneManager.LoadScene("Level4"); break;
            case "Level4": SceneManager.LoadScene("WinLoseScreen"); break;
            default: Debug.LogWarning("Nieznany poziom: " + currentLevel); break;
        }
    }

    // --- WIN/LOSE SCREEN ---
    public void WinLoseBackToMenu()
    {
        if (winLosePanel) winLosePanel.SetActive(false);
        BackToMain();
    }
}

