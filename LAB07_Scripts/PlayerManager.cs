using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData; // Przypisz `PlayerDataInstance` przez Inspektor w Unity

    private void Start()
    {
        // £adowanie danych na starcie
        playerData.LoadData();
        Debug.Log("Player Name: " + playerData.Name);
        Debug.Log("Player Score: " + playerData.Score);
        Debug.Log("Player Health: " + playerData.Health);
    }

    private void OnApplicationQuit()
    {
        // Zapisz dane przy zamykaniu aplikacji
        playerData.SaveData();
    }

    private void OnDestroy()
    {
        // Zapisz dane przy niszczeniu obiektu (np. zmiana sceny)
        playerData.SaveData();
    }

    // Przyk³adowa funkcja modyfikuj¹ca dane
    public void IncreaseScore(int amount)
    {
        playerData.Score += amount;
        Debug.Log("Nowy wynik gracza: " + playerData.Score);
    }
}