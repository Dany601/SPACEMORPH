using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ScreenshotManager : MonoBehaviour
{
    [SerializeField] private Camera screenshotCamera;
    [SerializeField] private Button saveButton;
    [SerializeField] private Text feedbackText;

    // Añadir una referencia al Canvas que contiene los botones
    [SerializeField] private Canvas uiCanvas;

    void Start()
    {
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(CaptureScreenshot);
        }
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
    }

    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshot());
    }

    private System.Collections.IEnumerator TakeScreenshot()
    {
        // Esperar al final del frame
        yield return new WaitForEndOfFrame();

        // Guardar el estado actual del Canvas
        bool wasCanvasActive = false;
        if (uiCanvas != null)
        {
            wasCanvasActive = uiCanvas.gameObject.activeSelf;
            uiCanvas.gameObject.SetActive(false);
        }

        // Crear directorio en el escritorio
        string directoryPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "ApartamentoScreenshots"
        );
        Directory.CreateDirectory(directoryPath);

        string fileName = $"Apartamento_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        string fullPath = Path.Combine(directoryPath, fileName);

        // Tomar el screenshot usando la cámara específica
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        screenshotCamera.targetTexture = rt;
        screenshotCamera.Render();

        RenderTexture.active = rt;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Restaurar la cámara
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        // Guardar imagen
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(fullPath, bytes);
        Destroy(screenshot);

        // Restaurar el estado del Canvas
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(wasCanvasActive);
        }

        Debug.Log($"Screenshot guardado en: {fullPath}");

        if (feedbackText != null)
        {
            feedbackText.text = "¡Imagen guardada!";
            feedbackText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            feedbackText.gameObject.SetActive(false);
        }
    }
}