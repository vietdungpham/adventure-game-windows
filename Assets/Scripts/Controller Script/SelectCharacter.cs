using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] characterPrefabs;
    void Start()
    {
        LoadCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadCharacter()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        GameObject.Instantiate(characterPrefabs[characterIndex]);
    }
}
