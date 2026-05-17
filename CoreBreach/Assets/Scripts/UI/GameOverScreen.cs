using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        // Başlangıçta her iki panel de gizli
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        // Restart butonu GameManager.Restart'ı çağırsın
        restartButton.onClick.AddListener(() => GameManager.Instance.Restart());
    }

    private void OnEnable()
    {
        GameEvents.OnCoreDestroyed += HandleLose;
        GameEvents.OnAllWavesCompleted += HandleWin;
    }

    private void OnDisable()
    {
        GameEvents.OnCoreDestroyed -= HandleLose;
        GameEvents.OnAllWavesCompleted -= HandleWin;
    }

    private void HandleLose()
    {
        Debug.Log("ShowLose CALISTI");
        losePanel.SetActive(true);
        finalScoreText.text = $"SCORE: {GameManager.Instance.Score}";
    }

    private void HandleWin()
    {
        Debug.Log("ShowWin CALISTI");
        winPanel.SetActive(true);
        finalScoreText.text = $"SCORE: {GameManager.Instance.Score}";
    }
}