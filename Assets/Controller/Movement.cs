using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Aþaðýda Movingin içine InputAction yazdýðýmýz için bu kütüphaneyi eklememiz gerekiyor. 

public class Movement : MonoBehaviour
{
    private Rigidbody capsule;
    public Vector2 moveVal;
    public float moveSpeed = 10;

    private void Awake() // Awake metodunda Rigidbodyi alýyoruz çünkü üzerine fonksiyonlar uygulamak istiyoruz.
    {
        capsule = GetComponent<Rigidbody>();
    }

    public void Moving(InputAction.CallbackContext value) // 3 farklý context var, biz valueyu seçiyoruz. Deðerini okumak istediðimiz için.
    {
        if(value.performed) // valueda üç tane olasýlýk var: canceled, performed, started (bu bir booling parametre)
        {
           // Debug.Log("Performed");
           moveVal = value.ReadValue<Vector2>(); //Input Aciton kýsmýnda Movement aksiyonuna 2DVector tipini tanýmlamýþtýk. Bu yüzden 2d vector okumamýz gerekiyor.
           // Debug.Log(moveVal.x + " " + moveVal.y);
           // capsule.AddForce(new Vector3(moveVal.x * moveSpeed, 0f, moveVal.y * moveSpeed), ForceMode.Impulse); //önce vektör tanýmlamamýz gerekiyor.
        }

        if (value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }
}
