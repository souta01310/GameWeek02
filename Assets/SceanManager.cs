using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanManager : MonoBehaviour
{
    public void ChangeScean(string scaneName)
    {
        SceneManager.LoadScene("Game");
    }
}
