using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] character;

    private int characterIndex;
    public void PlayGame()
    {
        Application.LoadLevel("LevelMenu");
    }
    public void BackToMenu()
    {
        Application.LoadLevel("Menu");
    }
    public void PlayLevel()
    {
        Application.LoadLevel(EventSystem.current.currentSelectedGameObject.name);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }
    public void ChangeCharacter(int index)
    {
        for(int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }
        character[index].SetActive(true);
        this.characterIndex = index;
    }
}
