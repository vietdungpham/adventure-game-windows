using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterPrefabDataTable", menuName = "adventure-game-windows/CharacterPrefabDataTable", order = 0)]
public class CharacterPrefabDataTable : ScriptableObject
{
    public List<CharacterData> charactersData = new List<CharacterData>();

    protected static CharacterPrefabDataTable instance;

    public static CharacterPrefabDataTable Instance
    {
        get
        {
            if (instance == null)
                instance = Resources.LoadAll<CharacterPrefabDataTable>("")[0];
            return instance;
        }
    }

    public CharacterData GetDataByName(CharacterName characterName)
    {
        for (var i = 0; i < charactersData.Count; i++)
        {
            if (charactersData[i].characterName == characterName)
                return charactersData[i];
        }
        return null;
    }
}

[System.Serializable]
public class CharacterData
{
    public CharacterName characterName;

    public GameObject characterPrefab;

    public GameObject characterUIPrefab;

    public int priceToUnlock;
}

public enum CharacterName { NinjaFrog = 0, VitualGuy = 1, PinkMan = 2, MaskDude = 3 }
