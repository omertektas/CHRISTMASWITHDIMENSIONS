using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolum2 : MonoBehaviour
{
    [SerializeField] GameObject yanlisPanel;
    [SerializeField] GameObject eskiKapi;
    [SerializeField] GameObject yeniKapi;
    [SerializeField] GameObject anahtar;
    Rigidbody2D rb;
    private float hiz;
    public float ziplamaHizi;
    private bool ziplamaKontrol=false;
    public static bool kontrol;
    public static bool kontrol2;
    Vector2 up;
    void Start()
    {
        kontrol=false;
            kontrol = true;

        rb = GetComponent<Rigidbody2D>();
        hiz = 4f;
        if (butonKontrol.sayac!=0)
        {
            kontrol=false;
            butonKontrol.Instance.hataDuzeltma();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        
        float h = hiz * Input.GetAxis("Horizontal");
        transform.Translate(h*Time.deltaTime, 0,0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ziplamaKontrol==false)
            {
                rb.AddForce(Vector2.up * ziplamaHizi);
                ziplamaKontrol = true;
            }


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="engel")
        {
            ziplamaKontrol = false;

        }
        if (collision.gameObject.tag == "bolum2engel")//yanma fonk
        {
            kontrol = false;
            yanlisPanel.SetActive(true);
            Invoke("olmeFonk", 2);
        butonKontrol.Instance.hataDuzeltma();



        }
        if (collision.gameObject.tag=="bolum2Kapi")
        {
            if (kontrol2==true)
            {
                butonKontrol.Instance.gecisVideoFonk();
                Invoke("gecisFonk", 8f);
            }
            

        }
        if (collision.gameObject.tag == "bolum2Anahtar")
        {
            kontrol2 = true;
            anahtar.SetActive(false);
            eskiKapi.SetActive(false);
            yeniKapi.SetActive(true);
        }
    }

    private void olmeFonk()
    {
        SceneManager.LoadScene(0);//0.index bolum2

    }
    private void gecisFonk()
    {
            SceneManager.LoadScene(1);//1.index bolum3

    }
}
