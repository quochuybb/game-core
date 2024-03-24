using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform _camPlayer;
    private Vector3 _offset;
    void Start()
    {
        _camPlayer = Camera.main.transform;
        _offset = _camPlayer.position - target.position;
    }
    
    void LateUpdate()
    {
        _camPlayer.position = target.position + _offset;
    }
}
