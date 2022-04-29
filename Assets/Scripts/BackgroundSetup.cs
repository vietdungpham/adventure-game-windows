using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSetup : MonoSingleton<BackgroundSetup>
{
    public Texture[] listBackground;
    public float speedScroll = 0.2f;   //tốc độ scrolling
    private Material material;    // khởi tạo một biến Material
    private Vector2 offset = Vector2.zero;   //khai báo 1 độ dời cho background

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        material = GetComponent<Renderer>().material;   //khởi tạo material
        offset = material.GetTextureOffset("_MainTex");
        RandomChangeBackground();
    }

    public void Setup()
    {
        float HeightCamera = Camera.main.orthographicSize * 2f;
        float WidthCamera = HeightCamera * Screen.width / Screen.height;
        transform.localScale = new Vector3(WidthCamera, HeightCamera, 0f);
    }

    [ContextMenu("Re-Setup Background")]
    public void RandomChangeBackground()
    {
        material.mainTexture = listBackground[Random.RandomRange(0, listBackground.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speedScroll * Time.deltaTime;   // cho background di chuyển từ trên xuống nê ta lấy trục y (nếu muốn di chuyển sang ngang thì ta lấy trục x)
        material.SetTextureOffset("_MainTex", offset);
    }
}
