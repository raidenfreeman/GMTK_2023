using UnityEngine;
using UnityEngine.UI;

public class MovingPlanet : MonoBehaviour
{
    private static readonly float width = 88f;
    private static readonly float height = 87f;
    private static readonly float maxOffsetX = 1920f + width;
    private static readonly float maxOffsetY = 1080f + height;


    [SerializeField] Image img;
    [SerializeField] float scrollSpeedX = 0.05f;
    [SerializeField] float scrollSpeedY = 0.001f;

    private Vector2 topLeftBound = new Vector2(-1080, 1920);

    void Update()
    {
        // var offset = Time.deltaTime * scrollSpeedX;
        // Vector2.Lerp(topLeftBound,-topLeftBound, offset)
        // img.rectTransform.anchoredPosition = new Vector2((Time.time * scrollSpeedX) % 1080,(Time.time * scrollSpeedY) % 1920 );
        img.rectTransform.anchoredPosition += new Vector2(maxOffsetX * (Time.deltaTime * scrollSpeedX),
            maxOffsetY * (Time.deltaTime * scrollSpeedY));
    }
}