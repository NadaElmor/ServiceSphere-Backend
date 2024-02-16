using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.core.Entities.Assessments;
using ServiceSphere.core.Entities.Users;
using ServiceSphere.repositery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.services
{
    public class NotificationService
    {
        private readonly ServiceSphereContext _context;

        public NotificationService(ServiceSphereContext context)
        {
            _context = context;
           
        }

        public async Task CreateNotificationAsync(string userId, string message)
        {

            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                date = DateTime.Now
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }
    }
}


