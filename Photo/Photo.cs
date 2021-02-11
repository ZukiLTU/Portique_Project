using DJI.WindowsSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using DJIVideoParser;
using DJI.WindowsSDK.Components;

namespace DJIDrone.VideoDrone
{
    public sealed partial class PageVideo : Page
    {
        /// <summary>
        /// Met le mode de la caméra
        /// </summary>
        public void SwitchMode()
        {
            DJISDKManager.Instance.ComponentManager.GetCameraHandler(0, 0).CameraWorkModeChanged += async delegate (object sender, CameraWorkModeMsg? val)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {
                    if(val != null)
                    {
                        lblMode.Text = "Mode : " + val.Value.value.ToString();
                    }
                });
            };
        }

        private void SetCameraWorkModeToShootPhoto_Click(object sender, RoutedEventArgs e)
        {
            SetCameraWorkMode(CameraWorkMode.SHOOT_PHOTO);
        }

        private void SetCameraModeToRecord_Click(object sender, RoutedEventArgs e)
        {
            SetCameraWorkMode(CameraWorkMode.RECORD_VIDEO);
        }

        private async void SetCameraWorkMode(CameraWorkMode mode)
        {
            if (DJISDKManager.Instance.ComponentManager != null)
            {
                CameraWorkModeMsg workMode = new CameraWorkModeMsg
                {
                    value = mode,
                };
                var retCode = await DJISDKManager.Instance.ComponentManager.GetCameraHandler(0, 0).SetCameraWorkModeAsync(workMode);
                if (retCode != SDKError.NO_ERROR)
                {
                    switch (mode)
                    {
                        case CameraWorkMode.SHOOT_PHOTO:
                            string _pmode = "prise photo";
                            lblMode.Text = "Mode" + _pmode.ToString() + " échoué." + "(" + retCode.ToString() + ")";
                            break;
                        case CameraWorkMode.RECORD_VIDEO:
                            string _vmode = "enregistrement vidéo";
                            lblMode.Text = "Mode" + _vmode.ToString() + "échoué." + "(" + retCode.ToString() + ")";
                            break;
                        case CameraWorkMode.MEDIA_DOWNLOAD:
                            string _dlmode = "téléchargement";
                            lblMode.Text = "Mode" + _dlmode.ToString() + "échoué." + "(" + retCode.ToString() + ")";
                            break;
                        case CameraWorkMode.BROADCAST:
                            string _bcmode = "diffusion";
                            lblMode.Text = "Mode" + _bcmode.ToString() + "échoué." + "(" + retCode.ToString() + ")";
                            break;
                        default:
                            lblMode.Text = "Mode inconnu.";
                            break;
                    } 
                }
            }
            else
            {
                //non enregistré
                Console.WriteLine("Licence non enregistrée.");
            }
        }
    }
}
