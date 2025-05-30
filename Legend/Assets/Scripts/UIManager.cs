using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthGlobe, manaGlobe;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject gameOverScreen;

    private void OnEnable()
    {
        PlayerLevel.OnXPUpdated += UpdateXPSlider;
        PlayerLevel.OnVictory += ShowVictoryScreen;
    }

    private void OnDisable()
    {
        PlayerLevel.OnXPUpdated -= UpdateXPSlider;
        PlayerLevel.OnVictory -= ShowVictoryScreen;
    }

    private void Update()
    {
        healthGlobe.fillAmount = playerHealth.GetHealthRatio();
    }

    private void UpdateXPSlider(float ratio)
    {
        xpSlider.value = ratio;
    }
    private void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}