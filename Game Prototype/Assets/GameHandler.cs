using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private bool paused = false;
    private bool muted = false;
    private bool optionsMenuBool = false;
    public int difficulty = 2;
    int easy = 2;
    int hard = 4;
    public Text PauseText;
    public AudioSource backgroundAudio;
    public Slider volumeSlider;
    public Image optionsMenu;
    public GameObject WorldTiles;
    public Text DifficultyText;
    public int score = 0;
    public Text scoreText;
    public int hearts = 5;
    public Text heartsText;
    public Text DefeatText;
    private void Awake()
    {
        DefeatText.enabled = false;
        PauseText.enabled = false;
        optionsMenu.gameObject.SetActive(false);
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;
        heartsText.text = "Hearts: " + hearts;
        if (hearts <= 0)
        {
            DefeatText.enabled = true;
            StartCoroutine(resetScene());
        }
        // Pause
        if (Input.GetKeyDown(KeyCode.P))
        { // Press P
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;
            if (paused)
            {
                backgroundAudio.Pause();
            }
            else
            {
                backgroundAudio.Play();
            }
            PauseText.enabled = paused;
        }
        // Mute 
        if (Input.GetKeyDown(KeyCode.O))
        { // Press O
            muted = !muted;
            AudioListener.volume = muted ? 0f : 1f;
        }
        // Options Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        { // Press Escape
            WorldTiles.tag = "Paused";
            DifficultyText.text = "Difficulty: " + ((difficulty == easy) ? "Easy" : "Hard");
            optionsMenuBool = !optionsMenuBool;
            optionsMenu.gameObject.SetActive(optionsMenuBool);
        }
        if (optionsMenuBool == false)
        {
            WorldTiles.tag = "Untagged";
        }
    }
    // Slider Volume
    void OnGUI()
    {
        backgroundAudio.volume = volumeSlider.value;
        DifficultyText.text = "Difficulty: " + ((difficulty == easy) ? "Easy" : "Hard");
    }
    public void muteAudio()
    {
        muted = !muted;
        AudioListener.volume = muted ? 0f : 1f;
    }
    public void changeDifficulty()
    {
        difficulty = (difficulty == easy) ? hard : easy;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator resetScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
