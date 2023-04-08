using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODOS OS NÓS IRÃO HERDAR DESSA CLASSE, TORNANDO ESTA CLASSE ABSTRATA (não podendo instanciar BTNode)
public abstract class BTNode 
{
    public enum Status {RUNNING, SUCCESS, FAILURE}//Estados possiveis na behaviour tree
    public Status status;//um objeto com nome status, do tipo Status
    public List<BTNode> children = new List<BTNode>();//opção de lista para inserir varios nós filhos

    //toda classe que herdar BTNode (exemplo: BT_Inimigo: BTNode) 
    //deve se sobrescrever os metodos de BTNode caso os metodos estejam abstratos
    public abstract IEnumerator Run(BehaviourTree bt);//SEMPRE COLOQUE O ROOT COMO PARAMETRO

    public void Print()
    {
    //    string cor = "cyan";
    //    if(status == Status.SUCCESS) cor = "green";
    //    if(status == Status.FAILURE) cor ="orange";
        
    //    Debug.Log("<color=" + cor + ">" + this.ToString() + " : " + status.ToString() + "</color>");
    }

}

