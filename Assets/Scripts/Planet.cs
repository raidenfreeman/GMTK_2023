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

    private int spriteArrayLen;
    // Start is called before the first frame update

    private int spriteIndex = 0;

    private void Start()
    {
        spriteArrayLen = sprites.Length;
    }

    void Update()
    {
        if (IsOutOfBounds(rectTransform, imageRef.sprite.textureRect.size))
        {
            spriteIndex = spriteIndex < spriteArrayLen - 1 ? ++spriteIndex : 0;
            var sprite = sprites[spriteIndex];
            rectTransform.sizeDelta = sprite.textureRect.size;
            imageRef.sprite = sprite;
            rectTransform.anchoredPosition = new Vector2(-1074, 508);
        }

        rectTransform.anchoredPosition += new Vector2((Time.deltaTime * scrollSpeedX), (Time.deltaTime * scrollSpeedY));
    }

    private static bool IsOutOfBounds(RectTransform rect, Vector2 textureRectSize)
    {
        var localScale = rect.localScale;
        var rectAnchoredPosition = rect.anchoredPosition;
        return Mathf.Abs(rectAnchoredPosition.x) > 0.5 * (1920 + textureRectSize.x * localScale.x) + 5 ||
               Mathf.Abs(rectAnchoredPosition.y) > 0.5 * (1080 + textureRectSize.y * localScale.y) + 5;
    }
}