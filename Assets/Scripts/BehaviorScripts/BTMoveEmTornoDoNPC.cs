using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMoveEmTornoDoNPC : BTNode
{
    
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = null;
        SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            GameObject[] oponentes = GameObject.FindGameObjectsWithTag("NPC");



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
                
                float tempo = Random.Range(0.8f, 2f);
                float sinal = Mathf.Sign(Random.Range(-1f, 1f));
                while (tempo > 0)
                {
                    tempo -= Time.deltaTime;

                    if (!alvo)
                    {
                        break;
                    }

                    bt.transform.LookAt(alvo.transform);
                    bt.GetComponent<Inimigos>().temInimigo = true;
                    // bt.GetComponent<Inimigos>().anim.Play("GunERun");
                    //é esse//bt.transform.Translate(Vector3.right * sinal * Time.deltaTime * (atributos.velocidade * 1.2f));
                    bt.transform.Translate(Vector3.right * Time.deltaTime * (atributos.velocidade * 1.2f));

                    yield return null;
                }
            }
            if (!alvo)
            {
                bt.GetComponent<Inimigos>().temInimigo = false;
                status = Status.FAILURE;
            }
            else
            {
                status = Status.SUCCESS;
            }
        }


        if (atributos.amigo)
        {
            GameObject[] oponentes = GameObject.FindGameObjectsWithTag("Player");



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
                
                float tempo = Random.Range(0.8f, 2f);
                float sinal = Mathf.Sign(Random.Range(-1f, 1f));
                while (tempo > 0)
                {
                    tempo -= Time.deltaTime;

                    if (!alvo)
                    {
                        break;
                    }

                    bt.transform.LookAt(alvo.transform);
                    bt.GetComponent<Inimigos>().temInimigo = true;
                    // bt.GetComponent<Inimigos>().anim.Play("GunERun");
                    //é esse//bt.transform.Translate(Vector3.right * sinal * Time.deltaTime * (atributos.velocidade * 1.2f));
                    bt.transform.Translate(Vector3.right * Time.deltaTime * (atributos.velocidade * 1.2f));

                    yield return null;
                }
            }
            if (!alvo)
            {
                bt.GetComponent<Inimigos>().temInimigo = false;
                status = Status.FAILURE;
            }
            else
            {
                status = Status.SUCCESS;
            }
        }
    }
}
