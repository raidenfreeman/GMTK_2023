using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ScrollTexture : MonoBehaviour
{
    [SerializeField] RawImage img;

    [SerializeField] float scrollSpeed = 0.5f;

    void Update()
    {
        img.uvRect = new Rect((Time.time * scrollSpeed) % 2, 0f, 1f, 1f);
    }
}