using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) UnityEngine.Application.Quit();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Calculate.execute = !Calculate.execute;
            Calculate.infinity = !Calculate.infinity;
        }
    }
}
