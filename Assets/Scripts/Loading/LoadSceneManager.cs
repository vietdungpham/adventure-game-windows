using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadSceneUtility
{
    public static string LevelScene = "LevelScene";

    public static string MenuScene = "MenuScene";

    public static string GameScene = "GameScene";

    public static void LoadScene(string sceneName, Action PreLoadAction = null, Action PostloadAction = null)
    {
        BackgroundSetup.Instance.RandomChangeBackground();
        LoadSceneManager.Instance.LoadScene(sceneName, PreLoadAction, PostloadAction);
    }

    public static void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public static string CurrentSceneName { get { return LoadSceneManager.Instance.currentSceneName; } }
}

public class LoadSceneManager : MonoBehaviour
{
    private static LoadSceneManager instance;

    [NonSerialized]
    public string currentSceneName;

    public static LoadSceneManager Instance
    {
        get
        {
            return instance;
        }
    }

    public LoadingScreenController loadingScreenController;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        loadingScreenController.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName, Action PreloadAction = null, Action PostLoadAction = null)
    {
        currentSceneName = sceneName;
        loadingScreenController.StartAnimating(sceneName, PreloadAction, PostLoadAction);
    }
}
