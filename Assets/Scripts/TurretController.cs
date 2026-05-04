using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private Transform muzzlePoint;
    [SerializeField]
    private Transform targetDrone;
    [SerializeField]
    private float fireAngleThreshold = 5f;    
    [SerializeField]
    private float fireInterval = 0.5f;
    [SerializeField]
    private float projectileSpeed = 50f;
    [SerializeField]
    private float projectileLifeTime = 3f;
    [SerializeField]
    private GameObject projectilePrefab;

    private float lastFireTime= -999f;

    private bool IsMuzzlePointAligned()
    {
        Vector3 direction = targetDrone.position - muzzlePoint.position;
        float angle = Vector3.Angle(muzzlePoint.forward, direction);

        if (angle <= fireAngleThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Fire()
    {
        if (!IsMuzzlePointAligned())
        {
            return;
        }

        if (Time.time < lastFireTime + fireInterval)
        {
            return;
        }

        lastFireTime = Time.time;

        GameObject newProjectile = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);

        Projectile projectile = newProjectile.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Init(projectileSpeed, projectileLifeTime);
        }
    }

    private void Update()
    {
        Fire();
    }

}
