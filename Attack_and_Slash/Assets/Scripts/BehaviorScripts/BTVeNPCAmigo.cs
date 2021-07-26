using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTVeNPCAmigo : BTNode
{
     public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.FAILURE;
        Print();

        SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            GameObject[] oponentes = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject op in oponentes)
            {
                if (bt.gameObject != op)
                {
                    if (Vector3.Distance(bt.transform.position, op.transform.position) < atributos.alcance)
                    {
                        status = Status.SUCCESS;

                        break;
                    }

                }

            }
        }
        if (atributos.amigo)
        {
            GameObject[] oponentes = GameObject.FindGameObjectsWithTag("NPC"); foreach (GameObject op in oponentes)
            {
                if (bt.gameObject != op)
                {
                    if (Vector3.Distance(bt.transform.position, op.transform.position) < atributos.alcance)
                    {
                        status = Status.SUCCESS;

                        break;
                    }

                }

            }
        }

        
        Print();
        yield break;
    }
}
//O código NÃO é atualizado por frame, ele funciona em UM frame SOMENTE, e somente quando a distancia for menor que 5.
//Não dará null pelo fato de NÃO atualizar por frame, e sim somente quando a distancia for menor que 5.

