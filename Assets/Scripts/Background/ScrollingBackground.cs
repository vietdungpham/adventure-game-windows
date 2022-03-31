using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 0.2f;   //tốc độ scrolling
    private Material mat;    // khởi tạo một biến Material
    private Vector2 offset = Vector2.zero;   //khai báo 1 độ dời cho background

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;   //khởi tạo material
        offset = mat.GetTextureOffset("__MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speed * Time.deltaTime;   // cho background di chuyển từ trên xuống nê ta lấy trục y (nếu muốn di chuyển sang ngang thì ta lấy trục x)
        mat.SetTextureOffset("_MainTex", offset);
    }
}
