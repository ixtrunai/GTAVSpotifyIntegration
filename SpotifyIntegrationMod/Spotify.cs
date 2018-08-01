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
        public static float spotifyVolume;

        public Spotify()
        {
            //SPOTIFY INIT
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

        //NEXT SONG (method not used yet)
        public void next()
        {
            spotify.Skip();
        }

        //PREVIOUS SONG (method not used yet)
        public void previous()
        {
            spotify.Previous();
        }

        //PAUSE SONG
        public void pause()
        {
            if (playing)
            {
                playing = false;
                PressKey(0xb3); // PLAY/PAUSE MULTIMEDIA KEY
            }
        }

        //START SONG
        public void play()
        {
            if (!playing)
            {
                playing = true;
                PressKey(0xb3); // PLAY/PAUSE MULTIMEDIA KEY
            }
        }

        //40% VOLUME ON CALLS OR CONVERS
        public void setCallVolume()
        { 
            spotify.SetSpotifyVolume(40f);
        }

        //100% VOLUME
        public void setNormalVolume()
        {
            spotify.SetSpotifyVolume(100f);
        }

        //KEYPRESS SIMULATION
        internal void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey, 0);
            keybd_event(keyCode, 0x45, KeyeventfExtendedkey | KeyeventfKeyup, 0);
        }
    }
}
