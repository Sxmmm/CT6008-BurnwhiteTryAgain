//////////////////////////////////////////////////
// Author: Zack Raeburn
// Description: 
//////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    private List<LineRenderer> m_activeLR = null;
    private List<LineRenderer> m_inactiveLR = null;

    private GameObject m_lrPrefab = null;

    private void Awake()
    {
        InitialiseVariables();
    }

    private void InitialiseVariables()
    {
        m_activeLR = new List<LineRenderer>();
        m_inactiveLR = new List<LineRenderer>();

        m_lrPrefab = Resources.Load("Prefabs/ZR_LineRenderer") as GameObject;

        for (int i = 0; i < HealthController.HealthControllerCount; ++i)
        {
            GameObject lr = Instantiate(m_lrPrefab, transform);
            m_inactiveLR.Add(lr.GetComponent<LineRenderer>());
        }
    }

    public LineRenderer Activate()
    {
        if (m_inactiveLR.Count == 0)
        {
            GameObject lrObj = Instantiate(m_lrPrefab, transform);
            m_inactiveLR.Add(lrObj.GetComponent<LineRenderer>());
        }

        int index = m_inactiveLR.Count - 1;
        LineRenderer lr = m_inactiveLR[index];
        m_activeLR.Add(lr);
        m_inactiveLR.RemoveAt(index);
        lr.gameObject.SetActive(true);
        return lr;
    }

    public void Deactivate(LineRenderer a_lr)
    {
        if (m_activeLR.Remove(a_lr))
        {
            m_inactiveLR.Add(a_lr);
            a_lr.gameObject.SetActive(false);
        }
    }
}
