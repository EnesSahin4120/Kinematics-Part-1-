using UnityEngine;

public class LookController : MonoBehaviour
{
    [SerializeField] private float sensivity;
    [SerializeField] private Transform player;
    private float xRotation;

    private InputInfo inputInfo;

    public void Init(InputInfo _inputInfo)
    {
        inputInfo = _inputInfo;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        xRotation -= inputInfo.MouseY() * Time.deltaTime * sensivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * inputInfo.MouseX() * Time.deltaTime * sensivity);
    }
}
