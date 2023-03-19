using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _fireButton;
    private void OnEnable() {
        GunfireController.OnProjectileFired += ChangeButtonState;
        Explosion.OnProjectileExplosion += ChangeButtonState;
    }

    private void OnDisable() {
        GunfireController.OnProjectileFired -= ChangeButtonState;
        Explosion.OnProjectileExplosion -= ChangeButtonState;
    }

    private void ChangeButtonState(Transform projectile) {
        _fireButton.SetActive(!_fireButton.activeSelf);
    }
}
