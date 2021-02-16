using DJI.WindowsSDK;
using DJI.WindowsSDK.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Joystick_slimDX;
using Windows.Media.Playback;

namespace DJIDrone.VideoDrone
{
    public class Commandes {
        public int Avancer()
        {
            int val;
            // YAxis = -1000 = avancer
            return val;
        }

        public int Reculer()
        {
            //YAxis = 1000 = reculer
        } 

        public int Gauche()
        {
            //XAxis = -1000 = gauche
        }

        public int Droite()
        {
            //YAxis = 1000 = Droite
        }

        public int Monter()
        {
            //Slider0 = -1000
        }

        public int Descendre()
        {
            //Slider0 = 1000;
        }
        public class Boutons
        {
            ushort btnPhoto = 1;
            ushort btnVideo = 2;
            ushort btnDecollage = 12;
            ushort btnReturnHome = 11;

            public void Photo()
            {

            }
        }
    }
}