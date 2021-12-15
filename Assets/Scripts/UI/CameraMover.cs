using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    
    [SerializeField] private Player _target;
    [SerializeField] private float _offsetVertical;
    [SerializeField] private float _offsetHorizontal;
    [SerializeField] private float _speed;
    
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y + _offsetVertical, _target.transform.position.z - _offsetHorizontal);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed*Time.deltaTime);
    }

}
