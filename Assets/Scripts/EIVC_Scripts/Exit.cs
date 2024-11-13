using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Exit : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        // Aseg�rate de que el bot�n est� asignado
        if (exitButton != null)
        {
            // Asocia la funci�n que se llamar� al hacer clic en el bot�n
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }
    }

    // Funci�n llamada cuando se presiona el bot�n "Exit"
    void OnExitButtonClicked()
    {
        // Si estamos en el editor de Unity, detendremos el juego
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        
#endif
    }
}
