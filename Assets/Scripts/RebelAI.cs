using UnityEngine;

public class RebelAI : MonoBehaviour
{
    private static readonly int Explode = Animator.StringToHash("Explode");
    private static readonly int VerticalSpeed = Animator.StringToHash("VerticalSpeed");
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D col2D;
    [SerializeField] private Score score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Die();
    }

    void Die()
    {
        col2D.enabled = false;
        animator.SetTrigger(Explode);
        score.OnPlayerDied();
        score.OnRebelDied();
    }

    void GoDown()
    {
        animator.SetFloat(VerticalSpeed, -1);
    }

    void GoUp()
    {
        animator.SetFloat(VerticalSpeed, 1);
    }

    public void ExplosionDone()
    {
    }
}