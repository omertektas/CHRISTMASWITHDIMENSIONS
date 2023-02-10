using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject yanlisCevap;
    [SerializeField] GameObject sonrakivideo;

    TextMeshProUGUI skorText;
    Vector3 sabitHareket;
    private float yatayHiz;
    private float x;
    private byte skorSayac;

    void Start()
    {
        skorText=GameObject.Find("Canvas/skorText").GetComponent<TextMeshProUGUI>();    
        skorSayac = 0;
        yatayHiz = 0.3f;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        sabitHareket = new Vector3(0, -50 * Time.deltaTime,0 );
        transform.Translate(sabitHareket);
        x = Mathf.Clamp(transform.position.z, -16, 16);
        float h = yatayHiz * Input.GetAxis("Horizontal");      
        transform.position = new Vector3(transform.position.x,transform.position.y,x);  
        transform.Translate(h, 0,0); 
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="engelBolum3")
        {
            yanlisCevap.SetActive(true);
            Invoke("olmeFonk3", 1);

        }
        if (collision.gameObject.tag == "hediyeBolum3")
        {
            skorSayac++;
            skorText.text = skorSayac.ToString();

            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag=="bitiscizgisi")
        {
            if (skorSayac == 10)
            {
                butonKontrol.Instance.sessizeal();
                sonrakivideo.SetActive(true);
                butonKontrol.Instance.gecisVideoFonkbolum3();
                Invoke("bolum4gecis", 21f);
            }
            else
            {
                yanlisCevap.SetActive(true);
                Invoke("olmeFonk3", 1);
            }
            
        }
    }
    private void olmeFonk3()
    {
        SceneManager.LoadScene(1);//1.index bolum3

    }
    private void bolum4gecis()
    {
        SceneManager.LoadScene(2);//1.index bolum3

    }

}
