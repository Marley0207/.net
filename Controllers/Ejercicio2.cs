using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Test1.Controllers;


public class Ejercicio2Controller : Controller
{
    private string [] elements = new string [5];

    public Ejercicio2Controller()
    {
        elements[0] = "Fifa o Morir";
        elements[1] = "Mario, sube el camino";
        elements[2] = "El Yugi es para siempre";
        elements[3] = "Como mi joya ninguna";
        elements[4] = "Duerman a .Net";
    }

    public string search(int n)
    {
        int number = n;
        if (number >= 0 && number < elements.Length)
        {
            return elements[number];
        }else{
            return "Índice inválido. El rango válido es de 0 a " + (elements.Length - 1) + ".";
        }
    }

    public string compare(string cadena)
    {
        cadena = cadena.ToUpper();
        foreach (string item in elements)
        {
            string itemMayuscula = item.ToUpper();
            if (itemMayuscula.CompareTo(cadena) == 0)
            {
                return item;
            }
        }
        return "No se encontro la cadena.";
    }
    
}