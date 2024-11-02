//using System.IO;
//using UnityEditor;
//using UnityEngine;

//[InitializeOnLoad]
//public static class Script_Atividade
//{
//    static readonly string caminho = "Assets/_Files/Atividade.txt";
//    static Atividade atividade;

//    static Script_Atividade()
//    {
//        EditorApplication.delayCall += Editor_Iniciado;
//        EditorApplication.quitting += Editor_Fechado;
//    }

//    static void Editor_Iniciado()
//    {
//        if (!File.Exists(caminho))
//        {
//            atividade = new Atividade();

//            atividade.data_entradaUltima = Data.DataAtual_Get();
//            atividade.data_saidaUltima = Data.Data_New(Data.DataAtual_Get(), 50, 0, 0, 0, 0, 0);

//            Atividade_Salvar();
//        }
//        else
//        {
//            Atividade_Carregar();

//            if (Data.DataIsMaior(Data.DataAtual_Get(), atividade.data_saidaUltima))
//            {
//                Debug.Log("mudou");

//                atividade.data_entradaUltima = Data.DataAtual_Get();
//                atividade.data_saidaUltima = Data.Data_New(Data.DataAtual_Get(), 50, 0, 0, 0, 0, 0);

//                Atividade_Salvar();
//            }
//        }
//    }

//    static void Editor_Fechado()
//    {
//        Atividade_Carregar();

//        atividade.data_saidaUltima = Data.DataAtual_Get(); //atualiza a data de saida

//        //Data _data_diff = Data.Data_Diff(Data.DataAtual_Get(), atividade.data_entradaUltima); //tempo da sessao
//        //Data da = atividade.data_atividadeTempo;
//        //Data _data5 = Data.Data_New(da, _data_diff);

//        //atividade.data_atividadeTempo = _data5;

//        Atividade_Salvar();
//    }

//    static void Atividade_Carregar()
//    {
//        string _conteudo = File.ReadAllText(caminho);
//        atividade = JsonUtility.FromJson<Atividade>(_conteudo);
//    }

//    static void Atividade_Salvar()
//    {
//        string _conteudo = JsonUtility.ToJson(atividade, true);
//        File.WriteAllText(caminho, _conteudo);
//    }
//}