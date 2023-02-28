using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.LocalNotification;
using System.Text.Json;
using System.Net.Http.Json;
using m0.maui.Interfaces;

namespace m0.maui.Platforms.Android
{
    [Service]
    public class NotificationService : Service, IForegroundService
    {
        public void Start()
        {
            Intent startService = new(MainActivity.ActivityCurrent, typeof(NotificationService));
            startService.SetAction("START_SERVICE");
            MainActivity.ActivityCurrent.StartActivity(startService);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if(intent.Action == "START_SERVICE")
            {
                Task.Run(() => Notification());
            }

            return StartCommandResult.NotSticky;
        }

        private static async Task Notification()
        {
            while(true)
            {
                var notification = new NotificationRequest
                {
                    NotificationId = 1000,
                    Title = "Warning",
                    Description = $"{Singleton.PPM} PPM",
                    BadgeNumber = 42,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = DateTime.Now.AddSeconds(5)
                    }
                };

                await LocalNotificationCenter.Current.Show(notification);
            }
        }
    }
}