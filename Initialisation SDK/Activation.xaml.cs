using DJI.WindowsSDK;
using System;
using System.IO;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YamlDotNet.RepresentationModel;

namespace DJIDrone.DJISDKInitializing
{
    public sealed partial class ActivatingPage : Page
    {
        /// <summary>
        /// Enregistrement de l'utilisteur
        /// </summary>
        public ActivatingPage()
        {
            this.InitializeComponent();
            DJISDKManager.Instance.SDKRegistrationStateChanged += Instance_SDKRegistrationEvent;
        }

        private async void Instance_SDKRegistrationEvent(SDKRegistrationState state, SDKError resultCode)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                activateStateTextBlock.Text = state == SDKRegistrationState.Succeeded ? "Activé." : "Inactif.";
                activationInformation.Text = resultCode == SDKError.NO_ERROR ? "Enregistré avec succès :" : resultCode.ToString();
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = "config.yml";
            //using (var reader = new StreamReader(path))
            //{
               // var yml = new YamlStream();
                //yml.Load(reader);
                DJISDKManager.Instance.RegisterApp(activatingCodeTextBox.Text);
                activationInformation.Text = "Enregistrement...";
            //
        }
    }
}
