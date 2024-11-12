using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLados : MonoBehaviour
{
    [System.Serializable]
    public class MovableObject
    {
        public Transform objectToMove; // Objeto a mover
        public Transform pointA;       // Primer punto de destino
        public Transform pointB;       // Segundo punto de destino
        public float speed = 2f;       // Velocidad de movimiento
        [HideInInspector] public float t = 0f;  // Variable de interpolaci�n
        [HideInInspector] public bool movingToB = true; // Direcci�n de movimiento
    }

    public List<MovableObject> objectsToMove; // Lista de objetos a mover

    void Update()
    {
        // Itera a trav�s de cada objeto en la lista
        foreach (var movableObject in objectsToMove)
        {
            // Movimiento hacia el punto B
            if (movableObject.movingToB)
            {
                movableObject.t += Time.deltaTime * movableObject.speed;
                if (movableObject.t >= 1f)
                {
                    movableObject.t = 1f;
                    movableObject.movingToB = false; // Cambiar direcci�n
                }
            }
            else // Movimiento hacia el punto A
            {
                movableObject.t -= Time.deltaTime * movableObject.speed;
                if (movableObject.t <= 0f)
                {
                    movableObject.t = 0f;
                    movableObject.movingToB = true; // Cambiar direcci�n
                }
            }

            // Interpolaci�n de posici�n entre pointA y pointB
            if (movableObject.objectToMove != null && movableObject.pointA != null && movableObject.pointB != null)
            {
                movableObject.objectToMove.position = Vector3.Lerp(movableObject.pointA.position, movableObject.pointB.position, movableObject.t);
            }
        }
    }
}
