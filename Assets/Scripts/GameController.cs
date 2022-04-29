using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public List<LevelProperties> levelsProperties = new List<LevelProperties>();

    private LevelProperties currentLevelProperties;

    private Player currentPlayer;

    private int currentPoint;

    private void Start()
    {
        Instance = this;
        BackgroundSetup.Instance.Setup();
        Init();
    }

    [ContextMenu("Init")]
    public void Init()
    {
        int currentLevel = PlayerPrefs.GetInt(PlayerData.CurrentLevel, 0);
        int selectedCharacter = PlayerPrefs.GetInt(PlayerData.SelectedCharacter, 0);
        currentLevelProperties = GetLevelPropertiesWithIndex(currentLevel);
        currentLevelProperties.gameObject.SetActive(true);
        currentLevelProperties.Init();
        var character =
            Instantiate(CharacterPrefabDataTable.Instance.GetDataByName((CharacterName)selectedCharacter).characterPrefab,
            currentLevelProperties.spawnPoint.position, Quaternion.identity);

        currentPlayer = character.GetComponent<Player>();
        currentPlayer.DeathEvent += OnDeathEvent;
        currentPlayer.GetItemEvent += OnGetItemEvent;

        currentPoint = 0;
    }

    private LevelProperties GetLevelPropertiesWithIndex(int index)
    {
        for (int i = 0; i < levelsProperties.Count; i++)
        {
            if (levelsProperties[i].index == index)
                return levelsProperties[i];
        }
        return null;
    }

    #region Callback
    public void OnGetItemEvent()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.items, 0.2f);
        currentPoint++;
        if (currentPoint == currentLevelProperties.pointToPass) //setup completed current level => re-load scene
            PopupSystem.Instance.ShowPopupGameWin(currentPoint);
    }

    public void OnDeathEvent()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.gameOver, 1f);
        PopupSystem.Instance.ShowPopupGameFail();
    }
    #endregion
}
