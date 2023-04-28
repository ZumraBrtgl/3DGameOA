using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private Transform _tr; // g�r�nt�y� k�saltmak a��s�ndan ama di�er taraftan da daha fazla kod yazm�� oluyoruz.

    private void Start()
    {
        _tr = transform;
    }

    void Update() // kameran�n rotasyonunu kullan�p kendi u� �n rotasyonunu belirleyece�im. �nemli olan y eksenindeki durum. 
    {
        _tr.SetPositionAndRotation(_tr.position, new Quaternion(_tr.rotation.x, _camera.transform.rotation.y, _tr.rotation.z, _tr.rotation.w));
    }
}


