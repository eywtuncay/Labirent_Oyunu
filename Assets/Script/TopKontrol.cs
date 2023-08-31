using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
    private float Hiz = 4.5f;
    float zamanSayaci = 20;
    int canSayaci=5;
    bool oyunDevam=true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam) { 
        zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci + "";
        }
        else if(!oyunTamam)
        {
            durum.text = "OYUN TAMAMLANAMADI!";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
    }

    private void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam) { 
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvet = new Vector3(dikey,0,-yatay);
        rg.AddForce(kuvet*Hiz);
        }
        else
        {
            rg.velocity = Vector3.zero;         // oyun bitince topu hareketsiz duruma sokar
            rg.angularVelocity = Vector3.zero;  // oyun bitince topu hareketsiz duruma sokar
        }

    }

    private void OnCollisionEnter(Collision cls)
    {
        string objeIsmi = cls.gameObject.name;
        if (objeIsmi.Equals ("bitis"))
        {
            //print("Oyun Tamamlandý.");
            oyunTamam = true;
            durum.text = "OYUN TAMAMLANDI TEBRÝKLER!";
            btn.gameObject.SetActive(true);
        }
        else if(!objeIsmi.Equals("parkurZemini"))
        {
            canSayaci -= 1;
            can.text = canSayaci+"";
            if (canSayaci ==0)
            {
                oyunDevam = false;
            }
        }
    }

}


