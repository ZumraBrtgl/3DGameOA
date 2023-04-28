using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private int health = 3;
    [SerializeField] GameObject[] _healthUI;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sphere"))
        {
            health--;
            _healthUI[health].gameObject.SetActive(false);
            if (health == 0)
            {
                _panel.SetActive(true);
                _gameOver.SetActive(true);
                StartCoroutine(Fade());
            }
        }

        if (other.gameObject.CompareTag("UI"))
        {
            var a = other.gameObject.transform.GetChild(0). gameObject; // boþ obje olan infonun deðil bir altýndaki canvasýn kapanýp açýlmasýný istiyoruz.
            a.SetActive(true);
            Debug.Log("UI Activated");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("UI"))
        {
            var a = other.gameObject.transform.GetChild(0).gameObject; // boþ obje olan infonun deðil bir altýndaki canvasýn kapanýp açýlmasýný istiyoruz.
            a.SetActive(false);
            Debug.Log("UI Deactivated");
        }

    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
}
