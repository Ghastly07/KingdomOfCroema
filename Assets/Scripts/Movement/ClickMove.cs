using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ClickMove : MonoBehaviour
{
    [SerializeField]
    LayerMask clickableLayer;

    [SerializeField]
    Camera myCamera;

    [SerializeField]
    float rayDistance = 200;

    [SerializeField]
    Texture2D defaultCursor;

    [SerializeField]
    Texture2D attackCursor;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, rayDistance);

        if (hit.transform.gameObject.layer == LayerMask.NameToLayer(Data.EnemyLayer))
        {
            Cursor.SetCursor(attackCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }

        if (Input.GetMouseButton(0) &&  !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit, rayDistance, clickableLayer))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

}
