using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InfoExchange : MonoBehaviour
{
    public static InfoExchange Instance;

    public string PlayerName;
    public int Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class DataSave
    {
        public string PlayerName;
        public int Score;
    }

    public void SaveScore()
    {
        DataSave data = new DataSave();

        data.PlayerName = PlayerName;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscores.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataSave data = JsonUtility.FromJson<DataSave>(json);

            PlayerName = data.PlayerName;
            Score = data.Score;
        }
    }
}
