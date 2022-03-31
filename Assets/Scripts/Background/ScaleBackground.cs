using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        float HeightCamera = Camera.main.orthographicSize * 2f;
        float WidthCamera = HeightCamera * Screen.width / Screen.height;
        transform.localScale = new Vector3(WidthCamera, HeightCamera, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
