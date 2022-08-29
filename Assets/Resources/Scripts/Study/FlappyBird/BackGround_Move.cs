using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Move : MonoBehaviour
{

    private Renderer renderer;
    public float offset = 0.0f;
    private Material mat;

    // Start is called before the first frame update
    private void Awake()
    {
        this.renderer = this.GetComponent<Renderer>();
    }
    void Start()
    {
        mat = this.renderer.material;        
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * 0.1f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
    }
}
