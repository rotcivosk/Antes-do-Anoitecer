using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene"); // Carrega a cena principal
    }

    public void ContinueGame()
    {
        // Lógica para continuar pode ser implementada aqui (exemplo: carregar dados salvos)
        Debug.Log("Continuar jogo - Implementar sistema de save");
    }

    public void OpenSettings()
    {
        Debug.Log("Abrir configurações - Implementar sistema de opções");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Sair do jogo"); // Mensagem aparece no editor, mas não afeta o build final
    }
}