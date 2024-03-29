﻿using System;
using System.Collections.Generic;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio
{
    public delegate void AvanceRelato();
   
    public static class Relato
    {
        public static event AvanceRelato Avanzar;
        public static void VictorHugoMorales()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "gol-del-siglo-relatado.mp3";
            wplayer.controls.play();

            // Agregar invocación al evento
            Avanzar.Invoke();

            System.Threading.Thread.Sleep(5000);
            do
            {
                // Agregar invocación al evento
                Avanzar.Invoke();
                
                System.Threading.Thread.Sleep(2000);
            } while (wplayer.playState != WMPLib.WMPPlayState.wmppsStopped);
            System.Threading.Thread.Sleep(4000);
            // Agregar invocación al evento
            Avanzar.Invoke();
            
        }
    }
}
