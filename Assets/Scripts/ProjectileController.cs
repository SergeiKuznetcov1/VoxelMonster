using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _changeDirSpeed;
    [SerializeField] private Joystick _joystick;

    private void Start() {
        _joystick = FindObjectOfType<Joystick>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        
        float inputX = _joystick.Horizontal * _changeDirSpeed;
        float inputY = _joystick.Vertical * _changeDirSpeed;

        Quaternion rotationX = Quaternion.AngleAxis(inputY, Vector3.left);
        Quaternion rotationY = Quaternion.AngleAxis(inputX, Vector3.up);
        transform.rotation *= rotationX * rotationY;
    }
}
