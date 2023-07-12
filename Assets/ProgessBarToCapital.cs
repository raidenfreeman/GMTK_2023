using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class ProgessBarToCapital : MonoBehaviour
{
    [SerializeField] private float RemainingTime = 120f;
    [SerializeField] private float TotalTime = 120f;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject gameover;
    [SerializeField] private Transform planetTransform;

    private bool isPaused = false;
    private TweenerCore<Vector3, Vector3, VectorOptions> planetTween;

    private void Awake()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            return;
        }

        RemainingTime -= Time.deltaTime;
        if (RemainingTime <= 0)
        {
            gameover.SetActive(true);
        }

        if (RemainingTime <= 30 && planetTween == null)
        {
            planetTween = planetTransform.DOMoveX(5, RemainingTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                planetTween = null;
            });
        }

        var percentage = RemainingTime / TotalTime;
        slider.value = percentage;
    }

    public void Pause()
    {
        isPaused = true;
        if (planetTween != null)
        {
            planetTween.Kill();
            planetTween = null;
        }
    }

    public void Restart()
    {
        isPaused = false;
        RemainingTime = TotalTime;
        if (planetTween != null)
        {
            planetTween.Kill();
            planetTween = null;
        }

        planetTransform.DOMove(new Vector3(-10, 0, 0), 2);
    }
}