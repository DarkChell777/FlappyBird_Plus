using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalSize;
    public Vector3 hoverSize = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 pressedSize = new Vector3(0.9f, 0.9f, 0.9f);
    public float speed = 0.2f; 

    private Coroutine resizeCoroutine;

    private void Start()
    {
        originalSize = transform.localScale;
    }

    private void ChangeSize(Vector3 targetSize)
    {
        if (resizeCoroutine != null)
        {
            StopCoroutine(resizeCoroutine);
        }
        resizeCoroutine = StartCoroutine(AnimateSize(targetSize));
    }

    private IEnumerator AnimateSize(Vector3 targetSize)
    {
        Vector3 initialSize = transform.localScale;
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime / speed;
            transform.localScale = Vector3.Lerp(initialSize, targetSize, progress);
            yield return null;
        }

        transform.localScale = targetSize; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeSize(hoverSize); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeSize(originalSize); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeSize(pressedSize); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ChangeSize(originalSize); 
    }
}




