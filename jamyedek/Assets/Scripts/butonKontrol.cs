using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class butonKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public static butonKontrol Instance;
    [SerializeField] GameObject oynaPanel;
    [SerializeField] GameObject soruisaretiPanel;
    [SerializeField] GameObject video;//baslangýç
    [SerializeField] GameObject sumolasýPanel;
    [SerializeField] GameObject gecisVideo;
    [SerializeField] AudioSource ses;


    public static int sayac = 0;
    private bool muteKontrol = false;
    private void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        
        //42saniye
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void videoKapat()//basalangýc videosu
    {
        video.SetActive(false);
        ses.mute = false;


    }

    public void oynabtnFonk()
    {
        sayac++;
        video.SetActive(true);
        ses.mute=true;
        Invoke("videoKapat", 42f);
        Invoke("gecisVideoFonk", 41f);
        Invoke("gecisVideoKapat", 50f);

        oynaPanel.SetActive(false);


    }
    public void soruisaretiFonk()
    {
        soruisaretiPanel.SetActive(true);
    }
    public void soruisaretkapatFonk()
    {
        soruisaretiPanel.SetActive(false);

    }
    public void cikisFonk()
    {
        Application.Quit();
    }

    public void durdur()
    {
        Time.timeScale = 0;
        sumolasýPanel.SetActive(true);
    }
    public void devamet()
    {
        Time.timeScale = 1;
        sumolasýPanel.SetActive(false);

    }
    public void gecisVideoFonk()
    {
        gecisVideo.SetActive(true);
    }
    public void gecisVideoKapat()
    {
        gecisVideo.SetActive(false);
    }
    public void hataDuzeltma()
    {
        oynaPanel.SetActive(false);

    }
    public void sessizeal()
    {
        ses.mute = false;
    }
    public void gecisVideoFonkbolum3()
    {
        ses.mute = true;

        //Invoke("gecisVideoFonk",21);
    }
    public void muteunnmutefonk()
    {
        if (muteKontrol==false)
        {
            
            ses.mute = false;
            muteKontrol = true;
        }
        else if (muteKontrol == true)
        {
          

            ses.mute = true;
            muteKontrol=false;
        }
    }
}
