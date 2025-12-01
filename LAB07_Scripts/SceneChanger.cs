using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public PlayerManager playerManager;

    public void LoadScene(string sceneName)
    {
        playerManager.IncreaseScore(10);
        SceneManager.LoadScene(sceneName);
    }
}
