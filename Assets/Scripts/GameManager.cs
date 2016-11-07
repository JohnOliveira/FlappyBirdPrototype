using UnityEngine;
using System.Collections;

public enum GameScenes
{
    TITLE,
    TUTORIAL,
    INGAME,
    GAMEOVER
}

public class GameManager : MonoBehaviour
{
    private GameScenes scenes;

    private Flappy flappy;
    private SoundManager soundManager;
    private Panel panel;
    private Vector3 startPosition;

    public GameObject playerObj;
    public GameObject hudObj;
    public GameObject tutorialObj;
    public GameObject gameOverObj;
    public GameObject titleObj;

	void Start ()
    {
        PlayerPrefs.DeleteAll();
        scenes = GameScenes.TITLE;

        flappy = FindObjectOfType(typeof(Flappy)) as Flappy;
        soundManager = FindObjectOfType(typeof(SoundManager)) as SoundManager;
        panel = FindObjectOfType(typeof(Panel)) as Panel;
	}
	void Update ()
    {
	    switch (scenes)
        {
            case GameScenes.TITLE:
                Title();
                break;
            case GameScenes.TUTORIAL:
                Tutorial();
                break;
            case GameScenes.INGAME:
                InGame();
                break;
            case GameScenes.GAMEOVER:
                GameOver();
                break;
        }
	}
    private void Title()
    {
        titleObj.SetActive(true);
        tutorialObj.SetActive(false);
        gameOverObj.SetActive(false);

        playerObj.SetActive(false);
        hudObj.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            playerObj.SetActive(true);
            startPosition = playerObj.transform.position;
            titleObj.SetActive(false);
            tutorialObj.SetActive(true);
            soundManager.Title();

            scenes = GameScenes.TUTORIAL;
        }
    }
    private void Tutorial()
    {
        playerObj.transform.position = startPosition;
        playerObj.transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            hudObj.SetActive(true);
            tutorialObj.SetActive(false);

            scenes = GameScenes.INGAME;
        }
    }
    private void InGame()
    {

    }
    private void GameOver()
    {
        hudObj.SetActive(false);
        gameOverObj.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            Pipes[] pipes = FindObjectsOfType(typeof(Pipes)) as Pipes[];
            foreach (Pipes p in pipes)
            {
                p.gameObject.SetActive(false);
            }
            flappy.RestartScore();
            tutorialObj.SetActive(true);
            hudObj.SetActive(false);
            gameOverObj.SetActive(false);

            scenes = GameScenes.TUTORIAL;
        }
    }
    //-----------------------------------
    public GameScenes CurrentScene()
    {
        return scenes;
    }
    public void SetTitle() { scenes = GameScenes.TITLE; }
    public void SetTutorial() { scenes = GameScenes.TUTORIAL; }
    public void SetInGame() { scenes = GameScenes.INGAME; }
    public void SetGameOver() { scenes = GameScenes.GAMEOVER; }
}