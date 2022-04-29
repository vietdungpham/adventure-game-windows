using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopupSettings : MonoBehaviour
{
    public Text musicStatusText;

    public Text sfxStatusText;

    private bool musicEnabled;

    private bool sfxEnabled;

    public void OnEnable()
    {
        musicEnabled = PlayerPrefs.GetInt("music_enabled", 1) == 1 ? true : false;
        if (musicEnabled)
            musicStatusText.text = "Music Off";
        else
            musicStatusText.text = "Music On";

        sfxEnabled = PlayerPrefs.GetInt("sfx_enabled", 1) == 1 ? true : false;
        if (sfxEnabled)
            sfxStatusText.text = "SFX Off";
        else
            sfxStatusText.text = "SFX On";
    }

    public void OnClickSoundButton()
    {
        musicEnabled = !musicEnabled;

        if (musicEnabled)
        {
            musicStatusText.text = "Music Off";
        }
        else
        {
            musicStatusText.text = "Music On";
        }

        PlayerPrefs.SetInt("music_enabled", musicEnabled == true ? 1 : 0);
        AudioSettingInterface.SetMusicEnabled(musicEnabled);
    }

    public void OnClickSFXButton()
    {
        sfxEnabled = !sfxEnabled;

        if (sfxEnabled)
        {
            sfxStatusText.text = "SFX Off";
        }
        else
        {
            sfxStatusText.text = "SFX On";
        }

        PlayerPrefs.SetInt("sfx_enabled", sfxEnabled == true ? 1 : 0);
        AudioSettingInterface.SetSFXEnabled(sfxEnabled);
    }
}
