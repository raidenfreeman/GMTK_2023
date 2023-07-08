using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ScrollTexture : MonoBehaviour
{
    [SerializeField] RawImage img;

    [SerializeField] float scrollSpeed = 0.5f;

    private float initialUVY;

    private void Awake()
    {
        initialUVY = img.uvRect.y;
    }

    void Update()
    {
        img.uvRect = new Rect((Time.time * scrollSpeed) % 2, initialUVY, 1f, 1f);
    }
}