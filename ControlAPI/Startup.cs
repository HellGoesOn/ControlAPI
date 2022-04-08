using ControlAPI.Contexts;
using ControlAPI.Models;
using ControlAPI.Repositories.Implementations;
using ControlAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddMvc();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));

            services.AddTransient<IBaseRepository<Schedule>, BaseRepository<Schedule>>();
            services.AddTransient<IBaseRepository<Teacher>, BaseRepository<Teacher>>();
            services.AddTransient<IBaseRepository<TeacherSubject>, BaseRepository<TeacherSubject>>();
            services.AddTransient<IBaseRepository<Subject>, BaseRepository<Subject>>();
            services.AddTransient<IBaseRepository<Group>, BaseRepository<Group>>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
