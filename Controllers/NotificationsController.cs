using Microsoft.Azure.NotificationHubs;
using System.Threading.Tasks;

namespace ShopTemplateAPI.Controllers
{
    public class NotificationsController
    {
        public async Task<NotificationOutcome> ToSendNotificationAsync(string pns, string message, string userTag)
        {
            if (string.IsNullOrEmpty(pns) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(userTag)) 
            {
                return null;
            }
            switch (pns.ToLower())
            {
                case "apns":
                    // iOS
                    var alert = "{\"aps\":{\"alert\":\"" + message + "\"}}";
                    return await Notifications.Instance.Hub.SendAppleNativeNotificationAsync(alert, userTag);
                case "fcm":
                    // Android
                    var notif = "{ \"data\" : {\"message\":\"" + message + "\"}}";
                    return await Notifications.Instance.Hub.SendFcmNativeNotificationAsync(notif, userTag);
                default: return null;
            }
        }
    }
}
