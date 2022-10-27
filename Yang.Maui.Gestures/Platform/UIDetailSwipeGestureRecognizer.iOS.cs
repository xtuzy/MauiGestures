﻿using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Yang.Maui.Gestures.Platform
{
    internal class UIDetailSwipeGestureRecognizer : UISwipeGestureRecognizer
    {
        public CGPoint BeganPoint;
        public double BeganTime;
        public CGPoint EndPoint;
        public double EndTime;
        public UIDetailSwipeGestureRecognizer()
        {
        }

        public UIDetailSwipeGestureRecognizer(Action action) : base(action)
        {
        }

        public UIDetailSwipeGestureRecognizer(System.Action<UISwipeGestureRecognizer> action):base(action) 
        { 
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            var touch = touches.AnyObject as UITouch;
            BeganTime  = new NSDate().SecondsSince1970;
            BeganPoint = touch.LocationInView(View);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            var touch = touches.AnyObject as UITouch;
            EndTime = new NSDate().SecondsSince1970;
            EndPoint = touch.LocationInView(View);
        }
    }
}
