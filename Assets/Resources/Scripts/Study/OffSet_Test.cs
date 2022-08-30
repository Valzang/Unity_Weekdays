using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSet_Test : MonoBehaviour
{
    private Renderer renderer_;
    public float offset = 0.0f;
    private Material mat;

    // Start is called before the first frame update
    private void Awake()
    {
        this.renderer_ = this.GetComponent<Renderer>();
    }
    void Start()
    {
        mat = this.renderer_.material;
        Texture baseTex = Resources.Load("Textures/Vol_7_1_Tiles_Base_Color") as Texture;
        mat.SetTexture("_Basemap", baseTex);
        mat.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * 0.1f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
    }
}
