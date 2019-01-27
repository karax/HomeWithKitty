using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenteDoEstadoDoGato : MonoBehaviour
{
    public float quantMenosSaúde, quantMenosSaciação;
	
	void Start ()
    {
		
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
    }
}
