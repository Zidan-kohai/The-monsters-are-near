using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _verticalMaxAngle;
    [SerializeField] private Transform _bodyTransform;
    private float Xrotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * _rotateSpeed * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * _rotateSpeed * Time.deltaTime;
        Xrotation -= MouseY;
        Xrotation = Mathf.Clamp(Xrotation, -_verticalMaxAngle, _verticalMaxAngle);
        transform.localRotation = Quaternion.Euler(Xrotation, 0, 0);
        _bodyTransform.Rotate(Vector3.up, MouseX);
    }
}
