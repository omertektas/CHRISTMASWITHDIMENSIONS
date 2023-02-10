using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;

public class level4 : MonoBehaviour
{
    [SerializeField] float hareketHizi;
    [SerializeField] float fareHassasiyeti;
    [SerializeField] GameObject hediye1;
    [SerializeField] GameObject hediye2;
    [SerializeField] GameObject hediye3;
    [SerializeField] GameObject hediye4;
    [SerializeField] GameObject hediye5;
    [SerializeField] GameObject hediye6;
    [SerializeField] GameObject hediye7;
    [SerializeField] GameObject hediye8;
    [SerializeField] GameObject hediye9;
    [SerializeField] GameObject hediye10;
    [SerializeField] GameObject bolumsonuvideo;
    [SerializeField] AudioSource ses;
    [SerializeField] GameObject text;
    [SerializeField] GameObject genelbitis;

    public Camera fpsCam;
    Vector3 direction;
    Rigidbody rb;
    float mouseX,mouseY;    
    float rotX, rotY;
    private bool sayac1;
    private bool sayac2;
    private bool sayac3;
    private bool sayac4;
    private bool sayac5;
    private bool sayac6;
    private bool sayac7;
    void Start()
    {
     sayac1 = false;
     sayac2 = false;
     sayac3 = false;
     sayac4 = false;
     sayac5 = false;
     sayac6 = false;
     sayac7 = false;
    Invoke("baslangictext", 10);
            rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * fareHassasiyeti;
        mouseY = Input.GetAxis("Mouse Y")*Time.deltaTime*fareHassasiyeti;
        rotX-=mouseY;
        rotX = Mathf.Clamp(rotX, -20, 20);
        rotY += mouseX;
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }
    private void LateUpdate()
    {
       fpsCam.transform.localRotation=Quaternion.Euler(rotX, 0, 0);
    }
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        direction = new Vector3(hor,0, ver);
        rb.MovePosition(transform.position+transform.TransformDirection(direction*Time.deltaTime*hareketHizi));
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag=="target1")
        {
            sayac1 = true;
           hediye1.SetActive(true);
        }
        if (collision.gameObject.tag == "target2")
        {
            sayac2 = true;  

            hediye2.SetActive(true);
            hediye3.SetActive(true);
            hediye4.SetActive(true);
        }
        if (collision.gameObject.tag == "target3")
        {
            sayac3 = true;


            hediye5.SetActive(true);
        }
        if (collision.gameObject.tag == "target4")
        {
            sayac4 = true;

            hediye6.SetActive(true);


        }
        if (collision.gameObject.tag == "target5")
        {
            sayac5 = true;

            hediye7.SetActive(true);
        }
        if (collision.gameObject.tag == "target6")
        {
            sayac6 = true;  

            hediye8.SetActive(true);
        }
        if (collision.gameObject.tag == "target7")
        {
           sayac7= true;    

            hediye9.SetActive(true);
            hediye10.SetActive(true);

        }
        if (sayac1==true && sayac2 == true && sayac3 == true && sayac4 == true && sayac5 == true && sayac6 == true && sayac7 == true) 
        {
            
            Invoke("sonvideo", 2f);
        }
        
        

    }
    private void sonvideo()
    {
        ses.mute = true;
        bolumsonuvideo.SetActive(true);
        Invoke("genelson", 8f);
    }
    private void baslangictext()
    {
        text.SetActive(false);
    }
    private void genelson()
    {
        genelbitis.SetActive(true);
        Invoke("quitfonk", 10f);

    }
    private void quitfonk()
    {
        Application.Quit();
    }
}
