using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoComprável : MonoBehaviour
{
    public Transform objeto;
    public bool areia, arranhador, casaDeluxe, novelo, rato, bola;

    private void Start()
    {
        if (areia) { if(gerenteGeral.quantDeAreia> 0) { spawnarObjeto(); }}
        if (arranhador) { if (gerenteGeral.arranhador) { spawnarObjeto(); }}
        if (casaDeluxe) { if (gerenteGeral.casaPremium) { spawnarObjeto(); } }
        if (novelo) { if (gerenteGeral.novelo) { spawnarObjeto(); } }
        if (rato) { if (gerenteGeral.rato) { spawnarObjeto(); } }
    }

    void spawnarObjeto ()
    {
        Instantiate(objeto);
    }

    private void Update()
    {
        if (areia)
        {
            if (gerenteGeral.quantDeAreia <= 0)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
