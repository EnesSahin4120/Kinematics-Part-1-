using UnityEngine;
using System.Collections;

public class ConstantAcceleration_Moving : MonoBehaviour
{
    //Necessary Move Parameters
    [SerializeField] Transform startTransform;
    [SerializeField] Transform endTransform;
    [SerializeField] private float acceleration;
    [SerializeField] private float arriveTime; 

    private float currentTime;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetStartInfo();
        StartCoroutine(Move());
    }

    private void SetStartInfo()
    {
        currentTime = arriveTime;
        transform.position = startTransform.position;
    }

    //Find Initial Velocity and Move
    private IEnumerator Move() 
    {
        float distance = Vector3.Distance(startTransform.position, endTransform.position);
        Vector3 direction = (endTransform.position - startTransform.position).normalized;
        float initVel = (distance / arriveTime) - (acceleration * arriveTime / 2f);
        float velocity = initVel;
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            velocity += acceleration * Time.deltaTime;
            rb.velocity = direction * velocity;
            yield return null;
        }
        rb.velocity = Vector3.zero;
        yield break;
    }
}
