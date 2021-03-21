using UnityEngine;

public class FreeCamScript : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;
    public float smoothness = 8f;
    public float speed = 0.01f;
    public float speedMultiplier = 5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        position = transform.position;
        rotation = transform.eulerAngles;
    }

    void LateUpdate()
    {
        float panX = Input.GetAxis("Mouse X");
        float panY = Input.GetAxis("Mouse Y");
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool ePressed = Input.GetKey(KeyCode.E);
        bool qPressed = Input.GetKey(KeyCode.Q);

        rotation.x -= panY;
        rotation.y += panX;

        Quaternion nextRotation = Quaternion.Euler(rotation);
        Quaternion smoothRotation = Quaternion.Lerp(transform.rotation, nextRotation, smoothness * Time.deltaTime);
        transform.rotation = smoothRotation;

        float currentSpeed = shiftPressed ? speed * speedMultiplier : speed;
        position +=  ((transform.right * moveX) + (transform.forward * moveY)) * currentSpeed;
        if (ePressed) position += Vector3.up * currentSpeed;
        if (qPressed) position += Vector3.down * currentSpeed;

        Vector3 nextPosition = Vector3.forward + position;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, nextPosition, smoothness * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
