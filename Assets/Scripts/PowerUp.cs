using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using MusicFilesNM;

public class PowerUp : MonoBehaviour
{
    private GameObject _music; //bir gameobject cashleyece�imiz i�in music diye bir gameobject tan�mlad�k.
    private MusicFiles _musicFiles;
    private ThirdPersonController _thirdPersonController;
    [SerializeField] private int Number;
    [SerializeField] private GameObject powerUp;

    private void Start()
    {
        _music = GameObject.Find("AudioManager"); // burada �nce AudioManager'� buluyoruz.
        _musicFiles = _music.GetComponent(typeof(MusicFiles)) as MusicFiles; // sonra bunun i�erisindeki MusicFiles ad� alt�ndaki componenti buluyoruz. 
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerup"))
        {
            powerUp.SetActive(true);
            AudioSource.PlayClipAtPoint(_musicFiles.music[Number],gameObject.transform.position); // virg�lden sonra bir pozisyon verdik. Bu gameobjectim neredeyse orada clibi �al demek.
            _thirdPersonController.JumpHeight = 20.2f;
            Invoke("BackToNormalJump", 3.0f);
            Destroy(other.gameObject);
        }
    }

    private void BackToNormalJump()
    {
        powerUp.SetActive(false);
        _thirdPersonController.JumpHeight = 1.2f;
    }
}
