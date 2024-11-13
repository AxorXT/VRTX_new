using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    // Velocidad de rotaci�n en grados por segundo
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Gira el objeto alrededor del eje Y (puedes cambiar los ejes X, Y, Z seg�n necesites)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
