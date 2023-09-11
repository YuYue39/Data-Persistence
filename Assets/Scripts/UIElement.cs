using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public TMP_Text PlayerName;
    public TMP_Text BestScore;

    private void Awake()
    {
        InfoExchange.Instance.LoadScore();
        BestScore.SetText("Best Score : " + InfoExchange.Instance.PlayerName + " : " + InfoExchange.Instance.Score);
    }

    public void StartGame()
    {
        InfoExchange.Instance.PlayerName = PlayerName.text;
        SceneManager.LoadScene(1);
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
