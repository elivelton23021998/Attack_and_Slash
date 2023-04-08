using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contrário do -SEQUENCE-, é o -SELECTOR- agora
public class BTSelector : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)//não dá para colocar o this, deve se colocar o parametro
    {
        status = Status.RUNNING;//OBJETO DE ESTATUS QUE VEM DE BTNode
        

        //childreen é o objeto de BTNode que é uma opção para criar varias nodes filhas
        
          foreach(BTNode node in children)
        {
            yield return bt.StartCoroutine(node.Run(bt));
           
            if(node.status == Status.SUCCESS)//caso o leaf dê sucesso... 
            {
                status = Status.SUCCESS;//...o selector da sucesso.
                break;
            }
        }  

        if(status == Status.RUNNING)//caso nenhum dê sucesso...  
        {
            status = Status.FAILURE;//...o selector falha.
        }
        
    }
}