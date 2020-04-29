using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Database;
using Kanban.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kanban
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KanbanDbContext>(options => options.UseSqlServer("Server=.;Integrated Security=SSPI;Database=KanbanDB;Trusted_Connection=Yes;MultipleActiveResultSets=True;"));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IItemTaskRepository, ItemTaskRepository>();
            services.AddTransient<ISprintRepository, SprintRepository>();
            services.AddTransient<IBacklogItemRepository, BacklogItemRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
