using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 1.5f;
    [SerializeField] private GameObject _rocketExplosion;
    public delegate void ProjectileExplosion(Transform projectile);
    public static event ProjectileExplosion OnProjectileExplosion;
    private bool _exploded;
    private void DoExplosion(Vector3 point)
    {
        _exploded = true;
        var colliders = Physics.OverlapSphere(point, _explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Cube cube))
            {
                if(!cube.Detouched)
                {
                    cube.Detouch();
                    cube.GetComponent<Rigidbody>().AddExplosionForce(1000f, point, _explosionRadius);
                }
                else
                {
                    cube.Destroy();
                }
            }
        }
        GameObject newExplosion = Instantiate(_rocketExplosion, transform.position, _rocketExplosion.transform.rotation, null);
        Debug.Log(Entity.DetouchedCubesAmount);
    }

    private void OnTriggerEnter(Collider other) {
        if (_exploded) return;
        if (other.GetComponent<Cube>() == null && other.GetComponent<Ground>() == null) return;
        DoExplosion(other.transform.position);
        if (OnProjectileExplosion != null)
            OnProjectileExplosion(other.transform);
        Destroy(gameObject);
    }
}
