using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoComprável : MonoBehaviour
{
    public Transform objeto;

	void spawnarObjeto ()
    {
        Instantiate(objeto);
    }
}
