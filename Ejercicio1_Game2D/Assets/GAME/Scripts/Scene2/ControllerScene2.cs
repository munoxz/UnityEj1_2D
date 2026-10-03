using UnityEngine;
using TMPro;

public class ControllerScene2 : MonoBehaviour
{
    // Texto del panel donde se muestra el puntaje
    public TextMeshProUGUI scoreText;

    // Timer de la escena 2 (el que está en PanelTiempo)
    public Timer timerScene2;

    // Panel final y sus textos
    public GameObject panelFinal;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalTimeText;

    // Puntos que hay que ganar en esta escena para terminar
    public int pointsToFinish = 100;

    // Score con el que se llegó a esta escena
    private int scoreAtStart = 0;

    void Start()
    {
        if (GameManager.instance != null)
            scoreAtStart = GameManager.instance.Score;

        panelFinal.SetActive(false);
    }

    void Update()
    {
        if (GameManager.instance != null)
            scoreText.text = "Score: " + GameManager.instance.Score;
    }

    // Lo llama cada objeto recolectable cuando el jugador lo recoge
    public void SendTime()
    {
        // Puntos ganados solo en esta escena
        int pointsInScene = GameManager.instance.Score - scoreAtStart;

        if (pointsInScene >= pointsToFinish)
        {
            timerScene2.TimerStop();                          // 1. parar el tiempo
            GameManager.instance.AddTime(timerScene2.StopTime); // 2. sumarlo al tiempo total

            // 3. mostrar el panel final con los totales
            panelFinal.SetActive(true);
            finalScoreText.text = "Score total: " + GameManager.instance.Score;
            finalTimeText.text = "Tiempo total: " + GameManager.instance.TotalTime.ToString("F2") + " s";
        }
    }
}
