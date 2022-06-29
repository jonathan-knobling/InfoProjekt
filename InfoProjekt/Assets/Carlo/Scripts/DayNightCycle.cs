using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Carlo.Scripts
{
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] private List<Light2D> lights;
        
        private bool lightsActive = false;        
        private Light2D globalLight;
        [SerializeField] private float ticks;
        private float seconds;
        private float minutes;
        [SerializeField]private float hours;
        private float days;
        
        private void Start()
        {
            globalLight = GetComponent<Light2D>();
        }
        
        private void FixedUpdate()
        {
            CalculateTime();
            SigmoidFunction();
            ControlLights();
        }
        
        private void CalculateTime()
        {
            seconds += Time.fixedDeltaTime * ticks;

            if (seconds >= 60)
            {
                seconds = 0;
                minutes += 1;
            }
            
            if (minutes >= 60)
            {
                minutes = 0;
                hours += 1;
            }

            if (hours >= 24)
            {
                hours = 0;
                days += 1;
            }
        }

        private void SigmoidFunction()
        {
            float x = hours + (float)(minutes * 0.01);
            
            if (hours < 12)
            {
                globalLight.intensity = (float)(1 / (1 + Math.Pow(Math.E, - x + 6)));
            }
            
            else if (hours > 12)
            {
                globalLight.intensity = (float)(1 / (1 + Math.Pow(Math.E, x - 20.5)));
            }
        }
        
        private void ControlLights()
        {
            Debug.Log(lightsActive);
            if (hours is > 6 and < 21)
            {
                if (lights[0].intensity > 0)
                {
                    TurnLightsOff();
                    if (lights[0].intensity <= 0)
                    {
                        lightsActive = false;
                    }
                }
            }
            else if (!lightsActive)
            {
                TurnLightsOn();
                if (lights[0].intensity >= 1)
                {
                    lightsActive = true;
                }
            }
            
        }

        private void TurnLightsOn()
        { 
            foreach (var light2D in lights)
            {
                light2D.intensity += 0.01f;
            }
        }

        private void TurnLightsOff()
        {
            foreach (var light2D in lights)
            {
                light2D.intensity -= 0.01f;
            } 
        }
    }
}