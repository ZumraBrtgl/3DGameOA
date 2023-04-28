using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    private Transform _tr; // görüntüyü kýsaltmak açýsýndan ama diðer taraftan da daha fazla kod yazmýþ oluyoruz.

    private void Start()
    {
        _tr = transform;
    }

    void Update() // kameranýn rotasyonunu kullanýp kendi uý ýn rotasyonunu belirleyeceðim. Önemli olan y eksenindeki durum. 
    {
        _tr.SetPositionAndRotation(_tr.position, new Quaternion(_tr.rotation.x, _camera.transform.rotation.y, _tr.rotation.z, _tr.rotation.w));
    }
}


