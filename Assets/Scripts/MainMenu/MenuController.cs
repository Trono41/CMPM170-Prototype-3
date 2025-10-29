using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string scene1;
    public string scene2;
    public string scene3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(scene1);
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene(scene2);
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene(scene3);
    }
}
