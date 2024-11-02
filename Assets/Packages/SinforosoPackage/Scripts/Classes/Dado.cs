using System;

[Serializable]
public class Dado
{
    public int idiomaAtualIndex;
    public bool primeiraLuta; //eh relacionada ao bar    
    public Data data_tavernaReset;
    public string jogadorNome = "";
    public int generosoQuant = 0; //quantidade de vezes q o jogador estava sem nenhum familiar

    //player
    public int playerFamiliaIdAtual; //
    public int itemUsado_idUnico_00 = -1;
    public int itemUsado_idUnico_01 = -1;
    public int itemUsado_idUnico_02 = -1;
}