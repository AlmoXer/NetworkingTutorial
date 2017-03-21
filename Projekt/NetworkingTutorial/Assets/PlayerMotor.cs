
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Get a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    //Get a rotatinal vector
    public void Rotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Get a rotatinal vector
    public void CameraRotation(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
    
    //Run every physics iteration
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on verlocity variable

    void PerformMovement()
    {
        if(velocity !=  Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    //Perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam!=null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
