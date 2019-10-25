﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsViewer : MonoBehaviour
{
    public Text[] textstats;
    Avatar MiAvatar;

    Animator an;
    Transform trans;
    Collider coli;
    Vector3 Bounds;
    bool Air = true, gotAvatar=false;

    private void Start()
    {
        StartCoroutine(getAvatar());
    }

    private void Update()
    {
        if (Air && gotAvatar)
        {
            Debug.DrawLine(trans.position + Bounds, trans.position + Bounds + Vector3.down,Color.red);
            if (Physics.Raycast(trans.position + Bounds,Vector3.down,0.5f))
            {
                //Debug.Log("Aterrizó");
                an.SetTrigger("Land");
                Air = false;
            }
        }
    }

    IEnumerator getAvatar()
    {
        yield return new WaitForSeconds(0.1f);
        MiAvatar = FindObjectOfType<Avatar>();
        setStats();
    }

    public void setStats()
    {
        if(MiAvatar != null)
        {
            textstats[0].text = "Nombre:" + MiAvatar.Nombre /*+" "+ MiAvatar.Apellido*/;
            textstats[1].text = "Faltas:" + MiAvatar.Faltas;
            textstats[2].text = "Presencias:" + MiAvatar.Presencias;
            textstats[3].text = "Tarde:" + MiAvatar.Tarde;
            textstats[4].text = "F.Medicas:" + MiAvatar.Medica;
            textstats[5].text = "Sustituto:" + MiAvatar.Sustituto;
            textstats[6].text = "Ref. Recibidas:" + (MiAvatar.RefRE + MiAvatar.RefRI);
            textstats[7].text = "Formaciones:" + MiAvatar.Formaciones;
            textstats[8].text = "Puntualidad:" ;
            textstats[9].text = "Invitados:" + MiAvatar.Invitados;
            textstats[10].text = "Ref. Generadas:" + (MiAvatar.RefGE + MiAvatar.RefGI);
            textstats[11].text = "Unos a Unos:" + MiAvatar.Uno_a_Uno;
            textstats[12].text = "GPNC:" + MiAvatar.GNC;
            textstats[13].text = "Puntaje:" + MiAvatar.Puntuacion;
            gotAvatar = true;
            trans = MiAvatar.GetComponent<Transform>();
            coli = MiAvatar.GetComponent<Collider>();
            an = MiAvatar.GetComponent<Animator>();
                
            Bounds = new Vector3(0,coli.bounds.min.y-0.05f,0);
        }
    }
}
