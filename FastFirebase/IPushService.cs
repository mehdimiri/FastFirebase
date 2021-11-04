using FastFirebase.Models;
using System;
using System.Threading.Tasks;

namespace FastFirebase
{
    public interface IPushService
    {
        Task SendPushNotificationAsync(PushJsonModel pushJsonModel);
    }
}
