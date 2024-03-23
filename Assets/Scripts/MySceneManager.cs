using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public TMP_InputField actualNicknameField;

    public void StartNew()
    {
        if (actualNicknameField.text != null)
        {
            DataManager.Instance.actualName = actualNicknameField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
