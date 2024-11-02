using System;
using UnityEngine;

[Serializable]
public class Data
{
    public int ano;
    public int mes;
    public int dia;
    public int hora;
    public int minuto;
    public int segundo;

    public static bool DataIsMaior(Data _data1, Data _data2)
    {
        if (_data1.ano != _data2.ano)
            return _data1.ano > _data2.ano;

        if (_data1.mes != _data2.mes)
            return _data1.mes > _data2.mes;

        if (_data1.dia != _data2.dia)
            return _data1.dia > _data2.dia;

        if (_data1.hora != _data2.hora)
            return _data1.hora > _data2.hora;

        if (_data1.minuto != _data2.minuto)
            return _data1.minuto > _data2.minuto;

        return _data1.segundo > _data2.segundo;
    }

    public static Data Data_New(Data _data, int _ano, int _mes, int _dia, int _hora, int _minuto, int _segundo) //cria uma nova data com acrescimo
    {
        //Data_Debug(_data);

        _data.segundo += _segundo;
        _data.minuto += _minuto + _data.segundo / 60;
        _data.segundo %= 60;

        _data.hora += _hora + _data.minuto / 60;
        _data.minuto %= 60;

        _data.dia += _dia + _data.hora / 24;
        _data.hora %= 24;

        _data.mes += _mes;
        _data.ano += _ano;

        while (_data.dia > DiasNoMes(_data.mes, _data.ano))
        {
            _data.dia -= DiasNoMes(_data.mes, _data.ano);
            _data.mes++;

            if (_data.mes > 12)
            {
                _data.mes = 1;
                _data.ano++;
            }
        }

        //Data_Debug(_data);

        return _data;
    }

    public static Data Data_New(Data _data, Data _data2)
    {
        //Data_Debug(_data);

        _data.segundo += _data2.segundo;
        _data.minuto += _data2.minuto + _data.segundo / 60;
        _data.segundo %= 60;

        _data.hora += _data2.hora + _data.minuto / 60;
        _data.minuto %= 60;

        _data.dia += _data2.dia + _data.hora / 24;
        _data.hora %= 24;

        _data.mes += _data2.mes;
        _data.ano += _data2.ano;

        while (_data.dia > DiasNoMes(_data.mes, _data.ano))
        {
            _data.dia -= DiasNoMes(_data.mes, _data.ano);
            _data.mes++;

            if (_data.mes > 12)
            {
                _data.mes = 1;
                _data.ano++;
            }
        }

        //Data_Debug(_data);

        return _data;
    }

    private static int DiasNoMes(int _mes, int _ano)
    {
        switch (_mes)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                if (DateTime.IsLeapYear(_ano))
                    return 29;
                else
                    return 28;
            default:
                throw new ArgumentOutOfRangeException(nameof(_mes), "Mês inválido");
        }
    }

    public static void Data_Debug(Data _data)
    {
        Debug.Log("=====");
        Debug.Log("Ano: " + _data.ano + ", Mes: " + _data.mes + ", Dia: " + _data.dia + ", Hora: " + _data.hora + ", Minuto: " + _data.minuto + ", Segundo: " + _data.segundo);
    }

    public static Data DataAtual_Get()
    {
        return new Data()
        {
            ano = DateTime.Now.Year,
            mes = DateTime.Now.Month,
            dia = DateTime.Now.Day,
            hora = DateTime.Now.Hour,
            minuto = DateTime.Now.Minute,
            segundo = DateTime.Now.Second
        };
    }

    public static Data Data_Diff(Data _data1, Data _data2)
    {
        Data _data = new Data
        {
            ano = Math.Abs(_data1.ano - _data2.ano),
            mes = Math.Abs(_data1.mes - _data2.mes),
            dia = Math.Abs(_data1.dia - _data2.dia),
            hora = Math.Abs(_data1.hora - _data2.hora),
            minuto = Math.Abs(_data1.minuto - _data2.minuto),
            segundo = Math.Abs(_data1.segundo - _data2.segundo)
        };

        return _data;
    }
}