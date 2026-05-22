using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    float horizontalInput = 0f;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float fallbackXLimit = 8f;

    SafeAreaController safeArea;

    void Awake()
    {
        safeArea = FindFirstObjectByType<SafeAreaController>();
    }

    void Update()
    {
        horizontalInput = 0f;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizontalInput = -1f;
        }else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizontalInput = 1f;
        }

        transform.position += Vector3.right * horizontalInput * moveSpeed * Time.deltaTime; 

        float leftLimit = safeArea != null ? safeArea.LeftBound : -fallbackXLimit;
        float rightLimit = safeArea != null ? safeArea.RightBound : fallbackXLimit;

        float clampX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       FindFirstObjectByType<GameManager>().GameOver();

    }
}
