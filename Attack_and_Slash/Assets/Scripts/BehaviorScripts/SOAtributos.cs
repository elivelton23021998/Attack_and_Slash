using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Atributos")]
public class SOAtributos : ScriptableObject
{
    public Color cor = Color.white;
    public int vidas = 3;
    public int limitedevida = 5;
    public float velocidade = 6;
    public float alcance = 20;
    public bool ataca;
    public bool melee;
    public bool adicionaVida;
    public bool amigo;




}
