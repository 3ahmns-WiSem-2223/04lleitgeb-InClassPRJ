using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnAndDestroyScript : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject circle;
    public bool stop;

    public Text destroyText;
    public int destroyCount;

    public float spawnMostWait;
    public float spawnLeastWait;
    public Vector3 spawnValues;

    void Start()
    {
        destroyCount = 0;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
                destroyCount += 1;
                destroyText.text = "Counter: " + destroyCount.ToString();
            }

        }


        if (!stop)
        {
            StartCoroutine(Spawn());
        }



    IEnumerator Spawn()
    {
        stop = true;
        yield return new WaitForSeconds(Random.Range(spawnLeastWait, spawnMostWait));
        circle = Instantiate(circlePrefab) as GameObject;
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
        circle.transform.position = spawnPosition;
        stop = false;
    }
}

    public void ReturnButton()
    {
        if (destroyCount > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", destroyCount);
        }
        SceneManager.LoadScene("MenuScene");
    }
}

