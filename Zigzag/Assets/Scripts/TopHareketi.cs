using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareketi : MonoBehaviour
{

    Vector3 yön;
    public float hiz;
    public ZeminSpawner zeminspawnerscript;
    public static bool dustu_mu;
    public float eklenecekHiz;
    public GameObject youLose_panel;

    void Start()
    {
        yön = Vector3.forward;
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
            if (yön.x == 0)
            {
                yön = Vector3.left;
            }
            else
            {
                yön = Vector3.forward;
            }

            hiz += eklenecekHiz * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector3 hareket = yön * Time.deltaTime * hiz;
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
