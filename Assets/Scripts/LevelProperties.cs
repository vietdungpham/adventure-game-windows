using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProperties : MonoBehaviour
{
    public int index;

    public int pointToPass;

    public Transform spawnPoint;

    public GameObject tileMap;

    public void Init()
    {
        tileMap.SetActive(true);
    }
}
