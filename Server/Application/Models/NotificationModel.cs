using Core.Entities;
using System;
using System.Text.Json;

namespace Application.Models
{
    public class NotificationModel
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public bool ForAllUsers { get; set; }
        public Guid? UserId { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
