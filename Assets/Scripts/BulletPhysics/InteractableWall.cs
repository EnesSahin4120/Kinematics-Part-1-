using UnityEngine;
using System.Collections;

public class InteractableWall : MonoBehaviour, IInteractableWall
{
    [SerializeField] private GameObject damageParticlePrefab; 
    public void Damage(Vector3 targetDamagePos, float targetArriveTime)
    {
        StartCoroutine(Damage_at_Time(targetDamagePos, targetArriveTime));
    }

    private IEnumerator Damage_at_Time(Vector3 pos, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject damageParticle = Instantiate(damageParticlePrefab, pos, Quaternion.identity);
    }
}
