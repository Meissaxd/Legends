using UnityEngine;
using System.IO;

public class TilemapCapture : MonoBehaviour
{
    public Camera captureCamera;
    public int resolutionWidth = 1024;
    public int resolutionHeight = 1024;

    [ContextMenu("Capture Tilemap")]
    public void CaptureTilemap()
    {
        RenderTexture rt = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        captureCamera.targetTexture = rt;

        Texture2D screenshot = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
        captureCamera.Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        byte[] bytes = screenshot.EncodeToPNG();
        string path = Application.dataPath + "/TilemapTexture.png";
        File.WriteAllBytes(path, bytes);
        Debug.Log("Saved screenshot to: " + path);
    }
}