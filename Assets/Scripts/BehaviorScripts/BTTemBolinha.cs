using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta será nossa primeira LEAF, ou seja primeira busca de nossa -SEQUENCE-
//PARTE CRIATIVA!
public class BTTemBolinha : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
       status = Status.FAILURE;//começa em falha...

        SOAtributos atributos = bt.GetComponent<Inimigos>().atributos;
        if (!atributos.amigo)
        {
            if (GameObject.FindGameObjectWithTag("Moeda"))//Condição da LEAF, ou seja verificar se tem a tag Bolinha
            {
                status = Status.SUCCESS;//dá sucesso se achar a bolinha
            }
        }
        if (atributos.amigo)
        {
            if (GameObject.FindGameObjectWithTag("Gold"))//Condição da LEAF, ou seja verificar se tem a tag Bolinha
            {
                status = Status.SUCCESS;//dá sucesso se achar a bolinha
            }
        }
        yield break;
    }
}
