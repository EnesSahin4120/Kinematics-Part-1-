using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    private InputInfo inputInfo;
    private LookController lookController;
    private MoveController moveController;

    private void Awake()
    {
        inputInfo = FindObjectOfType<InputInfo>();
        lookController = FindObjectOfType<LookController>();
        moveController = FindObjectOfType<MoveController>();

        lookController.Init(inputInfo);
        moveController.Init(inputInfo);
    }
}
