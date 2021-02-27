using System;
using System.Windows.Forms;

namespace PopUp.Service
{
    public enum NotificationType
    {
        TimerComplete,
        RestartTimer
    }

    public interface INotificationService
    {
        event Action<NotificationType> NotificationAccepted;

        void Notify(string title, string message, int timeout, NotificationType notificationType, ToolTipIcon icon);
    }
}
