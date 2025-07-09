using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class MenuUIHandler : MonoBehaviour
{
    //private InputField playerNameInput;
    private TMP_InputField playerNameInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerNameInput = GameObject.Find("PlayerNameInput").GetComponent<TMP_InputField>();
    }

    public void StartGame()
    {
        string playerName = playerNameInput.text.Length == 0
            ? "Player"
            : playerNameInput.text;
        Debug.Log("Setting Player Name: " + playerName);
        PlayerDataManager.Instance.SetPlayerName(playerName);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Player Name: " + playerNameInput.text);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
