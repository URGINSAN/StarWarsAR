using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public Transform CamTr;
    public Transform BoxTr;
    public Material WireMaskMat;
    public Transform[] WireSegment;
    [Space]
    public GameObject[] BigWireBroken;
    public GameObject[] BigWireNormal;
    [Space]
    public float[] ZAngles;
    public float DistToBox;
    [Space]
    public GameObject BigWiresSignal;
    public GameObject SmallWiresSignal;
    [Space]
    public int BigWiresCount;
    public bool[] SmallWiresOK;

    private void Start()
    {
        CamTr = Camera.main.transform;
    }

    private void Update()
    {
        DistToBox = Vector3.Distance(CamTr.position, BoxTr.position);
        DistToBox = Mathf.Clamp(DistToBox, 0.6f, 1.0f);
        WireMaskMat.SetFloat("_Cutoff", DistToBox);

        for (int i = 0; i < WireSegment.Length; i++)
        {
            WireSegment[i].localEulerAngles = new Vector3(WireSegment[i].localEulerAngles.x, WireSegment[i].localEulerAngles.y, 
                Mathf.Lerp(WireSegment[i].localEulerAngles.z, ZAngles[i], Time.deltaTime * 5));

            if (WireSegment[i].localEulerAngles.z > 359)
            {
                WireSegment[i].localEulerAngles = new Vector3(WireSegment[i].localEulerAngles.x, WireSegment[i].localEulerAngles.y, 0);
                ZAngles[i] = 0;
            }
        }
    }

    public void OnPressWireSegment(int index)
    {
        SmallWiresOK[index] = false;
        ZAngles[index] += 90;

        if (ZAngles[index] == 90 || ZAngles[index] == 270)
            SmallWiresOK[index] = true;

        CheckWin();
    }

    public void OnPressBigWire(int index)
    {
        BigWireBroken[index].SetActive(false);
        BigWireNormal[index].SetActive(true);

        BigWiresCount++;

        CheckWin();
    }

    void CheckWin()
    {
        BigWiresSignal.SetActive(false);
        SmallWiresSignal.SetActive(false);

        if (BigWiresCount == 3)
        {
            BigWiresSignal.SetActive(true);
        }

        int SmallWiresOKInt = 0;
        for (int i = 0; i < SmallWiresOK.Length; i++)
        {
            if (SmallWiresOK[i])
                SmallWiresOKInt++;
        }

        if (SmallWiresOKInt == 3)
        {
            SmallWiresSignal.SetActive(true);
        }

        if (BigWiresCount == 3 && SmallWiresOKInt == 3)
        {
            print("win");
        }
    }
}
