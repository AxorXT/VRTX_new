using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class SceneLoader : MonoBehaviour
{
    // Este m�todo puede ser llamado desde el bot�n
    public void LoadLevel1()
    {
        // Cambia "Level1" por el nombre exacto de tu escena
        SceneManager.LoadScene("Level1");
    }
}
