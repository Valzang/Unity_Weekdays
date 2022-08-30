using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Move : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * 0.1f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
    }
}
