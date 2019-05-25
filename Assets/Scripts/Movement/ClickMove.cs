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

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) &&  !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, rayDistance, clickableLayer))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

}
