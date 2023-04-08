using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using IA;

public class ControladorAnimacao : MonoBehaviour
{
    //VARIAVEIS
    float tempoTrocaAnim;
    bool andando;
    bool correndo;
    public bool morte=false;

    //VARIAVEIS ASSIST
    private Animator anim;
   // private MorcegoPatrulha mp;

    void Start()
    {
       // mp = GameObject.Find("MorcegoNavMesh").GetComponent<MorcegoPatrulha>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!morte)
        {
            Andando();
            TrocarIdleAnim();
        }
        else
        {
            anim.Play("Morrendo");
        }
    }

    void TrocarIdleAnim()
    {
        if (tempoTrocaAnim < 11f)
        {
            tempoTrocaAnim += Time.deltaTime;
            anim.SetFloat("Tempo", tempoTrocaAnim);
        }

        if (tempoTrocaAnim >= 11f)
        {
            tempoTrocaAnim = 0f;
        }

    }

    void Andando()
    {
        if (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0 )
            andando = true;

        else andando = false;

        if (andando)
        {
            anim.SetBool("NaoAndandoCorrendo", false);
            anim.SetBool("Andando", true);
            tempoTrocaAnim = 0f;
        }
        else
        {
            anim.SetBool("NaoAndandoCorrendo", true);
            anim.SetBool("Andando", false);
        }

        if (andando && Input.GetKey(KeyCode.LeftShift))
        {
            correndo = true;
        }
        else correndo = false;

        if (correndo)
        {
            anim.SetBool("NaoAndandoCorrendo", false);
            anim.SetBool("Correndo", true);
            tempoTrocaAnim = 0f;
        }
        else
        {
            anim.SetBool("Correndo", false);
        }


        if (correndo && Input.GetKeyDown (KeyCode.Space))
        {
            tempoTrocaAnim = 0f;
            anim.SetBool("NaoAndandoCorrendo", false);
            anim.SetBool("PuloCorre", true);
        }
        else anim.SetBool("PuloCorre", false);

    }
}
