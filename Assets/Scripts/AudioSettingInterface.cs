using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSettingInterface
{
    public static void SetMusicEnabled(bool flag)
    {
        AudioManager.Instance.SetMusicEnable(flag);
    }

    public static void SetSFXEnabled(bool flag)
    {
        AudioManager.Instance.SetEffectEnable(flag);
    }
}