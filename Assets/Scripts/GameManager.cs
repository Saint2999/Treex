using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public GameObject gameOverUI;

    public PauseMenu pauseMenu;

    public void Start()
    {
        pauseMenu.Resume();
        Time.timeScale = 1f;

    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            
            gameHasEnded = true;
            Debug.Log("Game over!");
            gameOverUI.SetActive(true);
            
        }
    }

}