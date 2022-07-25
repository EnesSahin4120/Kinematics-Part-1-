using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour, IWallInteractor<InteractableWall>
{
    //Shooting Parameters
    [SerializeField] private float shootSpeed;
    private Vector3 desiredBulletPos;
    private Vector3 hitBulletPos;
    private float arriveTime;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private Transform rayCamTransform;

    [SerializeField] private Text desiredBulletPos_Text;
    [SerializeField] private Text hitBulletPos_Text;

    private void OnEnable()
    {
        InputInfo.onIndicateClick += Shoot;
    }

    private void OnDisable()
    {
        InputInfo.onIndicateClick -= Shoot;
    }

    private void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(rayCamTransform.position, rayCamTransform.forward, out hit, Mathf.Infinity)){
            if (hit.transform.TryGetComponent(out InteractableWall _interactableWall)){
                desiredBulletPos = hit.point;
                CalculateHitBulletInfos();
                DetermineWall(_interactableWall, hitBulletPos + hit.normal * 2f, arriveTime);
            }
        }
    }

    //Set Bullet Hit Time and Hit Position
    private void CalculateHitBulletInfos()
    {
        float dist = Vector3.Distance(rayCamTransform.position, desiredBulletPos);
        arriveTime = dist / shootSpeed;
        float d = 0.5f * Physics.gravity.y * arriveTime * arriveTime;
        hitBulletPos = new Vector3(desiredBulletPos.x, desiredBulletPos.y + d, desiredBulletPos.z);
    }

    //Set Bullet Text Infos after Shooting
    private void ShowBulletInfos()
    {
        float desiredX = Mathematics.SimplifiedFraction(desiredBulletPos.x);
        float desiredY = Mathematics.SimplifiedFraction(desiredBulletPos.y);
        float desiredZ = Mathematics.SimplifiedFraction(desiredBulletPos.z);

        desiredBulletPos_Text.text = "Desired Bullet Position --> x : " + desiredX + " y : " + desiredY + " z : " + desiredZ;

        float hitX = Mathematics.SimplifiedFraction(hitBulletPos.x);
        float hitY = Mathematics.SimplifiedFraction(hitBulletPos.y);
        float hitZ = Mathematics.SimplifiedFraction(hitBulletPos.z);

        hitBulletPos_Text.text = "Hit Bullet Position --> x : " + hitX + " y : " + hitY + " z : " + hitZ;
    }

    //Hitting Target
    public void DetermineWall(InteractableWall interactableWall, Vector3 targetPos, float targetArriveTime)
    {
        ShowBulletInfos();
        interactableWall.Damage(targetPos, targetArriveTime);
    }
}
