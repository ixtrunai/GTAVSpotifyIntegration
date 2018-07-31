using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Local; //Base Namespace
using SpotifyAPI.Local.Enums; //Enums
using SpotifyAPI.Local.Models; //Models for the JSON-responses

namespace SpotifyIntegrationMod
{
    public class Spotify
    {
        //MULTIMEDIA KEYS UTILITIES
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        private const int KeyeventfExtendedkey = 0x1;
        private const int KeyeventfKeyup = 0x2;

        //SPOTIFY
        private static SpotifyLocalAPI spotify;
        private static StatusResponse status;
        Boolean playing = false;
        
        public Spotify()
        {
            //spotify init
            spotify = new SpotifyLocalAPI();
            spotify.Connect();
            status = spotify.GetStatus();
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                SpotifyLocalAPI.RunSpotify();
            }

            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
            {
                SpotifyLocalAPI.RunSpotifyWebHelper();
            }
        }

        //siguiente (no usado)
        public void next()
        {
            spotify.Skip();
        }

        //anterior (no usado)
        public void previous()
        {
            spotify.Previous();
        }

        //parar
        public void pause()
        {
            if (playing)
            {
                playing = false;
                PressKey(0xb3);
            }
        }

        //comenzar
        public void play()
        {
            if (!playing)
            {
                playing = true;
                PressKey(0xb3);
            }
        }

        //SIMULAR PULSADO DE TECLA
        internal void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey, 0);
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey | KeyeventfKeyup, 0);
        }
    }
}
