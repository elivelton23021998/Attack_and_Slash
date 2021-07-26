using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTColetaBolinha : BTNode
{
    bool check;
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.FAILURE;//não precisa entrar no running, ela não precisa
        SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            GameObject[] bolinhas = GameObject.FindGameObjectsWithTag("Moeda");

            foreach (GameObject bola in bolinhas)
            {
                if (Vector3.Distance(bola.transform.position, bt.transform.position) < 1)
                {
                    if (!check)
                    {
                        bt.GetComponent<Inimigos>().StartCoroutine(bt.GetComponent<Inimigos>().GameOver());
                        check = true;
                    }
                    status = Status.SUCCESS;
                }
            }
        }
        if (atributos.amigo)
        {
            GameObject[] bolinhas = GameObject.FindGameObjectsWithTag("Gold");

            foreach (GameObject bola in bolinhas)
            {
                if (Vector3.Distance(bola.transform.position, bt.transform.position) < 1)
                {
                    //GameObject.Destroy(bola);

                    //bt.GetComponent<Inimigos>().anim.Play("Idle");
                    if (!check)
                    {
                        bt.GetComponent<Inimigos>().StartCoroutine(bt.GetComponent<Inimigos>().EndGame());
                        check = true;
                    }
                    status = Status.SUCCESS;
                }
            }
        }

        yield break;//serve só pra corrotina funcionar
    }
}

//observe que este codigo nem tem o estatus RUNNING


