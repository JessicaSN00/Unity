using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

namespace Consts
{
    public static class CONSTS
    {

        // Default lighting time of the blue light
        public const float G_TIME = 5f;
        // default lighting time of yellow light
        public const float Y_TIME = 3f;
        // default lighting time of all red
        public const float ALLR_TIME = 3f;
        // lighting time when stepping light blinks
        public const float BLINK_TIME = 0.25f;
        // Stage light red → Time to change of car light
        public const float CHANGE_TIME = 3f;

        // Maximum intensity of light bulb type light
        public const float MAX_INTENSITY = 4f;
        // Maximum strength of light bulb type light (step light)
        public const float MAX_P_INTENSITY = 8f;

        // Acceleration of car at normal time
        public const float ACCERALATION = 2f;
    }
}

public class lights_traffic : MonoBehaviour {

    //車灯用のマテリアル(LED)
    //0:青点灯, 1:青消灯, 2:黄点灯, 3:黄消灯, 4:赤点灯, 5:赤消灯
    public Material[] lightMaterial = new Material[6];

    //光源のタイプ
    //0:電球, 1:LED
    public int lightType = 1;


    //車灯の灯火の切り替え（青）
    //SettingLight(切り替える灯火のオブジェクト, 点灯(true) or 消灯(false))
    public void SettingLightG(GameObject lightObject, bool lightStatus)
    {
        //電球式
        if (lightType == 0)
        {
            Light pointLight;
            pointLight = lightObject.GetComponent<Light>();
            if (lightStatus)
            {   //点灯
                if (pointLight.intensity < CONSTS.MAX_INTENSITY)
                {
                    pointLight.intensity += (CONSTS.MAX_INTENSITY / 10);
                }
            }
            else
            {           //Goes off
                if (pointLight.intensity > 0)
                {
                    pointLight.intensity -= (CONSTS.MAX_INTENSITY / 10);
                }
            }
        } //LED式
        else if (lightType == 1)
        {
            if (lightStatus)
            {   //点灯
                lightObject.GetComponent<Renderer>().material = lightMaterial[0];
            }
            else
            {           //消灯
                lightObject.GetComponent<Renderer>().material = lightMaterial[1];
            }
        }
    }

    //車灯の灯火の切り替え（黄）
    //SettingLight(切り替える灯火のオブジェクト, 点灯(true) or 消灯(false))
    public void SettingLightY(GameObject lightObject, bool lightStatus)
    {
        //電球式
        if (lightType == 0)
        {
            Light pointLight;
            pointLight = lightObject.GetComponent<Light>();
            if (lightStatus)
            {   //点灯
                if (pointLight.intensity < CONSTS.MAX_INTENSITY)
                {
                    pointLight.intensity += (CONSTS.MAX_INTENSITY / 10);
                }
            }
            else
            {           //消灯
                if (pointLight.intensity > 0)
                {
                    pointLight.intensity -= (CONSTS.MAX_INTENSITY / 10);
                }
            }
        } //LED式
        else if (lightType == 1)
        {
            if (lightStatus)
            {   //点灯
                lightObject.GetComponent<Renderer>().material = lightMaterial[2];
            }
            else
            {           //消灯
                lightObject.GetComponent<Renderer>().material = lightMaterial[3];
            }
        }
    }

    //車灯の灯火の切り替え（赤）
    //SettingLight(切り替える灯火のオブジェクト, 点灯(true) or 消灯(false))
    public void SettingLightR(GameObject lightObject, bool lightStatus)
    {
        //電球式
        if (lightType == 0)
        {
            Light pointLight;
            pointLight = lightObject.GetComponent<Light>();
            if (lightStatus)
            {   //点灯
                if (pointLight.intensity < CONSTS.MAX_INTENSITY)
                {
                    pointLight.intensity += (CONSTS.MAX_INTENSITY / 10);
                }
            }
            else
            {           //消灯
                if (pointLight.intensity > 0)
                {
                    pointLight.intensity -= (CONSTS.MAX_INTENSITY / 10);
                }
            }
        } //LED式
        else if (lightType == 1)
        {
            if (lightStatus)
            {   //点灯
                lightObject.GetComponent<Renderer>().material = lightMaterial[4];
            }
            else
            {           //消灯
                lightObject.GetComponent<Renderer>().material = lightMaterial[5];
            }
        }
    }
}
