using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCombateOponente : BTNode
{

    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = null;

        SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            GameObject[] oponentes = GameObject.FindGameObjectsWithTag("Player");

            GameObject projetil = bt.GetComponent<Inimigos>().projetil;
            

            float distancia = Mathf.Infinity;

            foreach (GameObject op in oponentes)
            {
                if (bt.gameObject != op)
                {
                    if (Vector3.Distance(bt.transform.position, op.transform.position) < distancia)
                    {
                        alvo = op;
                        distancia = Vector3.Distance(bt.transform.position, op.transform.position);
                    }
                }
            }
            if (alvo)
            {
                if (atributos.ataca)
                {
                    bt.transform.LookAt(alvo.transform);
                    Transform arma = bt.GetComponent<Inimigos>().arma;
                    Vector3 pontaArma = (arma.transform.position + arma.transform.forward);
                    bt.GetComponent<Inimigos>().anim.Play("GunERun");
                    if (atributos.melee)
                    {
                        bt.GetComponent<Inimigos>().projetil.SetActive(true);
                    }

                    if (!atributos.melee)
                    {
                        GameObject copia = GameObject.Instantiate(projetil, pontaArma, Quaternion.identity);
                        copia.GetComponent<Rigidbody>().AddForce(bt.transform.forward * 1000);
                    }

                }
            }

            else
            {
                bt.GetComponent<Inimigos>().anim.Play("Idle");
                bt.GetComponent<Inimigos>().projetil.SetActive(false);
                status = Status.FAILURE;

            }
        }
        if (atributos.amigo)
        {
            GameObject[] oponentes = GameObject.FindGameObjectsWithTag("NPC");

            GameObject projetil = bt.GetComponent<Inimigos>().projetil;


            float distancia = Mathf.Infinity;

            foreach (GameObject op in oponentes)
            {
                if (bt.gameObject != op)
                {
                    if (Vector3.Distance(bt.transform.position, op.transform.position) < distancia)
                    {
                        alvo = op;
                        distancia = Vector3.Distance(bt.transform.position, op.transform.position);
                    }
                }
            }

            if (alvo)
            {
                if (atributos.ataca)
                {
                    bt.transform.LookAt(alvo.transform);
                    Transform arma = bt.GetComponent<Inimigos>().arma;
                    Vector3 pontaArma = (arma.transform.position + arma.transform.forward);
                    bt.GetComponent<Inimigos>().anim.Play("GunERun");
                    if (atributos.melee)
                    {
                        bt.GetComponent<Inimigos>().projetil.SetActive(true);
                    }

                    if (!atributos.melee)
                    {
                        GameObject copia = GameObject.Instantiate(projetil, pontaArma, Quaternion.identity);
                        copia.GetComponent<Rigidbody>().AddForce(bt.transform.forward * 1000);
                    }

                }
            }

            else
            {
                bt.GetComponent<Inimigos>().anim.Play("Idle");
                bt.GetComponent<Inimigos>().projetil.SetActive(false);
                status = Status.FAILURE;

            }
        }
        
        Print();
        yield break;
    }
    
    
}
 

