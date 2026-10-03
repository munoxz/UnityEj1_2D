using UnityEngine;

public class ObjectRecolector : MonoBehaviour
{
    // Valor de puntuación otorgado por este objeto recolectable
    public int scoreValue = 10;

    // Bocina propia de este objeto (está en el mismo prefab)
    public AudioSource audioSource;

    // Sonido que suena al recoger este objeto
    public AudioClip audioClip;

    void Start()
    {
        // Toma el Audio Source que tiene este mismo objeto
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo reacciona si lo que entró es el jugador
        if (collision.CompareTag("Player"))
        {
            // Sonido: detener si algo suena, poner el clip y reproducir
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();

            GetComponent<SpriteRenderer>().enabled = false; // Oculta el objeto recolectable
            GetComponent<Collider2D>().enabled = false;     // Desactiva el collider para evitar múltiples colisiones

            Debug.Log("Objeto recolectado por el jugador");

            if (GameManager.instance != null)
                GameManager.instance.AddScore(scoreValue);

            // Le avisa al controlador de la escena que se recogió un objeto.
            // Así SendTime() se llama solo cuando pasa algo, no en cada frame.
            ControllerScene1 controller1 = FindFirstObjectByType<ControllerScene1>();
            if (controller1 != null) controller1.SendTime();

            ControllerScene2 controller2 = FindFirstObjectByType<ControllerScene2>();
            if (controller2 != null) controller2.SendTime();

            // Destruye el objeto 4 segundos después, para que alcance a sonar
            Destroy(gameObject, 4f);
        }
    }
}
