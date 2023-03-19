using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Image _hpCurrent;
    private float _cubeValue;
    private void Start() {
        Debug.Log(Entity.TotalCubesAmount);
        _cubeValue = 1.0f / Entity.TotalCubesAmount;
        Debug.Log(_cubeValue);
    }

    private void OnEnable() {
        Explosion.OnProjectileExplosion += UpdateHPbar;
    }

    private void UpdateHPbar(Transform projectile) {
        float result = Entity.DetouchedCubesAmount * _cubeValue;
        _hpCurrent.fillAmount = 1.0f - result;
    }
}
