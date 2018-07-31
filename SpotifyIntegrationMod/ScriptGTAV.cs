using GTA;
using SpotifyIntegrationMod;
using System;
using System.Windows.Forms;

public class ScriptGTAV : Script
{
    private Spotify spotify = new Spotify();

    public ScriptGTAV()
    {
        Tick += OnTick;
        Interval = 100; //cada 10 milisegundos
    }

    void OnTick(object sender, EventArgs e)
    {
        if (Game.Player.Character.IsInVehicle())
        {
            ApagarRadio();
            spotify.play();
        }
        else{
            spotify.pause();
        }
    }

    void ApagarRadio()
    {
        GTA.Vehicle veh = Game.Player.Character.CurrentVehicle;
        veh.RadioStation = GTA.RadioStation.RadioOff;
    }
}
  
