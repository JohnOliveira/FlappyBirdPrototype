using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipesSpawn : MonoBehaviour
{
    private GameManager gameManager;

    private List<GameObject> pipesList;
    private float timer;
    private float interval;
    private float Ypos;

    public GameObject prefab;
    public float minHeight;
    public float maxHeight;

	void Start ()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

        timer = 0f;
        interval = 1f;

        pipesList = new List<GameObject>();

	    for (int i = 0; i <5; i++)
        {
            GameObject newPrefab = Instantiate(prefab) as GameObject;
            pipesList.Add(newPrefab);
            newPrefab.SetActive(false);
        }
	}
    void Update()
    {
        if (gameManager.CurrentScene() != GameScenes.INGAME)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer > interval)
        {
            Spawn();
            timer = 0f;
        }
	}
    private void Spawn()
    {
        GameObject tempPrefab = null;
        
        Ypos = Random.Range(minHeight, maxHeight);

        for (int i = 0; i < 5; i++)
        {
            if (!pipesList[i].activeSelf)
            {
                tempPrefab = pipesList[i];
                break;
            }
        }
        if (tempPrefab != null)
        {
            tempPrefab.transform.position = new Vector3
                (transform.position.x, Ypos, transform.position.z);

            tempPrefab.SetActive(true);
        }
    }
}