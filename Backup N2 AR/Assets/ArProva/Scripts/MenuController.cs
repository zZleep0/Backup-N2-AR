using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Refer�ncias aos bot�es
    public Button Jogar;
    public Button Sair;
    


    void Start()
    {
        // Atribui as fun��es aos bot�es
        Jogar.onClick.AddListener(PlayGame);
        Sair.onClick.AddListener(ExitGame);
        

    }

    // Fun��o para trocar para a cena do jogo
    void PlayGame()
    {
        SceneManager.LoadScene("ArProva");
    }

   

    // Fun��o para sair do jogo
    void ExitGame()
    {
        Debug.Log("Sair do jogo...");
        Application.Quit();
    }
}