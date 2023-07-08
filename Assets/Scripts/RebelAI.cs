using UnityEngine;

public class RebelAI : MonoBehaviour
{
    private static readonly int Explode = Animator.StringToHash("Explode");
    private static readonly int VerticalSpeed = Animator.StringToHash("VerticalSpeed");
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Die()
    {
        animator.SetTrigger(Explode);
    }

    void GoDown()
    {
        animator.SetFloat(VerticalSpeed, -1);
    }

    void GoUp()
    {
        animator.SetFloat(VerticalSpeed, 1);
    }
}