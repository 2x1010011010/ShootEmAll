using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvas;

    public void Open()
    {
        _canvas.alpha = 1;
    }

    public void Close()
    {
        _canvas.alpha = 0;
    }
}
