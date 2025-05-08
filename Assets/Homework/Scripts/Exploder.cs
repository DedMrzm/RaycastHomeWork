using Unity.Burst.CompilerServices;
using UnityEngine;

public class Exploder : MonoBehaviour, IExploider
{
    private KeyCode ShootKey = KeyCode.Mouse1;

    [SerializeField] private float _explotionRadius;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private ParticleSystem _explodeEffect;

    private void Update()
    {
        if (Input.GetKeyDown(ShootKey))
        {
            Shoot();
        }
    }

    public void Explose(Vector3 explotionPoint)
    {
        Collider[] targets = Physics.OverlapSphere(explotionPoint, _explotionRadius);

        foreach (Collider target in targets)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();

            if (damageable != null)
                damageable.TakeDamage(_damage);
        }
    }

    private void Shoot()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hit))
        {
            Instantiate(_explodeEffect, hit.point, _explodeEffect.gameObject.transform.rotation);
            Explose(hit.point);
        }
    }
}
 