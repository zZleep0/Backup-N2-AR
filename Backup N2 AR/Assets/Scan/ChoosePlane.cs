using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlane : MonoBehaviour
{
    public int activeScene;
    public GameObject plane;
    public CarManager spawner;

    public GameObject[] planePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            DefinirAviao();
        }
    }

    void DefinirAviao()
    {
        spawner = GameObject.Find("Car Spawner").GetComponent<CarManager>();
        spawner.CarPrefab = plane;
    }

    public void Aviao1()
    {
        plane = planePrefab[0];
        SceneManager.LoadScene("Testes");
    }
    public void Aviao2()
    {
        plane = planePrefab[1];
        SceneManager.LoadScene("Testes");
    }
    public void Aviao3()
    {
        plane = planePrefab[2];
        SceneManager.LoadScene("Testes");
    }
}
