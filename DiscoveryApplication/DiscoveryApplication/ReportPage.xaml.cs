using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

using Xamarin.Essentials;
namespace DiscoveryApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {

        double Latitude;
        double Longitude;
        public ReportPage()
        {
            InitializeComponent();
        }

        private async void BtnHiReport_Clicked(object sender, EventArgs e)
        {
            ///MapPage.test
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    var position = new Position(Latitude, Longitude);
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = "Hi Jack",
                        Address = "Over here There"
                    };
                    ///map.Pins.Add(pin);
                //    lblLat.Text += location.Latitude.ToString();
                //    lblLong.Text += location.Longitude.ToString();
                //    lblAlt.Text += location.Altitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception  
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception  
            }
            catch (Exception ex)
            {
                // Unable to get location  
            }
        }
    }
}