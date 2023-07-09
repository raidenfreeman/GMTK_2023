using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private RebelAI ai;

    public void OnExplodeDone()
    {
        ai.ExplosionDone();
    }
}