using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class RebelAI : MonoBehaviour
{
    private static readonly int Explode = Animator.StringToHash("Explode");
    private static readonly int VerticalSpeed = Animator.StringToHash("VerticalSpeed");
    private static readonly int Reset = Animator.StringToHash("Reset");
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D col2D;
    [SerializeField] private Score score;
    [SerializeField] private float speed;
    [SerializeField] private float bottomBound;
    [SerializeField] private float topBound;
    [SerializeField] private ProgessBarToCapital progressbar;

    private readonly float randomMovementDuration = 0.5f;

    private int AIRoutine = 0;
    private bool isMovingRandomly = false;

    int previousDirection = 1;
    private TweenerCore<Vector3, Vector3, VectorOptions> randomMoveTween;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        switch (AIRoutine)
        {
            case 0:
                MoveUpAndDown(position, position.y);
                break;
            case 1:
                MoveRandomly(position, position.y);
                break;
            case 2:
                AvoidObstaclesInFront();
                break;
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

    private void AvoidObstaclesInFront()
    {
        int layerMask = 1 << 3;
        var originCenter = transform.position;
        var originUp = transform.position + Vector3.up * 0.65f;
        var originDown = transform.position + Vector3.down * 0.65f;
        RaycastHit2D hitUp = Physics2D.Raycast(originUp, Vector2.left, 20, layerMask);
        RaycastHit2D hitCenter = Physics2D.Raycast(originCenter, Vector2.left, 20, layerMask);
        RaycastHit2D hitDown = Physics2D.Raycast(originDown, Vector2.left, 20, layerMask);
        float distanceUp = Mathf.Abs(hitUp.point.y - transform.position.y);
        float distanceCenter = Mathf.Abs(hitCenter.point.y - transform.position.y);
        float distanceDown = Mathf.Abs(hitDown.point.y - transform.position.y);

        var closestDistance = Mathf.Min(new[] { distanceCenter, distanceUp, distanceDown });
        if (distanceUp == closestDistance)
        {
        }

        if (distanceDown == closestDistance)
        {
        }

        if (distanceCenter == closestDistance)
        {
        }

        // If it hits something...
        // if (hit.collider != null)
        // {
        //     Debug.DrawRay(origin, hit.transform.position - origin);
        //     float distance = Mathf.Abs(hit.point.y - transform.position.y);
        // }
    }

    private void MoveRandomly(Vector3 position, float positionY)
    {
        if (!isMovingRandomly)
        {
            var maxUp = Mathf.Min(positionY + speed * randomMovementDuration, topBound);
            var maxDown = Mathf.Max(positionY - speed * randomMovementDuration, bottomBound);
            var targetY = Random.Range(maxDown, maxUp);
            animator.SetFloat(VerticalSpeed, targetY > positionY ? 1 : -1);
            var duration = Mathf.Abs(positionY - targetY) / speed;
            randomMoveTween = transform.DOMoveY(targetY, duration).OnComplete(() => { isMovingRandomly = false; })
                .SetEase(Ease.Linear);
            isMovingRandomly = true;
        }
    }

    private void MoveUpAndDown(Vector3 position, float positionY)
    {
        if (positionY < bottomBound)
        {
            transform.position = new Vector3(position.x, bottomBound, position.z);
            previousDirection = 1;
        }

        if (positionY > topBound)
        {
            transform.position = new Vector3(position.x, topBound, position.z);
            previousDirection = -1;
        }

        if (previousDirection == 1)
        {
            GoUp();
        }
        else
        {
            GoDown();
        }
    }

    void Die()
    {
        col2D.enabled = false;
        animator.SetTrigger(Explode);
        score.OnRebelDied();
        transform.DOShakePosition(3, 0.4f).OnComplete(RewspawnWithAdvancedAI);
        randomMoveTween.Kill();
        progressbar.Pause();
    }

    private void RewspawnWithAdvancedAI()
    {
        progressbar.Restart();
        col2D.enabled = true;
        AIRoutine++;
        animator.SetFloat(VerticalSpeed, 0);
        animator.SetTrigger(Reset);
        score.OnRebelRespawn();
    }

    void GoDown()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        previousDirection = -1;
        animator.SetFloat(VerticalSpeed, -1);
    }

    void GoUp()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        previousDirection = 1;
        animator.SetFloat(VerticalSpeed, 1);
    }

    public void ExplosionDone()
    {
    }
}