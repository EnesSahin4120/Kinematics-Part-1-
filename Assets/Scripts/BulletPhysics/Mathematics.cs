using UnityEngine;

public  class Mathematics : MonoBehaviour
{
    static public float SimplifiedFraction(float targetNumerical)
    {
        return Mathf.Round(targetNumerical * 10.0f) * 0.1f;
    }
}
