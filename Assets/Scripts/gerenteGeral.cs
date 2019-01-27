using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenteGeral
{
    public static float saúdeDoGato;
    public static int dinheiro;
    public static int quantDePetiscos;
    public static int quantDeRação;
    public static bool foiAlimentado, foiLimpado;
    public static bool arranhador, casaPremium;
    public static float velocDaPerdaSaúde = .1f;

    public static void diminuirSaúdeDoGato ()
    {
        saúdeDoGato -= velocDaPerdaSaúde;
    }
}
