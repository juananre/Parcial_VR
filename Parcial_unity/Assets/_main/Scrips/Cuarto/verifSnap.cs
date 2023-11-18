using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class verifSnap : MonoBehaviour
{
    public GameObject objSnap;
    public GameObject objSnap2;
    public GameObject objSnap3;
    public GameObject objSnap4;

    public TextMeshProUGUI enunciadoCajasText;

    private void Update()
    {
        if (todosObjsActivos())
        {
            prenderEnunciaCajas();
        }
    }

    bool todosObjsActivos()
    {
        // Verifica si cada objeto está activo
        return objSnap.activeSelf && objSnap2.activeSelf && objSnap3.activeSelf && objSnap4.activeSelf;
    }

    void prenderEnunciaCajas()
    {
        enunciadoCajasText.fontStyle = FontStyles.Strikethrough;
    }
}
