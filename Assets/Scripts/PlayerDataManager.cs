using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public string playerName = "None";
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
    }

    private void Start()
    {
        LoadScoreData();
    }

    public void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveScoreData()
    {

    }

    public void LoadScoreData()
    {

    }
}
