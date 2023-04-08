using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDarVida : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = null;


        SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            GameObject[] amigoNPC = GameObject.FindGameObjectsWithTag("NPC");
            GameObject projetilVida = bt.GetComponent<Inimigos>().projetilVida;

            float distancia = Mathf.Infinity;

            foreach (GameObject op in amigoNPC)
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
                bt.transform.LookAt(alvo.transform);
                Transform arma = bt.GetComponent<Inimigos>().arma;
                Vector3 pontaArma = (arma.transform.position + arma.transform.forward);
                bt.GetComponent<Inimigos>().anim.Play("GunERun");
                bt.GetComponent<Inimigos>().projetilVida.SetActive(true);
                //GameObject copia = GameObject.Instantiate(projetilVida, arma.position, Quaternion.identity);

            }

            else
            {
                status = Status.FAILURE;
            }
        }
        if (atributos.amigo)
        {
            GameObject[] amigoNPC = GameObject.FindGameObjectsWithTag("Player");
            GameObject projetilVida = bt.GetComponent<Inimigos>().projetilVida;

            float distancia = Mathf.Infinity;

            foreach (GameObject op in amigoNPC)
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
                bt.transform.LookAt(alvo.transform);
                Transform arma = bt.GetComponent<Inimigos>().arma;
                Vector3 pontaArma = (arma.transform.position + arma.transform.forward);
                bt.GetComponent<Inimigos>().anim.Play("GunERun");
                bt.GetComponent<Inimigos>().projetilVida.SetActive(true);
                //GameObject copia = GameObject.Instantiate(projetilVida, arma.position, Quaternion.identity);

            }

            else
            {
                status = Status.FAILURE;
            }
        }
        Print();
        yield break;
    }
    
    
}
