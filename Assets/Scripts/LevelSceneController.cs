using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSceneController : MonoBehaviour
{
    public int levelCounter;

    public Transform buttonField;

    public Transform characterField;

    public Button levelButtonPrefab;

    public Button previousButton;

    public Button nextButton;

    public Text nameText;

    public Button selectButton;

    public Text selectedText;

    public Button unlockButton;

    public Text currencyText;

    private CharacterName currentCharacter;

    private char[] unlockedCharacter;

    public void Start()
    {
        BackgroundSetup.Instance.Setup();
        InitLevelButton();
        levelButtonPrefab.gameObject.SetActive(false);

        currencyText.text = PlayerPrefs.GetInt(PlayerData.CurrencyFruits, 0).ToString();
        unlockedCharacter = PlayerPrefs.GetString(PlayerData.UnlockedCharacters, "1000").ToCharArray();
        currentCharacter = (CharacterName)PlayerPrefs.GetInt(PlayerData.SelectedCharacter, 0);
        InitCharacter(currentCharacter);

        previousButton.onClick.AddListener(() =>
        {
            currentCharacter--;
            InitCharacter(currentCharacter);
        });

        nextButton.onClick.AddListener(() =>
        {
            currentCharacter++;
            InitCharacter(currentCharacter);
        });              
    }

    public void InitLevelButton()
    {
        for (var i = 0; i < levelCounter; i++)
        {
            var index = i;
            var levelButton = Instantiate(levelButtonPrefab, buttonField);
            levelButton.GetComponentInChildren<Text>().text = (i + 1).ToString();
            if (i <= PlayerPrefs.GetInt(PlayerData.UnlockedLevels, 0))
            {
                levelButton.onClick.AddListener(() =>
                {
                    OnClickLevelButton(index);
                });
            }
            else
            {
                levelButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
            }

        }
    }

    public void OnClickSelectButton()
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PlayerPrefs.SetInt(PlayerData.SelectedCharacter, (int)currentCharacter);
        selectedText.gameObject.SetActive(true);
        selectButton.gameObject.SetActive(false);
    }

    public void OnClickUnlockCharacterButton()
    {
        var price = CharacterPrefabDataTable.Instance.GetDataByName(currentCharacter).priceToUnlock;
        var currentPrice = PlayerPrefs.GetInt(PlayerData.CurrencyFruits, 0);

        if (currentPrice - price >= 0)
        {
            AudioManager.Instance.PlaySFX(AudioClipId.UnlockCharacterEffect);
            unlockedCharacter[(int)currentCharacter] = '1';
            unlockButton.gameObject.SetActive(false);
            OnClickSelectButton();
            PlayerPrefs.SetString(PlayerData.UnlockedCharacters, new string(unlockedCharacter));
            PlayerPrefs.SetInt(PlayerData.CurrencyFruits, currentPrice - price);
            currencyText.text = PlayerPrefs.GetInt(PlayerData.CurrencyFruits, 0).ToString();
        }
    }

    public void OnClickLevelButton(int index)
    {
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        AudioManager.Instance.PlaySFX(AudioClipId.ButtonEffect);
        PlayerPrefs.SetInt(PlayerData.CurrentLevel, index);
        PlayerPrefs.SetInt(PlayerData.SelectedCharacter, PlayerPrefs.GetInt(PlayerData.SelectedCharacter, 0));
        LoadSceneUtility.LoadScene(LoadSceneUtility.GameScene);
    }

    private void InitCharacter(CharacterName character)
    {
        foreach (Transform item in characterField)
            Destroy(item.gameObject);

        var uiCharacter = Instantiate(CharacterPrefabDataTable.Instance.GetDataByName(character).characterUIPrefab, characterField);
        nameText.text = character.ToString();
        if ((int)character==0)
        {
            previousButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);         
        }
        else if ((int)character == 3)
        {
            previousButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }

        var status = unlockedCharacter[(int)character];
        switch(status)
        {
            case '0':
                selectButton.gameObject.SetActive(false);
                selectedText.gameObject.SetActive(false);
                unlockButton.gameObject.SetActive(true);
                unlockButton.GetComponentInChildren<Text>().text = CharacterPrefabDataTable.Instance.GetDataByName(character).priceToUnlock.ToString();
                break;
            case '1':
                unlockButton.gameObject.SetActive(false);
                if (PlayerPrefs.GetInt(PlayerData.SelectedCharacter, 0) == (int)character)
                {
                    selectedText.gameObject.SetActive(true);
                    selectButton.gameObject.SetActive(false);
                }
                else
                {
                    selectButton.gameObject.SetActive(true);
                    selectedText.gameObject.SetActive(false);
                }                    
                break;
        }
    }
}
