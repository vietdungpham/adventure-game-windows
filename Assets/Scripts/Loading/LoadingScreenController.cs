using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public GameObject Loading;

    public Slider loadingBar;
    private float hotFixtimer;
    private int hotFixResCount;
    private int hotFixResTotal = 7;
    private int _resCount;
    private int _resTotal = 51;

    [Header("Close")]
    public AnimationCurve dropCurve;

    public float dropDuration;

    [Header("Open")]
    public AnimationCurve liftCurve;

    public float liftDuration;

    [Header("References")]
    public Image bgImage;

    public RectTransform barRectTransform;

    public Text loadingText;

    [Header("GC")]
    public bool triggerGarbageCollector = true;

    private bool animationComplete;

    private int showCount;

    private Vector2 sourcePos;

    private Vector2 targetPos;

    private float canvasWidth;

    public void Awake()
    {
        var canvasScaler = GetComponent<CanvasScaler>();

        Vector2 canvasSize = UIUtility.GetCanvasSize(canvasScaler);
        canvasWidth = canvasSize.x;
        sourcePos = barRectTransform.anchoredPosition;
        targetPos = new Vector2(-sourcePos.x * 2f + canvasSize.x, sourcePos.y);
        loadingBar.value = 0.01f;
    }
    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }
    private void Update()
    {
        StartAsyncLoad();
        UpdateSlider();
    }
    public void UpdateSlider()
    {
        if (hotFixResCount >= hotFixResTotal)
        {
            return;
        }

        if (loadingBar != null)
        {
            hotFixtimer += Time.deltaTime;
            if (loadingBar.value >= (float)hotFixResCount * 1f / (float)hotFixResTotal)
            {
                hotFixtimer = 0f;
            }
            loadingBar.value = Mathf.Lerp(loadingBar.value, (float)hotFixResCount * 1f / (float)hotFixResTotal + 0.1f, hotFixtimer / 5f);
        }
    }
    public void StartAsyncLoad()
    {
        if (hotFixResCount >= hotFixResTotal)
        {

            loadingBar.value = 0.01f;

        }
    }
    public void StartAnimating(string sceneName, Action PreLoadAction, Action PostLoadAction)
    {
        gameObject.SetActive(true);

        StartCoroutine(LoadingCoroutine(sceneName, PreLoadAction, PostLoadAction));
    }

    public IEnumerator LoadingCoroutine(string sceneName, Action PreloadAction, Action PostLoadAction)
    {
        bgImage.gameObject.SetActive(true);
        StartCoroutine(LoadingText());
        loadingBar.value = 0.01f;
        //loadingBar.gameObject.SetActive(true);
        StartCoroutine(AsyncLoad());
        Loading.SetActive(true);
        yield return new WaitForSeconds(dropDuration - 0.25f);

        yield return new WaitForSeconds(0.25f);

        PreloadAction?.Invoke();

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        if (triggerGarbageCollector)
        {
            GC.Collect();

#if UNITY_EDITOR
            Debug.LogFormat("Memory used after full collection:   {0:N0}", GC.GetTotalMemory(true));
#endif
        }
        bgImage.gameObject.SetActive(false);
        Loading.SetActive(false);

        yield return new WaitForSeconds(0.4f);

        PostLoadAction?.Invoke();

        yield return new WaitForSeconds(liftDuration);

        gameObject.SetActive(false);
    }

    private IEnumerator LoadingText()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        loadingText.text = loadingText.text + ".";
        if (loadingText.text.Equals("Loading...."))
            loadingText.text = "Loading";

        StartCoroutine(LoadingText());
    }

    private IEnumerator AsyncLoad()
    {
        loadingBar.value += 1f / (float)_resTotal;
        _resCount++;
        yield return null;
        loadingBar.value += 1f / (float)_resTotal;
        _resCount++;
        yield return null;
        for (int i = 0; i < _resTotal; i++)
        {
            loadingBar.value += 1f / (float)_resTotal;
            _resCount++;
            yield return null;
        }

        //loadingBar.gameObject.SetActive(false);

        yield return null;
    }


}
