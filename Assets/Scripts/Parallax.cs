using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    private GameManager gameManager;

    private Material currentMat;
    private float offSet;

    public float speed;

	void Start ()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

        currentMat = GetComponent<Renderer>().material;
	}
	void Update ()
    {
        if (gameManager.CurrentScene() == GameScenes.GAMEOVER)
        {
            return;
        }

        offSet += 0.001f * Time.deltaTime;

        currentMat.SetTextureOffset("_MainTex", new Vector2(speed * offSet, 0));
	}
}