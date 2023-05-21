using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareketi : MonoBehaviour
{

    Vector3 y�n;
    public float hiz;
    public ZeminSpawner zeminspawnerscript;
    public static bool dustu_mu;
    public float eklenecekHiz;
    public GameObject youLose_panel;

    void Start()
    {
        y�n = Vector3.forward;
        dustu_mu = false;
    }


    void Update()
    {
        if (transform.position.y <= -1.0f)
        {
            dustu_mu = true;
        }
        if (dustu_mu == true)
        {
            youLose_panel.SetActive(true);
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (y�n.x == 0)
            {
                y�n = Vector3.left;
            }
            else
            {
                y�n = Vector3.forward;
            }

            hiz += eklenecekHiz * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector3 hareket = y�n * Time.deltaTime * hiz;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            Skor.skor++;
            collision.gameObject.AddComponent<Rigidbody>();
            zeminspawnerscript.zemin_olustur();
            StartCoroutine(ZeminiSil(collision.gameObject));
        }
    }

    IEnumerator ZeminiSil(GameObject SilinecekZemin)
    {
        yield return new WaitForSeconds(3f);
        Destroy(SilinecekZemin);
    }
    
}
