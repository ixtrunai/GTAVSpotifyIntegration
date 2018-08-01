using GTA;
using SpotifyIntegrationMod;
using System;
using System.Windows.Forms;
using NativeUI;

public class ScriptGTAV : Script
{
    private Spotify spotify = new Spotify();

    public ScriptGTAV()
    {
        Tick += OnTick;
        Interval = 100; //EVERY 100 MILLISECONDS -> OnTick()
    }

    void OnTick(object sender, EventArgs e)
    {
        if (Game.Player.Character.IsInVehicle()) //if player is in vehicle
        {
            onPhoneCallVolume(); //adjust spotify volume
            RadioOff();  //radio off
            spotify.play(); //play spotify
        }
        else{
            spotify.pause(); //pause spotify
        }
    }

    //CALLVolumeAdjustment
    void onPhoneCallVolume()
    {
        Boolean isInCall = GTA.Native.Function.Call<Boolean>(GTA.Native.Hash.IS_MOBILE_PHONE_CALL_ONGOING, GTA.Control.Phone.GetHashCode());
        Boolean isInConver = GTA.Native.Function.Call<Boolean>(GTA.Native.Hash.IS_PED_IN_CURRENT_CONVERSATION, Game.Player.Character.GetHashCode());
        if (isInCall || isInConver)
        {
            spotify.setCallVolume();
        }
        else
        {
            spotify.setNormalVolume();
        }
    }

    //RADIO OFF
    void RadioOff()
    {
        GTA.Vehicle veh = Game.Player.Character.CurrentVehicle;
        veh.RadioStation = GTA.RadioStation.RadioOff;
    }
}
  
