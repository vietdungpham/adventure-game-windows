using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupGameFail : MonoBehaviour
{
    public void OnClickMenuButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PopupSystem.Instance.HideAllPopup();
        LoadSceneUtility.LoadScene(LoadSceneUtility.MenuScene);
    }

    public void OnClickRetryButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);        
        LoadSceneUtility.ReloadCurrentScene();
        PopupSystem.Instance.HideAllPopup();
    }
}
