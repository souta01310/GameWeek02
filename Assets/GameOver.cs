using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganmeover : MonoBehaviour
{
    [Header("タグ")]
    [SerializeField] private string targetTag = "Player"; // 反応するタグ

    private string methodName = "Hit";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("c");
            // このオブジェクトのコンポーネントからメソッドを呼び出す
            SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
        }
    }
    public void Hit()
    {
        Debug.Log("H");
        SceneManager.LoadScene("Title");
    }
}
