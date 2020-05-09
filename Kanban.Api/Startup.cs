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
using Microsoft.OpenApi.Models;

namespace Kanban
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Project Kanban for subject 'System sieciowe' by Krzysztof Swiatek", Version = "v1"
                    });
            });
            services.AddDbContext<KanbanDbContext>(options => options.UseSqlServer("Server=.;Integrated Security=SSPI;Database=KanbanDB;Trusted_Connection=Yes;MultipleActiveResultSets=True;"));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IItemTaskRepository, ItemTaskRepository>();
            services.AddTransient<ISprintRepository, SprintRepository>();
            services.AddTransient<IBacklogItemRepository, BacklogItemRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Project Kanban for subject 'System sieciowe' by Krzysztof Swiatek");
            });

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
