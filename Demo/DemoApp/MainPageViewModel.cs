﻿using Yang.Maui.Gestures;
using System;
using System.Windows.Input;

namespace DemoApp
{
    public class MainPageViewModel : BindableObject
    {
        private readonly INavigation navigation;
        private Point pan, pinch;
        private GestureStatus? panStatus;
        private double rotation, scale;

        public Point Pan { get => pan; set { pan = value; OnPropertyChanged(); } }
        public GestureStatus? PanStatus { get => panStatus; set { panStatus = value; OnPropertyChanged(); } }
        public Point Pinch { get => pinch; set { pinch = value; OnPropertyChanged(); } }
        public double Rotation { get => rotation; set { rotation = value; OnPropertyChanged(); } }
        public double Scale { get => scale; set { scale = value; OnPropertyChanged(); } }

        public MainPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public ICommand PanPointCommand => new Command<PanEventArgs>(args =>
        {
            var point = args.Point;
            Pan = point;
            PanStatus = args.Status;
        });
        
        public ICommand PinchCommand => new Command<PinchEventArgs>(args =>
        {
            Pinch = args.Center;
            Rotation = args.RotationDegrees;
            Scale = args.Scale;
        });

        public ICommand OpenVapoliaCommand => new Command(async () =>
        {
            await navigation.PushAsync(new ContentPage {
                Title = "Web",
                Content = new Grid {
                    BackgroundColor = Colors.Yellow,
                    Children = { new WebView { Source = new UrlWebViewSource { Url = "https://vapolia.fr" }, HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill} }}});
        });

        public ICommand OpenVapoliaPointCommand => new Command<Point>(point =>
        {
            Pan = point;
            OpenVapoliaCommand.Execute(null);
        });

        SwipeEventArgs swipeDetail;
        public SwipeEventArgs SwipeDetail { get => swipeDetail; set { swipeDetail = value; OnPropertyChanged(); } }
        public ICommand SwipeDetailCommand => new Command<SwipeEventArgs>(args =>
        {
            SwipeDetail = args;
        });
    }
}
