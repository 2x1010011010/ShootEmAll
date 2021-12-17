using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _tapPosition;

    public event UnityAction OnScreenClick;
    public Vector3 TapPosition => _tapPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                _tapPosition = hit.point;
            OnScreenClick?.Invoke();
        }
    }
}
