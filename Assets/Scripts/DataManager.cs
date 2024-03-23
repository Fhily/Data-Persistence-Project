using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string bestNickname;
    public int bestOverallScore;
    public string actualName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveDataClass
    {
        public string bestNickname;
        public int bestOverallScore;
        public string actualName;
    }

    public void SaveData()
    {
        SaveDataClass data = new SaveDataClass();
        data.bestNickname = bestNickname;
        data.bestOverallScore = bestOverallScore;
        data.actualName = actualName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataClass data = JsonUtility.FromJson<SaveDataClass>(json);

            bestNickname = data.bestNickname;
            bestOverallScore = data.bestOverallScore;
            actualName = data.actualName;
        }
    }
}
