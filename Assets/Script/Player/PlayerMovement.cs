using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _playerController;
    //Ground Check
    [SerializeField] private Transform _grountCheckOrigin;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundMask;
    private bool _isGrounded;
    //
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _heightJump;
    private Vector3 _velocity;

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_grountCheckOrigin.position, _groundCheckRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) _moveSpeed *= 2;
        else if (Input.GetKeyUp(KeyCode.LeftShift)) _moveSpeed /= 2;
        Vector3 directionMovement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        directionMovement.Normalize();
        _playerController.Move(directionMovement.normalized * _moveSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_heightJump * -2f * _gravity);
        }

        _velocity.y += _gravity * Time.deltaTime;
        _playerController.Move(_velocity * Time.deltaTime);
    }


}
