using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopupGameWin : MonoBehaviour
{
    public Text scoreText;

    public void OnEnable()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.GameWinEffect);
    }

    public void Init(int point)
    {
        scoreText.text = "Score: " + point;
    }

    public void OnClickMenuButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PopupSystem.Instance.HideAllPopup();
        LoadSceneUtility.LoadScene(LoadSceneUtility.MenuScene);
    }

    public void OnClickContinueButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PopupSystem.Instance.HideAllPopup();
        var currentUnlockedLevel = PlayerPrefs.GetInt(PlayerData.UnlockedLevels, 0);
        var nextUnlockedLevel = PlayerPrefs.GetInt(PlayerData.CurrentLevel, 0) + 1;
        if(currentUnlockedLevel<nextUnlockedLevel)
            PlayerPrefs.SetInt(PlayerData.UnlockedLevels, nextUnlockedLevel);
        LoadSceneUtility.LoadScene(LoadSceneUtility.LevelScene);
    }
}
