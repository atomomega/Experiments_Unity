using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTest : MonoBehaviour {

    public float frequency = 20;
    [Range(0, 1)]
    public float amplidude = 0.7f;
    [Range(1, 8)]
    public int octaves = 8;
    public Vector2 offset = new Vector2(0, 0);

    Texture2D perlin;

    void Start()
    {
        perlin = Utility.PerlinNoise(256, 256, 20f, offset, frequency, amplidude, octaves);
    }

    void FixedUpdate()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = perlin;
    }

}
