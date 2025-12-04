using System.IO;
using UnityEngine;

public class ScreenshotMaker : MonoBehaviour
{
    public Camera cameraToUse;
    public RenderTexture renderTexture;

    void Start()
    {
        CaptureScreenshot();
    }

    void CaptureScreenshot()
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = renderTexture;
        
        cameraToUse.targetTexture = renderTexture;
        cameraToUse.Render();
        
        Texture2D image = new Texture2D(renderTexture.width, renderTexture.height);
        image.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        image.Apply();
        
        byte[] bytes = image.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Screenshot.png", bytes);
        
        RenderTexture.active = currentRT;
        cameraToUse.targetTexture = null;
        
        Debug.Log("Screenshot saved as Screenshot.png");
    }
}
