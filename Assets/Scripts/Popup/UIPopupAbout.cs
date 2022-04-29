using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupAbout : MonoBehaviour
{
    public System.Action OpenPopupEvent;

    // Start is called before the first frame update
    void Start()
    {
        OpenPopupEvent?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
