using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private string playerName = "DefaultName"; // Pole prywatne dla imienia

    [SerializeField, Range(0, 100)]
    private int playerHealth = 100; // Pole prywatne dla zdrowia z zakresem [0, 100]

    [SerializeField, Min(0)]
    private int playerScore = 0;

    // Publiczna w³aœciwoœæ do odczytu i zapisu nazwy
    public string Name
    {
        get => playerName;
        set => playerName = value;
    }

    // Publiczna w³aœciwoœæ do odczytu i zapisu zdrowia z walidacj¹
    public int Health
    {
        get => playerHealth;
        set => playerHealth = Mathf.Clamp(value, 0, 100); // Gwarantuje zakres [0, 100]
    }

    public int Score
    {
        get => playerScore;
        set => playerScore = Mathf.Max(0, value); // nigdy < 0
    }

    // Klucz do przechowywania danych w PlayerPrefs w formacie JSON
    private const string PlayerDataKey = "PlayerData_JSON";

    // Funkcja do za³adowania danych z PlayerPrefs jako JSON
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(PlayerDataKey))
        {
            string jsonData = PlayerPrefs.GetString(PlayerDataKey);
            JsonUtility.FromJsonOverwrite(jsonData, this);
            Debug.Log("PlayerData wczytane: " + jsonData);
        }
        else
        {
            // Ustaw domyœlne wartoœci, jeœli dane nie istniej¹
            playerName = "DefaultName";
            playerScore = 0;
            playerHealth = 100;
        }
    }

    // Funkcja do zapisania danych do PlayerPrefs jako JSON
    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerDataKey, jsonData);
        PlayerPrefs.Save(); // Zapisz wszystkie zmiany w PlayerPrefs
        Debug.Log("PlayerData zapisane: " + jsonData);
    }
}