using HMS.BLL.Services;
using HMS.BLL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.WebAPI.Helper.Extensions
{
    public static class ServiceExtend
    {
        public static IServiceCollection AddServices(this IServiceCollection services )
        {
            if (services==null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IUserService, UserService>();
            return services;

        }
    }
}
