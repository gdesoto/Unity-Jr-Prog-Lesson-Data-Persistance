using UnityEngine;
using System.IO;
public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public string currentPlayer = "None";
    public string bestPlayer = "None";
    public int bestScore = 0;

    // Start: Persist data between scenes
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreData();
    }

    private void Start()
    {
    }

    public void SetPlayerName(string _playerName)
    {
        currentPlayer = _playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveScoreData(int newScore)
    {
        // Is it a new high Score?
        if (newScore <= bestScore)
        {
            return;
        }
        bestPlayer = currentPlayer;
        bestScore = newScore;
        // Create SaveData class
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

        // Convert SaveData to string
        string json = JsonUtility.ToJson(data);

        // Save to folder for data that will survive between application reinstall or update.
        File.WriteAllText(Application.persistentDataPath + "/brickout_player.json", json);
    }

    public void LoadScoreData()
    {

        string path = Application.persistentDataPath + "/brickout_player.json";

        // Check if file exists
        if (!File.Exists(path))
        {
            return;
        }

        // Get file contents
        string json = File.ReadAllText(path);

        // Convert content to SaveData class
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // Update properties from SaveData values.
        bestPlayer = data.bestPlayer;
        bestScore = data.bestScore;

    }
}
