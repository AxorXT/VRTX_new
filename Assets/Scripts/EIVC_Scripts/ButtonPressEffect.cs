using System.Collections;  // Aseg�rate de importar System.Collections
using UnityEngine;

public class ButtonPressEffect : MonoBehaviour
{
    private Vector3 originalScale;
    public Vector3 pressedScale = new Vector3(0.9f, 0.9f, 0.9f); // Escala cuando el bot�n se presiona
    public float pressDuration = 0.1f; // Duraci�n de la presi�n

    void Start()
    {
        originalScale = transform.localScale;  // Guarda la escala original del bot�n
    }

    // Se llama cuando otro objeto entra en el �rea del collider (Trigger)
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entr� es el personaje (puedes usar un tag o nombre de objeto)
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();  // Detenemos cualquier corutina en curso
            StartCoroutine(PressButton());  // Llamamos a la corutina para presionar el bot�n
        }
    }

    // Se llama cuando el objeto sale del �rea del collider (Trigger)
    void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto que sali� es el personaje
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;  // Restauramos el tama�o original
        }
    }

    // Corutina que cambia la escala del bot�n temporalmente para simular el efecto de presi�n
    IEnumerator PressButton()
    {
        transform.localScale = pressedScale;  // Reducimos el tama�o para simular la presi�n
        yield return new WaitForSeconds(pressDuration);  // Esperamos un breve momento
        transform.localScale = originalScale;  // Restauramos el tama�o original
    }
}
