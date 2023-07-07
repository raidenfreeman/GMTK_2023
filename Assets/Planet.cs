using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Planet : MonoBehaviour
{
    private static readonly float width = 88f;
    private static readonly float height = 87f;
    private static readonly float maxOffsetX = 1920f + width;
    private static readonly float maxOffsetY = 1080f + height;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Image imageRef;

    [SerializeField] private RectTransform rectTransform;


    [SerializeField] float scrollSpeedX = 0.05f;
    [SerializeField] float scrollSpeedY = 0.001f;
    private bool reset = true;

    private int spriteArrayLen;
    // Start is called before the first frame update

    private int spriteIndex = 0;

    float timer = 0;

    private void Start()
    {
        spriteArrayLen = sprites.Length;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Math.Truncate(timer % 2) == 0)
        {
            if (reset)
            {
                spriteIndex = spriteIndex < spriteArrayLen - 1 ? ++spriteIndex : 0;
                var imageRefSprite = sprites[spriteIndex];
                rectTransform.sizeDelta = imageRefSprite.textureRect.size;
                imageRef.sprite = imageRefSprite;
                reset = false;
            }
        }
        else
        {
            reset = true;
        }

        rectTransform.anchoredPosition += new Vector2((Time.deltaTime * scrollSpeedX), (Time.deltaTime * scrollSpeedY));
    }
}