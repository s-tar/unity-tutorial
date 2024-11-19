using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInputField;

    public void OnPlayerNameChanged()
    {
        GameManager.Instance.playerName = playerNameInputField.text;
    }
    public void StartGame()
    {
        if (GameManager.Instance.playerName.Length == 0)
        {
            return;
        }
        
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
