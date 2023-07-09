using UnityEngine;
using UnityEngine.UI;

public class ProgessBar : MonoBehaviour
{
    [SerializeField] private float RemainingTime = 120f;
    [SerializeField] private float TotalTime = 120f;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        RemainingTime = TotalTime;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RemainingTime -= Time.deltaTime;
        var percentage = RemainingTime / TotalTime;
        slider.value = percentage;
    }
}