using System.Collections;
<<<<<<< HEAD

using UnityEngine;
using UnityEngine.SceneManagement;

=======
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
>>>>>>> origin/main



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]Animator transitionAnim;
    [SerializeField] private GameObject gameOverPrefab; // Đối tượng prefab GameOver
<<<<<<< HEAD
    [SerializeField] private GameObject pauseMenuPrefab;
    private GameOver gameOverUI;
    private PauseMenu pauseMenu;
=======
    private GameOver gameOverUI;
>>>>>>> origin/main

    public int level { get; private set; } = 0;
    public int score { get; private set; } = 0;
    public int highScore { get; private set; } = 0;



    private void Awake()
    {
        if (Instance != null)
        {
<<<<<<< HEAD
            Destroy(gameObject);
=======
            DestroyImmediate(gameObject);
>>>>>>> origin/main
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        NewGame();
       

    }

    public void NewGame()
    {
        
        ResetScore();
<<<<<<< HEAD
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (gameOverUI != null)
        {
            gameOverUI.ResetGameOverUI(); // Đảm bảo giao diện game over được ẩn
        } 
=======
        if (gameOverUI != null)
        {
            gameOverUI.ResetGameOverUI(); // Đảm bảo giao diện game over được ẩn
        }
>>>>>>> origin/main
        FindObjectOfType<player>().UpdateScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
        FindObjectOfType<player>().UpdateScoreUI();
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    public void IncreaseScore(int point)
    {
        score += point;
        if(score > highScore)
        {
            highScore = score;
<<<<<<< HEAD
            PlayerPrefs.SetInt("HighScore", highScore);
=======
>>>>>>> origin/main
        }
        FindObjectOfType<player>().UpdateScoreUI();
    }

<<<<<<< HEAD
    void OnApplicationQuit()
    {
        // Lưu điểm cao nhất khi thoát trò chơi
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

=======
>>>>>>> origin/main
    public void GameOver()
    {
        if (gameOverUI == null)
        {
            gameOverUI = Instantiate(gameOverPrefab).GetComponent<GameOver>();
            DontDestroyOnLoad(gameOverUI.gameObject); // Giữ gameOverUI không bị hủy
        }
        gameOverUI.gameOver(); // Hiển thị giao diện game over
    }

<<<<<<< HEAD
    public void PauseMenu()
    {
        if (pauseMenu == null)
        {
            pauseMenu = Instantiate(pauseMenuPrefab).GetComponent<PauseMenu>();
            DontDestroyOnLoad(pauseMenu.gameObject); // Giữ gameOverUI không bị hủy
        }
        pauseMenu.Pause(); // Hiển thị giao diện game over
    }
=======
>>>>>>> origin/main
    
}
