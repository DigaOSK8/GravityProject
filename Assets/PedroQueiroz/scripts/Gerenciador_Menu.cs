using UnityEngine;
using System.Collections;

public class Gerenciador_Menu : MonoBehaviour {

    public GameObject inicial;
    public GameObject credits;

	// Use this for initialization
	void Start () {
        inicial.SetActive(true);
    }

    #region Credits

    public void btn_Credits_Back()
    {
        inicial.SetActive(true);
        credits.SetActive(false);
    }

    #endregion

    #region Inicial

    public void btn_Inicial_PlayGame()
    {
        credits.SetActive(false);
        inicial.SetActive(false);
    }

    public void btn_Inial_Credits()
    {
        credits.SetActive(true);
        inicial.SetActive(false);
    }

    public void btn_Inicial_Exit()
    {
        Application.Quit();
    }

    #endregion





}
