using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private CharacterController characterController;
    private InputInfo inputInfo;

    public void Init(InputInfo _inputInfo)
    {
        inputInfo = _inputInfo;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        characterController.Move(MoveVector() * moveSpeed * Time.deltaTime);
    }

    private Vector3 MoveVector() 
    {
        return transform.right * inputInfo.RightInput() + transform.forward * inputInfo.ForwardInput();
    }
}
