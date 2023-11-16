using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour{
    /* This script sets the main menu up for operation, but I couldnt find a way for the game to unload 
     * the game scene because the game scene would lock your mouse to the center of the screen and the 
     * buttons in the main menu dont work, so I just decided that the main menu would just show up when
     * you first launch the game.
     */
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}

