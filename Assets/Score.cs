using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    private bool isPlayerAlive = true;

    private int totalScore = 0;

    private void Start()
    {
        StartCoroutine(IncScoreEverySecond());
    }

    public void AddScore(int score)
    {
        totalScore += score;
        tmp.text = $"Score: {totalScore}";
    }

    private IEnumerator IncScoreEverySecond()
    {
        while (isPlayerAlive)
        {
            yield return new WaitForSeconds(0.01f);
            AddScore(1);
            yield return null;
        }
    }

    public void OnRebelDied()
    {
        var tmpTransform = tmp.GetComponent<RectTransform>();
        var tmpPosition = tmpTransform.anchoredPosition;
        tmpTransform.DOShakePosition(2, 20);
        AddScore(1000);
    }

    public void OnPlayerDied()
    {
        isPlayerAlive = false;
    }
}