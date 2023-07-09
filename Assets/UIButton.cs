using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Button btn;
    [SerializeField] private Sprite enabledButtonSprite;
    [SerializeField] private Sprite disabledButtonSprite;

    private void Awake()
    {
        img.sprite = btn.interactable ? enabledButtonSprite : disabledButtonSprite;
    }

    public void EnableButton()
    {
        img.sprite = enabledButtonSprite;
        btn.interactable = true;
    }

    public void DisableButton()
    {
        img.sprite = disabledButtonSprite;
        btn.interactable = false;
    }
}