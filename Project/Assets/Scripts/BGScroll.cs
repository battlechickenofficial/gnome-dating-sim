using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed;

    public MeshRenderer r;

    private void Update() {
        float offset = scrollSpeed * Time.time;
        r.materials[0].SetTextureOffset("_MainTex", new Vector2(offset, -offset));
    }
}
