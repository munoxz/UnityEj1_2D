using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControllerScene1 : MonoBehaviour
{
    // Texto del panel donde se muestra el puntaje
    public TextMeshProUGUI scoreText;

    // Timer de la escena 1 (el que está en PanelTiempo)
    public Timer timerScene1;

    // Escena a la que se pasa al terminar
    public string nextScene = "Escena2";

    void Update()
    {
        // El Update solo actualiza el texto del puntaje
        if (GameManager.instance != null)
            scoreText.text = "Score: " + GameManager.instance.Score;
    }

    // Lo llama cada objeto recolectable cuando el jugador lo recoge
    public void SendTime()
    {
        if (GameManager.instance.Score >= 100)
        {
            timerScene1.TimerStop();                 // 1. parar el tiempo
            float time = timerScene1.StopTime;       // 2. obtener el tiempo
            GameManager.instance.AddTime(time);      // 3. enviarlo al Game Manager

            Invoke(nameof(NextScene), 1f);           // 4. pasar a la escena 2 después de 1 segundo
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
