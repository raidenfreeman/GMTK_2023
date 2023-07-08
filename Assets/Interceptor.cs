using UnityEngine;

public class Interceptor : MonoBehaviour
{
    [SerializeField] private GameObject[] interceptors;

    [SerializeField] private float horizontalSpeed = 2;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * horizontalSpeed));
    }
}