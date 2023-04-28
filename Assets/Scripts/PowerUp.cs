using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using MusicFilesNM;

public class PowerUp : MonoBehaviour
{
    private GameObject _music; //bir gameobject cashleyeceðimiz için music diye bir gameobject tanýmladýk.
    private MusicFiles _musicFiles;
    private ThirdPersonController _thirdPersonController;
    [SerializeField] private int Number;
    [SerializeField] private GameObject powerUp;

    private void Start()
    {
        _music = GameObject.Find("AudioManager"); // burada önce AudioManager'ý buluyoruz.
        _musicFiles = _music.GetComponent(typeof(MusicFiles)) as MusicFiles; // sonra bunun içerisindeki MusicFiles adý altýndaki componenti buluyoruz. 
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerup"))
        {
            powerUp.SetActive(true);
            AudioSource.PlayClipAtPoint(_musicFiles.music[Number],gameObject.transform.position); // virgülden sonra bir pozisyon verdik. Bu gameobjectim neredeyse orada clibi çal demek.
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
