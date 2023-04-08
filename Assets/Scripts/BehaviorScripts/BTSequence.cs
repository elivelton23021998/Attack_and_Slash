using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Herdará de BTNode, esta classe será a nossa -SEQUENCE-
//Para dar o StartCoroutine, na classe BTNode e no metodo Run(), passe a BehaviourTree como parametro
public class BTSequence : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)//não dá para colocar o this, deve se colocar o parametro
    {
        status = Status.RUNNING;//OBJETO DE ESTATUS QUE VEM DE BTNode
        

        //childreen é o objeto de BTNode que é uma opção para criar varias nodes filhas
        
          foreach(BTNode node in children)
        {
            yield return bt.StartCoroutine(node.Run(bt));
           
            if(node.status == Status.FAILURE)//caso o leaf falhe... 
            {
                status = Status.FAILURE;//...a sequence falha.
                break;
            }
        }  

        if(status == Status.RUNNING)//caso nenhum falhe...  
        {
            status = Status.SUCCESS;//...a sequence da certo.
        }
       
    }
}
