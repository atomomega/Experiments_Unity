using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

    static Color CalcColor(int x, int y, int width, int height)
    {
        float xCoord = (float)x / width, yCoord = (float)y / height;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    public static Texture2D PerlinNoise(int width, int height)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y, width, height);
                tex.SetPixel(x, y, color);
            }
        }

        tex.Apply();
        return tex;
    }

    static Color CalcColor(int x, int y, int width, int height, Vector2 offset)
    {
        float xCoord = (float)x / width + offset.x, yCoord = (float)y / height + offset.y;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    public static Texture2D PerlinNoise(int width, int height, Vector2 offset)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y, width, height, offset);
                tex.SetPixel(x, y, color);
            }
        }

        tex.Apply();
        return tex;
    }

    static Color CalcColor(int x, int y, int width, int height, float scale)
    {
        float xCoord = (float)x / width * scale, yCoord = (float)y / height * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    public static Texture2D PerlinNoise(int width, int height, float scale)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y, width, height, scale);
                tex.SetPixel(x, y, color);
            }
        }

        tex.Apply();
        return tex;
    }

    static Color CalcColor(int x, int y, int width, int height, float scale, Vector2 offset)
    {
        float xCoord = (float)x / width * scale + offset.x, yCoord = (float)y / height * scale + offset.y;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    public static Texture2D PerlinNoise(int width, int height, float scale, Vector2 offset)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y, width, height, scale, offset);
                tex.SetPixel(x, y, color);
            }
        }

        tex.Apply();
        return tex;
    }

    static Color CalcColor(int x, int y, int width, int height, float scale, float frequency, float amplitude, int octaves)
    {
        float xCoord = 0f, yCoord = 0f, sample = 0f, gain = 1f;

        yCoord = (float)y / height * scale;
        xCoord = (float)x / width * scale;

        for (int i = 0; i < octaves; i++)
        {
            sample += Mathf.PerlinNoise(xCoord * gain / frequency, yCoord * gain / frequency) * amplitude / gain;
            gain *= 2.0f;
        }

        return new Color(sample, sample, sample);
    }

    public static Texture2D PerlinNoise(int width, int height, float scale, float freqency, float amplitude, int octaves)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y, width, height, scale, freqency, amplitude, octaves);
                tex.SetPixel(x, y, color);
            }
        }

        tex.Apply();
        return tex;
    }

    static Color CalcColor(int x, int y, int width, int height, float scale, Vector2 offset, float frequency, float amplitude, int octaves)
    {
        float xCoord = 0f, yCoord = 0f, sample = 0f, gain = 1f;

        yCoord = (float)y / height * scale + offset.x;
        xCoord = (float)x / width * scale + offset.y;

        for (int i = 0; i < octaves; i++)
        {
            sample += Mathf.PerlinNoise(xCoord * gain / frequency, yCoord * gain / frequency) * amplitude / gain;
            gain *= 2.0f;
        }

        return new Color(sample, sample, sample);
    }

    public static Texture2D PerlinNoise(int width, int height, float scale, Vector2 offset, float freqency, float amplitude, int octaves)
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y, width, height, scale, offset, freqency, amplitude, octaves);
                tex.SetPixel(x, y, color);
            }
        }

        tex.Apply();
        return tex;
    }

    public static bool TraceRay(Vector3 origin, Vector3 direction)
    {
        RaycastHit raycast;

        return Physics.Raycast(origin, direction, out raycast);
    }

    public static bool TraceRay(Vector3 origin, Vector3 direction, float maxDistance)
    {
        RaycastHit raycast;

        return Physics.Raycast(origin, direction, out raycast, maxDistance);
    }

    public static bool TraceRay(Vector3 origin, Vector3 direction, float maxDistance, LayerMask layerMask)
    {
        RaycastHit raycast;

        return Physics.Raycast(origin, direction, out raycast, maxDistance, layerMask);
    }

    public static bool TraceRay(Vector3 origin, Vector3 direction, float maxDistance, LayerMask layerMask, QueryTriggerInteraction triggerInteraction)
    {
        RaycastHit raycast;

        return Physics.Raycast(origin, direction, out raycast, maxDistance, layerMask, triggerInteraction);
    }

    public static int RandomInt(int minimum, int maximum)
    {
        return Random.Range(minimum, maximum);
    }

    public static int RandomInt()
    {
        return Random.Range(0, int.MaxValue);
    }

    public static float RandomFloat(float minimum, float maximum)
    {
        return Random.Range(minimum, maximum);
    }

    public static string RandomSeed(int length)
    {
        int[] seedValues = new int[length];
        string seed = null;
        for(int i = 0; i < length; i++)
        {
            seedValues[i] = RandomInt(0, 9);
            seed += seedValues[i].ToString();
        }

        return seed;
    }

    public static string RandomSeed()
    {
        int[] seedValues = new int[8];
        string seed = null;
        for (int i = 0; i < seedValues.Length; i++)
        {
            seedValues[i] = RandomInt(0, 9);
            seed += seedValues[i].ToString();
        }

        return seed;
    }

}
