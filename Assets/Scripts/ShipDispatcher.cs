using UnityEngine;
using UnityEngine.UI;

public class ShipDispatcher : MonoBehaviour
{
    [SerializeField] private Interceptor[] interceptorGroups;
    [SerializeField] private Sprite interceptorGhost;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject ghost;
    [SerializeField] private SpriteRenderer ghostSprite;
    [SerializeField] private Button[] btns;
    private int interceptorsLeft = 1;

    void Update()
    {
        if (interceptorsLeft > 0)
        {
            Vector2 screenToWorldPoint = mainCam.ScreenToWorldPoint(Input.mousePosition);
            screenToWorldPoint.x = -7.5f;
            screenToWorldPoint.y = Mathf.Clamp(screenToWorldPoint.y, -4.6f, 4.6f);
            ghost.transform.position = screenToWorldPoint;
            if (Input.GetMouseButtonUp(0))
            {
                DispatchInterceptors(screenToWorldPoint);
            }
        }
    }

    public void EnableAllInt()
    {
        interceptorsLeft = 5;
        foreach (var button in btns)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void InterceptorsDone()
    {
        interceptorsLeft++;
        ghostSprite.sprite = interceptorGhost;
    }

    private void PlaceInterceptorGroup(Interceptor interceptorGroup, Vector3 target)
    {
        interceptorsLeft--;
        interceptorGroup.transform.position = target;
        interceptorGroup.gameObject.SetActive(true);
        if (interceptorsLeft == 0)
        {
            DisableGhost();
        }
    }

    private void DisableGhost()
    {
        ghostSprite.sprite = null;
    }

    private void DispatchInterceptors(Vector3 target)
    {
        for (int i = 0; i < interceptorGroups.Length; i++)
        {
            var interceptorGroup = interceptorGroups[i];
            if (!interceptorGroup.isActiveAndEnabled)
            {
                PlaceInterceptorGroup(interceptorGroup, target);
                return;
            }
        }
    }
}