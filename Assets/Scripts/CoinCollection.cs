using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CoinRand;
using System;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    private CoinInst randomizer;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private TMP_Text _text;
    int count = 0;
    private AudioSource click;
    private int totalSpawnPoints;
    int y;

    private void Start()
    {
        click = GetComponent<AudioSource>(); // burada cashliyoruz
        //biz bir gameobject arýyoruz. Bu gameobject bizim componentimize ait bir gamObj olmalý.
        randomizer = _gameObject.GetComponent(typeof(CoinInst)) as CoinInst; // benzerini MusicFiles scriptinde de yapmýþtýk.
        totalSpawnPoints = randomizer.spawnPoints.Count();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            //Destroy(other.gameObject);
            count++; // countu bir artýrýyoruz
            _text.text = count.ToString(); // componentimdeki text kýsmýný counta eþledik. Ama int olduðu için stringe çeviriyoruz.
            other.gameObject.SetActive(false);
            click.Play();
            StartCoroutine(Spawn(other.gameObject));
        }
    }

    IEnumerator Spawn(GameObject gameObject)
    {
        int x = randomizer.spawnPoints.IndexOf(gameObject.transform.parent.transform);
        // yakaladýðýmýz pointi listeden çýkarmamýz gerekiyor.
        //3 saniye sonra active state dönecek
        randomizer.randomValues.Remove(x);
        while (randomizer.randomValues.Count < Math.Ceiling(totalSpawnPoints/2.0f))
        {
            y = randomizer.r.Next(0, randomizer.spawnPoints.Count() - 1);
            randomizer.randomValues.Add(y);
        }
        yield return new WaitForSeconds(3);
        gameObject.transform.position = randomizer.spawnPoints[y]. transform.position;
        gameObject.SetActive(true);
    }
}
