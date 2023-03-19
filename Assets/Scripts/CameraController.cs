using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _fpsCamera;
    [SerializeField] private CinemachineVirtualCamera _projectileCamera;

    private void OnEnable() {
        GunfireController.OnProjectileFired += ChangeToProjectile;
        Explosion.OnProjectileExplosion += ChangeToFPS;
    }
    private void OnDisable() {
        GunfireController.OnProjectileFired -= ChangeToProjectile;
        Explosion.OnProjectileExplosion += ChangeToFPS;
    }

    private void ChangeToProjectile(Transform projectile) {
        _fpsCamera.Priority = 0;
        _projectileCamera.Priority = 1;
        _projectileCamera.Follow = projectile;
        _projectileCamera.LookAt = projectile;
    }

    private void ChangeToFPS(Transform projectile) {
        _fpsCamera.Priority = 1;
        _projectileCamera.Priority = 0;
    }
}
