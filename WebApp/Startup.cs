using Data;
using Data.CronJob;
using Data.DataAccess.Implement.AuthModule;
using Data.DataAccess.Implement.BlogModule;
using Data.DataAccess.Implement.EventModule;
using Data.DataAccess.Implement.JobModule;
using Data.DataAccess.Implement.UserModule;
using Data.DataAccess.Interface.AuthModule;
using Data.DataAccess.Interface.BlogModule;
using Data.DataAccess.Interface.EventModule;
using Data.DataAccess.Interface.JobModule;
using Data.DataAccess.Interface.UserModule;
using Data.Database;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Service.CronJob;
using Service.Implement.AuthModule;
using Service.Implement.BlogModule;
using Service.Implement.EventModule;
using Service.Implement.JobModule;
using Service.Implement.UserModule;
using Service.Interface.AuthService;
using Service.Interface.BlogModule;
using Service.Interface.EventModule;
using Service.Interface.JobModule;
using Service.Interface.UserModule;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp
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
            services.AddDbContext<Context>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("FPTDatabase")));
            services.AddHttpContextAccessor();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IBlogTagRepository, BlogTagRepository>();
            services.AddScoped<IBlogTagService, BlogTagService>();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IVoteService, VoteService>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();

            services.AddScoped<IEventParticipantRepository, EventParticipantRepository>();
            services.AddScoped<IEventParticipantService, EventParticipantService>();

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();

            services.AddScoped<IApplyJobRepository, ApplyJobRepository>();
            services.AddScoped<IApplyJobService, ApplyJobService>();

            services.AddCronJob<UpdateEventStatusJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = "* * * * *";
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ValidatorOptions.Global.LanguageManager = new CustomValidator();
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
