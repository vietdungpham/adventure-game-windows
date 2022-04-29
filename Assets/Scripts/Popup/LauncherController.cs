using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LauncherController : MonoBehaviour
{
    public CanvasGroup nameText;

    public GameObject buttonControlsContainer;

    public CanvasGroup[] buttonControls;

    [Header("Open Animation")]
    public AnimationCurve scaleUpCurve;

    public float scaleUpDuration = 0.5f;

    public float fadeInDuration = 0.5f;

    public float openDelayInterval = 0.1f;

    private bool canClick;

    // Start is called before the first frame update
    void Start()
    {
        FadeInNameText();
        AudioManager.Instance.PlayMusic(AudioClipId.BackgroundMusic,true);
    }

    public void FadeInNameText()
    {
        nameText.alpha = 0f;
        buttonControlsContainer.SetActive(false);
        nameText.DOFade(1f, 0.9f).OnComplete(() =>
        {
            buttonControlsContainer.SetActive(true);
            ScaleUpCurve();
        });
    }

    public void ScaleUpCurve()
    {
        for (int i = 0; i < buttonControls.Length; i++)
        {
            var transform = buttonControls[i].transform;
            var canvasGroup = transform.GetComponent<CanvasGroup>();
            float delay = (i != 4) ? i * openDelayInterval : (i - 1) * openDelayInterval;

            float scale = transform.localScale.x;
            transform.localScale = Vector3.zero;
            var tween = transform.DOScale(scale, scaleUpDuration).SetDelay(delay).SetEase(scaleUpCurve);

            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1f, fadeInDuration).SetDelay(delay).SetEase(Ease.Linear);

            if (i == buttonControls.Length - 1)
            {
                tween.OnComplete(() => canClick = true);
            }
        }
    }

    public void OnClickPlay()
    {
        if (canClick)
        {
            AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
            LoadSceneUtility.LoadScene(LoadSceneUtility.LevelScene);
        }            
    }

    public void OnClickSetting()
    {
        if (canClick)
        {
            AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
            PopupSystem.Instance.ShowPopupSettings();
        }            
    }

    public void OnClickAbout()
    {
        if (canClick)
        {
            AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
            PopupSystem.Instance.ShowPopupAbout();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Hack 1000 Fruits")]
    public void HackFruits()
    {
        PlayerPrefs.SetInt(PlayerData.CurrencyFruits, 1000);
    }
#endif
}
