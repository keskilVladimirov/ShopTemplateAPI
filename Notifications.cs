using Microsoft.Azure.NotificationHubs;

namespace ShopTemplateAPI
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://clicknamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=EFqN1PSOAu8zrfEfBESF75eI3prFnIVBzvEetAEXnqQ=",
                                                                            "ClickNotificationHub");
        }
    }
}
