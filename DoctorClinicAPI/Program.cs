using DoctorClinic.Domain;
using DoctorClinic.PostgresDb;
using DoctorClinic.Services.CommandHandlers;
using DoctorClinic.Services.QueryHandlers;
using DoctorClinic.Utilities.Helpers;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

var connectionString = configuration.GetConnectionString("Default");
// Add services to the container.

 builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository));
builder.Services.AddScoped(typeof(IPatientReservationRepository), typeof(PatientReservationRepository));
//SQLServer
//builder.Services.AddDbContext<DoctorClinicDbContext>(option => option.UseSqlServer(connectionString));

//PostgreSQL
builder.Services.AddDbContext<DoctorClinicDbContext>(options => options.UseNpgsql(connectionString));


builder.Services.AddOptions();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<CreatePatientReservationCommand, bool>, CreatePatientReservationCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateAppointmentCommand, bool>, CreateAppointmentCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetAppointmentsQuery, List<GetAppointmentsOutput>>, GetAppointmentsQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetPatientReservationsQuery, List<GetPatientReservationsOutput>>, GetPatientReservationsQueryHandler>();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
