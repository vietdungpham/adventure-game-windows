using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupGamePause : MonoBehaviour
{
    public void OnClickMenuButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PopupSystem.Instance.HideAllPopup();
        LoadSceneUtility.LoadScene(LoadSceneUtility.MenuScene);
    }

    public void OnClickResumeButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PopupSystem.Instance.HideAllPopup();
    }
}
