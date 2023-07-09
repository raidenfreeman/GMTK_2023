using DG.Tweening;
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
    void FixedUpdate()
    {
        int layerMask = 1 << 3;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 20, layerMask);

        // If it hits something...
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, hit.transform.position - transform.position);
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            // float distance = Mathf.Abs(hit.point.y - transform.position.y);
            // float heightError = floatHeight - distance;
            //
            // // The force is proportional to the height error, but we remove a part of it
            // // according to the object's speed.
            // float force = liftForce * heightError - rb2D.velocity.y * damping;
            //
            // // Apply the force to the rigidbody.
            // rb2D.AddForce(Vector3.up * force);
        }
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
        transform.DOShakePosition(4, 0.4f);
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