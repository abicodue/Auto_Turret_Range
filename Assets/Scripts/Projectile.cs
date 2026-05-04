using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float projectileLifeTime;

    public void Init(float speed, float lifeTime)
    {
        projectileSpeed = speed;
        projectileLifeTime = lifeTime;

        Destroy(gameObject, projectileLifeTime);
    }

    private void Update()
    {
        this.transform.position += this.transform.forward * projectileSpeed * Time.deltaTime;
    }

}
