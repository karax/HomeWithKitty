using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenteDoEstadoDoGato : MonoBehaviour
{
    public float quantMenosSaúde, quantMenosSaciação;
	
	void Start ()
    {
		if (gerenteGeral.arranhador)
        {
            if (gerenteGeral.casaPremium)
            {
                gerenteGeral.saúdeMáximaDoGato = 150;
            }
            else
            {
                gerenteGeral.saúdeMáximaDoGato = 125;
            }
        }
        else if (gerenteGeral.casaPremium)
        {
            gerenteGeral.saúdeMáximaDoGato = 125;
        }
        else
        {
            gerenteGeral.saúdeMáximaDoGato = 100;
        }

        gerenteGeral.saciaçãoMáximadoDoGato = 100;
	}
		
	void Update ()
    {
        gerenteGeral.saciaçãoAtualdoDoGato -= quantMenosSaciação * Time.deltaTime;

        if (gerenteGeral.saciaçãoAtualdoDoGato > 75)
        {
            gerenteGeral.saúdeAtualDoGato -= quantMenosSaúde * Time.deltaTime;
        }
        if (gerenteGeral.saciaçãoAtualdoDoGato > 50)
        {
            gerenteGeral.saúdeAtualDoGato -= quantMenosSaúde * Time.deltaTime;
        }
        if (gerenteGeral.saciaçãoAtualdoDoGato > 25)
        {
            gerenteGeral.saúdeAtualDoGato -= quantMenosSaúde * Time.deltaTime;
        }

        if (!gerenteGeral.foiLimpo)
        {
            gerenteGeral.saúdeAtualDoGato -= quantMenosSaúde * Time.deltaTime * 2;
        }

        if (gerenteGeral.saciaçãoAtualdoDoGato > gerenteGeral.saciaçãoMáximadoDoGato)
        {
            gerenteGeral.saciaçãoAtualdoDoGato = gerenteGeral.saciaçãoMáximadoDoGato;
        }

        if (gerenteGeral.saciaçãoAtualdoDoGato < 0)
        {
            gerenteGeral.saciaçãoAtualdoDoGato = 0;
        }
    }
}
