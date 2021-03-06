﻿using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Geolocation;
using Windows.UI;

#if WINDOWS_PHONE_APP
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
#elif WINDOWS_APP
using Bing.Maps;
#endif

namespace ChildTracker.Helpers
{
    public class MapView : Grid, INotifyPropertyChanged
    {
#if WINDOWS_APP
        private Map _map;
        private MapLayer _pinLayer;
#elif WINDOWS_PHONE_APP
        private MapControl _map;
#endif


        public MapView()
        {
#if WINDOWS_APP
            _map = new Map();
            _map.Credentials ="AiFTXnMoalZ-eN9AjO34J_3ZIv0r1rFsnEKOn8TUBD6QvCyoVm7FVGkdNZzM7bVu";
            _pinLayer = new MapLayer();
            _map.Children.Add(_pinLayer);
#elif WINDOWS_PHONE_APP
            _map = new MapControl();
            _map.MapServiceToken = "AiFTXnMoalZ-eN9AjO34J_3ZIv0r1rFsnEKOn8TUBD6QvCyoVm7FVGkdNZzM7bVu";
#endif

            this.Children.Add(_map);
        }

        public double Zoom
        {
            get
            {
                return _map.ZoomLevel;
            }
            set
            {
                _map.ZoomLevel = value;
                OnPropertyChanged("Zoom");
            }
        }

        public Geopoint Center
        {
            get
            {
#if WINDOWS_APP
                return _map.Center.ToGeopoint();
#elif WINDOWS_PHONE_APP
                return _map.Center;
#endif
            }
            set
            {
#if WINDOWS_APP
                _map.Center = value.ToLocation();
#elif WINDOWS_PHONE_APP
                _map.Center = value;
#endif

                OnPropertyChanged("Center");
            }
        }

        public string Credentials
        {
            get
            {
#if WINDOWS_APP 
                return _map.Credentials; 
#elif WINDOWS_PHONE_APP
                return string.Empty;
#endif
            }
            set
            {
#if WINDOWS_APP 
                if (!string.IsNullOrEmpty(value)) 
                { 
                    _map.Credentials = value; 
                } 
#endif

                OnPropertyChanged("Credentials");
            }
        }

        public string MapServiceToken
        {
            get
            {
#if WINDOWS_APP 
                return string.Empty; 
#elif WINDOWS_PHONE_APP
                return _map.MapServiceToken;
#endif
            }
            set
            {
#if WINDOWS_PHONE_APP
                if (!string.IsNullOrEmpty(value))
                {
                    _map.MapServiceToken = value;
                }
#endif

                OnPropertyChanged("MapServiceToken");
            }
        }

        public void SetView(BasicGeoposition center, double zoom)
        {
#if WINDOWS_APP
            _map.SetView(center.ToLocation(), zoom);
            OnPropertyChanged("Center");
            OnPropertyChanged("Zoom");
#elif WINDOWS_PHONE_APP
            _map.Center = new Geopoint(center);
            _map.ZoomLevel = zoom;
#endif
        }

        public void AddPushpin(BasicGeoposition location, string text)
        {
#if WINDOWS_APP
            var pin = new Pushpin()
            {
                Text = text
            };
            MapLayer.SetPosition(pin, location.ToLocation());
            _pinLayer.Children.Add(pin);
#elif WINDOWS_PHONE_APP
    var pin = new Grid()
    {
        Width = 24,
        Height = 24,
        Margin = new Windows.UI.Xaml.Thickness(-12)
    };

    pin.Children.Add(new Ellipse()
    {
        Fill = new SolidColorBrush(Colors.DodgerBlue),
        Stroke = new SolidColorBrush(Colors.White),
        StrokeThickness = 3,
        Width = 24,
        Height = 24
    });

    pin.Children.Add(new TextBlock()
    {
        Text = text,
        FontSize = 12,
        Foreground = new SolidColorBrush(Colors.White),
        HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
        VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center
    });

    MapControl.SetLocation(pin, new Geopoint(location));
    _map.Children.Add(pin);
#endif
        }

        public void ClearMap()
        {
#if WINDOWS_APP
            _pinLayer.Children.Clear();
#elif WINDOWS_PHONE_APP
    _map.Children.Clear();
#endif
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
