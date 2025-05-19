using UnityEngine;

public class BalaController : MonoBehaviour
{
    private Rigidbody fis;
    public float velocidade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fis = GetComponent<Rigidbody>();
        fis.AddForce(transform.forward * velocidade, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Debug.Log("Atingiu o aviao inimigo");
            CarBehaviour car = GameObject.Find("aircraft-a(Clone)").GetComponent<CarBehaviour>();
            car.pontos += 50;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
