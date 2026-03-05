using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 10f;
    public float xRange = 5f;

    private PlayerInput playerInput; 
    private InputAction moveAction;

    private void Awake()
    {
        
        if (InputSystem.actions != null)
        {
            moveAction = InputSystem.actions.FindAction("Move");
        }
        else
        {
            Debug.LogError("หา Input Actions ไม่เจอ! อย่าลืมเช็คในหน้าต่าง Input System นะครับ");
        }
    }

    void Update()
    {
        if (moveAction == null) return;

        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        float horizontalMove = moveInput.x * turnSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * horizontalMove);
        
        Vector3 pos = transform.position;
        if (pos.x < -xRange) pos.x = -xRange;
        if (pos.x > xRange) pos.x = xRange;
        transform.position = pos;
    }
}
