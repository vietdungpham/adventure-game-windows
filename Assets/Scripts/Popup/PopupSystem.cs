using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class PopupSystem : MonoSingleton<PopupSystem>
{
    public GameObject blockPanel;

    [SerializeField]
    private UIPopupSettings popupSettings;

    [SerializeField]
    private UIPopupAbout popupAbout;

    [SerializeField]
    private UIPopupGameWin popupGameWin;

    [SerializeField]
    private UIPopupGameFail popupGameFail;

    [SerializeField]
    private UIPopupGamePause popupGamePause;

    private void Start()
    {
        EventTrigger trigger = blockPanel.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        HideAllPopup();
    }

    public void HideAllPopup()
    {
        blockPanel.gameObject.SetActive(false);
        popupSettings.gameObject.SetActive(false);
        popupAbout.gameObject.SetActive(false);
        popupGameWin.gameObject.SetActive(false);
        popupGameFail.gameObject.SetActive(false);
        popupGamePause.gameObject.SetActive(false);
    }

    public void ShowPopupSettings()
    {
        HideAllPopup();
        blockPanel.gameObject.SetActive(true);
        var canvasGroup = popupSettings.GetComponent<CanvasGroup>();
        popupSettings.gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1f, 0.4f).SetEase(Ease.Linear);
    }

    public void ShowPopupAbout()
    {
        HideAllPopup();
        blockPanel.gameObject.SetActive(true);
        var canvasGroup = popupAbout.GetComponent<CanvasGroup>();
        popupAbout.gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1f, 0.4f).SetEase(Ease.Linear);
    }

    internal void ShowPopupGameFail()
    {
        HideAllPopup();
        blockPanel.gameObject.SetActive(true);
        var canvasGroup = popupGameFail.GetComponent<CanvasGroup>();
        popupGameFail.gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1f, 0.4f).SetEase(Ease.Linear);
    }

    public void ShowPopupGameWin(int point)
    {
        HideAllPopup();
        PlayerPrefs.SetInt(PlayerData.CurrencyFruits, PlayerPrefs.GetInt(PlayerData.CurrencyFruits, 0) + point);
        blockPanel.gameObject.SetActive(true);
        var canvasGroup = popupGameWin.GetComponent<CanvasGroup>();
        popupGameWin.gameObject.SetActive(true);
        popupGameWin.Init(point);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1f, 0.4f).SetEase(Ease.Linear);
    }
}
