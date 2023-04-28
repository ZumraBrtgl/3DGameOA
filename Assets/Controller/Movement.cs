using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // A�a��da Movingin i�ine InputAction yazd���m�z i�in bu k�t�phaneyi eklememiz gerekiyor. 

public class Movement : MonoBehaviour
{
    private Rigidbody capsule;
    public Vector2 moveVal;
    public float moveSpeed = 10;

    private void Awake() // Awake metodunda Rigidbodyi al�yoruz ��nk� �zerine fonksiyonlar uygulamak istiyoruz.
    {
        capsule = GetComponent<Rigidbody>();
    }

    public void Moving(InputAction.CallbackContext value) // 3 farkl� context var, biz valueyu se�iyoruz. De�erini okumak istedi�imiz i�in.
    {
        if(value.performed) // valueda �� tane olas�l�k var: canceled, performed, started (bu bir booling parametre)
        {
           // Debug.Log("Performed");
           moveVal = value.ReadValue<Vector2>(); //Input Aciton k�sm�nda Movement aksiyonuna 2DVector tipini tan�mlam��t�k. Bu y�zden 2d vector okumam�z gerekiyor.
           // Debug.Log(moveVal.x + " " + moveVal.y);
           // capsule.AddForce(new Vector3(moveVal.x * moveSpeed, 0f, moveVal.y * moveSpeed), ForceMode.Impulse); //�nce vekt�r tan�mlamam�z gerekiyor.
        }

        if (value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }
}
