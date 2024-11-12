using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnCollision : MonoBehaviour
{
    public Transform playerStartPosition; // Posici�n de inicio donde el jugador ser� regresado
    public GameObject playerObject;      // El objeto vac�o que contiene al jugador (por ejemplo, "Player")
    public PlayerTime playerTime;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reiniciar el cron�metro cuando el jugador muera
            if (playerTime != null)
            {
                playerTime.ResetTimer();
            }

            // Llamar al m�todo que mata al jugador y lo regresa a la posici�n inicial
            RespawnPlayer(collision.gameObject);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        // Desactivar el objeto principal del jugador (Player)
        player.SetActive(false);  // Desactiva todo el objeto principal (Player)

        // Reposicionar al jugador en la posici�n de inicio
        player.transform.position = playerStartPosition.position;

        // Reactivar el jugador despu�s de un peque�o retraso (si se desea un efecto visual)
        Invoke(nameof(ReactivatePlayer), 1f);  // Espera 1 segundo antes de reactivar
    }

    private void ReactivatePlayer()
    {
        // Buscar el objeto "Player" y reactivarlo
        if (playerObject != null)
        {
            playerObject.SetActive(true);  // Reactivar el objeto principal del jugador
        }
    }
}
