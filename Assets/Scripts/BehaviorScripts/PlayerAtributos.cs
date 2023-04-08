using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAtributos : MonoBehaviour
{
   public int vida = 3;
   public int limitedevida;
    bool morreu;

    public Text municao;
    public Slider lifeBar;
    
    public void Start()
   {

        municao.text = "";
        //vidaInimigo.text = "";

        lifeBar.maxValue = vida;
        lifeBar.value = vida;
    }

    private void Update()
    {
        lifeBar.value = vida;
        municao.text = GetComponent<TPMovimento>().municao.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projetil"))
        {
            if (other.gameObject.name == "ColisaoSoco") 
            {
                vida--;
            }
            else
            {
                Destroy(other.gameObject);
            vida--;
            }
            
            
            if(vida <= 0)
            {
                if (!morreu)
                {
                    GetComponent<ControladorAnimacao>().morte = true;
                    StartCoroutine(GetComponent<TPMovimento>().EndGame());
                    GetComponent<TPMovimento>().fim = true;
                    morreu = true;
                }

               
            }
        }
        if (other.CompareTag("Up"))
        {
            GetComponent<TPMovimento>().nivel++;
            Destroy(other);
        }

        if (other.CompareTag("End"))
        {
            StartCoroutine(GetComponent<TPMovimento>().EndGame());
        }

        if (other.CompareTag("Vida"))
        {
           // Destroy(other.gameObject);
            
            if(vida < limitedevida && vida >=0)
            {
                vida++;
            }
        }

        if (other.CompareTag("Municao"))
        {
            GetComponent<TPMovimento>().municao += Random.Range(10, 30);
            Destroy(other.gameObject);
        }

            if (other.CompareTag("Destroy"))
        {
               Destroy(gameObject);
        }
    }
}
