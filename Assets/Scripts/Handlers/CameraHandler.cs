using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _offsetRotation;

    private void Start()
    {
        transform.position = _target.position + _offset;
        transform.eulerAngles = _offsetRotation;
    }
}
