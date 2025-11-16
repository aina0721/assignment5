using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_TitleBack()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnClick_PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}
