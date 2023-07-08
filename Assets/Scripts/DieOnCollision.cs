using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // animator.SetTrigger();
    }
}