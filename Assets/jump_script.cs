using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(Rigidbody))]
public class jump_script : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheckPoint;

    private XROrigin _xrRig;
    private CapsuleCollider _collider;
    private Rigidbody _body;

    private bool isGrounded => Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;
    // groundCheckPoint is just an empty child GameObject set to (0,0,0) on the XROrigin


    void Start()
    {
        _xrRig = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        _body = GetComponent<Rigidbody>();
        jumpActionReference.action.performed += OnJump;
    }

    void Update()
    {
        var center = _xrRig.CameraInOriginSpacePos;

        _collider.center = new Vector3(center.x, _collider.height/2, center.z);
        _collider.height = Mathf.Clamp(_xrRig.CameraInOriginSpaceHeight, 1.4f, 1.8f);
        //_collider.height = _xrRig.CameraInOriginSpaceHeight;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!isGrounded) return;
        _body.AddForce(Vector3.up * jumpForce);
    }

}
