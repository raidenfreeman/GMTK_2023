using System;
using System.Collections;
using UnityEngine;

public class ShipDispatcher : MonoBehaviour
{
    [SerializeField] private Interceptor[] interceptorGroups;
    [SerializeField] private Sprite interceptorGhost;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject ghost;
    [SerializeField] private SpriteRenderer ghostSprite;

    void Update()
    {
        if (ghostSprite.sprite)
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

    private void PlaceInterceptorGroup(Interceptor interceptorGroup, Vector3 target)
    {
        interceptorGroup.transform.position = target;
        interceptorGroup.gameObject.SetActive(true);
        DisableGhost();
    }

    private void DisableGhost()
    {
        ghostSprite.sprite = null;
    }


    public void OnInterceptorButtonPressed()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(WaitForMouseUp(() => { EnableGhost(interceptorGhost); }));
        }
    }

    private IEnumerator WaitForMouseUp(Action a)
    {
        while (Input.GetMouseButtonUp(0))
        {
            yield return 0;
        }

        a.Invoke();
    }

    private void EnableGhost(Sprite sprite)
    {
        ghostSprite.sprite = sprite;
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