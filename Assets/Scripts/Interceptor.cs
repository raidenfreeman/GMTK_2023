using UnityEngine;

public class Interceptor : MonoBehaviour
{
    [SerializeField] private GameObject[] interceptors;

    [SerializeField] private float horizontalSpeed = 2;

    [SerializeField] private float oscillationPeriod = 1f;
    private int totalInterceptors;


    private void Awake()
    {
        totalInterceptors = interceptors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * horizontalSpeed));
        var time = Time.time;
        for (int i = 0; i < totalInterceptors; i++)
        {
            var interceptor = interceptors[i];
            var interceptorPosition = interceptor.transform.localPosition;
            if (oscillationPeriod > 0)
            {
                var phase = (i % 4) * 0.5f;
                interceptor.transform.localPosition =
                    new Vector3(interceptorPosition.x,
                        Mathf.Sin((time / oscillationPeriod + phase) * Mathf.PI));
            }
        }
    }
}