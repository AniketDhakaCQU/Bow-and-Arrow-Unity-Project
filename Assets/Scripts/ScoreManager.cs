using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text levelText;
    public int score = 0;
    public int level = 1;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);      // Keep this around so we can maintain our levels
    }

    void Start()
    {
        UpdateScoreText();
        UpdateLevelText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        if (score == 50)
        {
            LoadNextScene();
        } else if (score == 100) {
            LoadNextScene();
        } else if (score == 150) {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // level++;
        // UpdateLevelText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLevelText()
    {
        levelText.text = "Level: " + level;
    }
}