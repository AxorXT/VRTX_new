using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    public Camera playerCamera;         // C�mara del jugador desde la cual se lanza el raycast
    public TextMeshProUGUI timerText;   // Texto en UI para mostrar el tiempo
    public float timeRemaining = 0f;    // Tiempo restante del cron�metro
    private bool timerRunning = false;  // Controla si el cron�metro est� en marcha

    void Update()
    {
        // Detectar si el jugador hace clic
        if (Input.GetMouseButtonDown(0))
        {
            // Lanzamos un raycast desde el centro de la c�mara
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto golpeado tiene la etiqueta "Interactable"
                if (hit.transform.CompareTag("buttonObject") && !timerRunning)
                {
                    StartTimer();  // Iniciar cron�metro si se hace clic en el objeto interactivo
                }
            }
        }

        // Si el cron�metro est� en marcha, actualiza el tiempo
        if (timerRunning)
        {
            timeRemaining += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    // M�todo para iniciar el cron�metro
    void StartTimer()
    {
        timerRunning = true;
        timeRemaining = 0f; // Reinicia el tiempo cuando comienza el cron�metro
    }

    // M�todo para actualizar el texto del cron�metro en la UI
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Tiempo: " + timeRemaining.ToString("F2") + " segundos";
        }
    }

    // M�todo para detener el cron�metro (lo puedes llamar cuando llegues a una meta)
    public void StopTimer()
    {
        timerRunning = false;
        Debug.Log("Cron�metro detenido. Tiempo total: " + timeRemaining + " segundos.");
    }

    // M�todo para reiniciar el cron�metro (lo puedes llamar cuando el jugador muera)
    public void ResetTimer()
    {
        timerRunning = false;  // Detener el cron�metro
        timeRemaining = 0f;    // Reiniciar el tiempo a cero
        UpdateTimerDisplay();  // Actualizar el texto en pantalla
    }
}