using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace iOS_Simulation.Theme.Animations
{
    public class AniShape
    {
        public enum MoveDirection
        {
            x,
            y,
            xy
        }
        public static void fadeIn(UIElement UE)
        {
            fadeIn(UE, AniSettings.animateDuration);
        }

        public static void fadeIn(UIElement UE, double duration)
        {
            ObjectAnimationUsingKeyFrames b_appear = new ObjectAnimationUsingKeyFrames();
            DiscreteObjectKeyFrame d1 = new DiscreteObjectKeyFrame(Visibility.Collapsed);
            DiscreteObjectKeyFrame d2 = new DiscreteObjectKeyFrame(Visibility.Visible);
            d1.KeyTime = TimeSpan.FromSeconds(0);
            d2.KeyTime = TimeSpan.FromSeconds(0);
            b_appear.KeyFrames.Add(d1);
            b_appear.KeyFrames.Add(d2);

            UE.BeginAnimation(UIElement.VisibilityProperty, b_appear);

            UE.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void fadeOut(UIElement UE)
        {
            fadeOut(UE, AniSettings.animateDuration);
        }

        public static void fadeOut(UIElement UE, double duration)
        {
            ObjectAnimationUsingKeyFrames b_appear = new ObjectAnimationUsingKeyFrames();
            DiscreteObjectKeyFrame d1 = new DiscreteObjectKeyFrame(Visibility.Visible);
            DiscreteObjectKeyFrame d2 = new DiscreteObjectKeyFrame(Visibility.Collapsed);
            d1.KeyTime = TimeSpan.FromSeconds(0);
            d2.KeyTime = TimeSpan.FromSeconds(duration);
            b_appear.KeyFrames.Add(d1);
            b_appear.KeyFrames.Add(d2);

            UE.BeginAnimation(UIElement.VisibilityProperty, b_appear);

            UE.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void fadeOn(UIElement UE)
        {
            fadeOn(UE, AniSettings.animateDuration);
        }

        public static void fadeOn(UIElement UE, double duration)
        {
            UE.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1, 0.2, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void fadeOff(UIElement UE)
        {
            fadeOff(UE, AniSettings.animateDuration);
        }

        public static void fadeOff(UIElement UE, double duration)
        {
            UE.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(0.2, 1, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void blurOn(UIElement UE)
        {
            blurOn(UE, AniSettings.animateDuration);
        }

        public static void blurOn(UIElement UE, double duration)
        {
            UE.Effect = new BlurEffect();
            UE.Effect.BeginAnimation(BlurEffect.RadiusProperty, new DoubleAnimation(0, 35, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void blurOff(UIElement UE)
        {
            blurOff(UE, AniSettings.animateDuration);
        }

        public static void blurOff(UIElement UE, double duration)
        {
            UE.Effect = new BlurEffect();
            UE.Effect.BeginAnimation(BlurEffect.RadiusProperty, new DoubleAnimation(35, 0, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void zoomIn(UIElement UE)
        {
            zoomIn(UE, AniSettings.animateDuration);
        }

        public static void zoomIn(UIElement UE, double duration)
        {
            zoom(UE, 0, 1, duration);
        }

        public static void zoomOut(UIElement UE)
        {
            zoomOut(UE, AniSettings.animateDuration);
        }

        public static void zoomOut(UIElement UE, double duration)
        {
            zoom(UE, 1, 0, duration);
        }

        public static void zoom(UIElement UE, double _startValue, double _endValue, double duration)
        {
            UE.RenderTransform = new ScaleTransform();
            UE.RenderTransformOrigin = new Point(0.5, 0.5);
            UE.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, new DoubleAnimation(_startValue, _endValue, new Duration(TimeSpan.FromSeconds(duration))));
            UE.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, new DoubleAnimation(_startValue, _endValue, new Duration(TimeSpan.FromSeconds(duration))));
        }

        public static void shake(UIElement UE)
        {
            shake(UE, 50);
        }
        
        public static void shake(UIElement UE, int distance)
        {
            UE.RenderTransform = new TranslateTransform();
            
            DoubleAnimationUsingKeyFrames translationAnimation = new DoubleAnimationUsingKeyFrames();
            translationAnimation.Duration = TimeSpan.FromSeconds(0.2);

            translationAnimation.KeyFrames.Add(
                new LinearDoubleKeyFrame(
                    distance, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.05))) // KeyTime
                );
            translationAnimation.KeyFrames.Add(
                new LinearDoubleKeyFrame(
                    -distance, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.15))) // KeyTime
                );
            translationAnimation.KeyFrames.Add(
                new LinearDoubleKeyFrame(
                    0, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.2))) // KeyTime
                );
            
            UE.RenderTransform.BeginAnimation(TranslateTransform.XProperty, translationAnimation); 
        }

        public static void move(UIElement UE, MoveDirection direction, int distance, double duration)
        {
            move(UE, direction, 0, distance, duration);
        }

        public static void move(UIElement UE, MoveDirection direction, int from, int to, double duration)
        {
            UE.RenderTransform = new TranslateTransform();
            switch (direction)
            {
                case MoveDirection.x:
                    UE.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(from, to, new Duration(TimeSpan.FromSeconds(duration)))); break;
                case MoveDirection.y:
                    UE.RenderTransform.BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation(from, to, new Duration(TimeSpan.FromSeconds(duration)))); break;
            }
        }

        public static void moveXY(UIElement UE, int top_fr, int top_to, int left_fr, int left_to, double duration)
        {
            Storyboard sbAnimateImage = new Storyboard();
            DoubleAnimation doubleAnimation;

            doubleAnimation = new DoubleAnimation(top_fr, top_to, new Duration(TimeSpan.FromSeconds(duration)));
            Storyboard.SetTarget(doubleAnimation, UE);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            sbAnimateImage.Children.Add(doubleAnimation);

            doubleAnimation = new DoubleAnimation(left_fr, left_to, new Duration(TimeSpan.FromSeconds(duration)));
            Storyboard.SetTarget(doubleAnimation, UE);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            sbAnimateImage.Children.Add(doubleAnimation);

            sbAnimateImage.Begin();
        }

        public static void blink(UIElement UE, bool turnOn)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0.4,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            if (turnOn) UE.BeginAnimation(UIElement.OpacityProperty, animation);
            else UE.BeginAnimation(UIElement.OpacityProperty, null);
        }

    }
}
